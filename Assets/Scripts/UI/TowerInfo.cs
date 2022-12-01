using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngineInternal;
using TMPro;


public class TowerInfo : MonoBehaviour
{
    GameObject towerGameobject;

    public GameObject Towerinfotab;
    [SerializeField] TextMeshProUGUI TowerinfoText;
    [SerializeField] TextMeshProUGUI UpgradeTowerinfoText;
    [SerializeField] TextMeshProUGUI CurrentTowerLevel;
    [SerializeField] TextMeshProUGUI CurrentTowerName;
    [SerializeField] TextMeshProUGUI UpgradeCost;
    [SerializeField] TextMeshProUGUI SellCost;

    [SerializeField] GameObject BallistaPrefab2;
    [SerializeField] GameObject BallistaPrefab3;

    [SerializeField] GameObject PortalPrefab2;
    [SerializeField] GameObject PortalPrefab3;

    string Towertext;
    string TowertextUpgrade;

    string towerSelected;

    //***********************************************************************************************
    //Tower Objects

    //TowerInformation(string name, int level, float damage, float range, float attackSpeed, int upgrade, int sell)

    // ballista objects
    public TowerInformation Ballista1 = new("Ballista", 1, 1, 35, .75f, 100, 60);
    public TowerInformation Ballista2 = new("Ballista", 2, 2, 40, .5f, 200, 120);
    public TowerInformation Ballista3 = new("Ballista", 3, 3, 50, .25f, 999999, 180);

    // portal tower objects
    public TowerInformation PortalTower1 = new("PortalTower", 1, 3, 3, .9f, 120, 80);
    public TowerInformation PortalTower2 = new("PortalTower", 2, 4, 32.5f, .8f, 240, 160);
    public TowerInformation PortalTower3 = new("PortalTower", 3, 5, 35, .75f, 999999, 240);
    //continue with towers


    //************************************************************************************************
    //OnClickMethods

    //Buy Upgrade Method
    public void UpgradeTower()
    {
        if (Pause.isPaused) return;

        // Everytower must have TowerScript!
        TowerScript tower = towerGameobject.GetComponent<TowerScript>();

        //Ballista
        if (tower.type == TowerScript.TowerType.Ballista && tower.level == 1) UpgradeTowerHelper(Ballista1, BallistaPrefab2);
        else if (tower.type == TowerScript.TowerType.Ballista && tower.level == 2) UpgradeTowerHelper(Ballista2, BallistaPrefab3);
        //Void
        else if (tower.type == TowerScript.TowerType.Void && tower.level == 1) UpgradeTowerHelper(PortalTower1, PortalPrefab2);
        else if (tower.type == TowerScript.TowerType.Void && tower.level == 2) UpgradeTowerHelper(PortalTower2, PortalPrefab3);

        Towerinfotab.SetActive(false);
    }

    //Sell Tower Method
    public void SellTower()
    {
        if (Pause.isPaused) return;
        bool flag = true;
        switch (towerSelected)
        {
            case "BallistaTowerlvl01(Clone)":
                GameManager.money += Ballista1.sell;
                break;
            case "BallistaTowerlvl02(Clone)":
                GameManager.money += Ballista2.sell;
                break;
            case "BallistaTowerlvl03(Clone)":
                GameManager.money += Ballista3.sell;
                break;
            case "PortalTowerlvl01(Clone)":
                GameManager.money += PortalTower1.sell;
                break;
            case "PortalTowerlvl02(Clone)":
                GameManager.money += PortalTower2.sell;
                break;
            case "PortalTowerlvl03(Clone)":
                GameManager.money += PortalTower3.sell;
                break;
            default:
                flag = false;
                break;
        }
        if (flag)
        {
            towerGameobject.GetComponent<TowerScript>().GroundBelow.placed = false;
            Destroy(towerGameobject);
        }
        Towerinfotab.SetActive(false);

    }
    //************************************************************************************************
    //Close info interface
    public void TowerInfoClose()
    {
        if (!Pause.isPaused)
        {
            Towerinfotab.SetActive(false);

            //Reset tower position
            towerGameobject.transform.localPosition -= new Vector3(0.0f, 0.5f, 0.0f);

            // Remove link
            towerGameobject = null;
        }
    }
    //************************************************************************************************

    void Update()
    {
        // Left click check
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray that has direction Camera -> mouse
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast a ray 500 units without a layercast(-1) and ignoreing colliders set to triggers
            if (Physics.Raycast(ray, out RaycastHit hit, 500f, -1, QueryTriggerInteraction.Ignore))
            {
                Debug.Log(hit.collider.name);

                // Only count as tower selected if it has right tower and the store is closed and it is not the same object, so the height doesnt increase more
                if (hit.collider.CompareTag("Tower") && !OpenStore.isStoreOpen && hit.collider.gameObject != towerGameobject)
                {
                    // Open tower info on gui
                    Towerinfotab.SetActive(true);
                    towerSelected = hit.collider.name;
                    towerGameobject = hit.collider.gameObject;

                    // Move tower up to signal that the tower is selected
                    towerGameobject.transform.localPosition += new Vector3(0.0f, 0.5f, 0.0f);
                }
            }
        }



        //************************************************************************************************
        // Ballista Selection
        if (towerSelected == "BallistaTowerlvl01(Clone)")
        {
            SetTowerStats(Ballista1, Ballista2);
        }
        else if (towerSelected == "BallistaTowerlvl02(Clone)")
        {
            SetTowerStats(Ballista2, Ballista3);
        }
        else if (towerSelected == "BallistaTowerlvl03(Clone)")
        {
            SetTowerStatsMax(Ballista3);
        }

        // PortalTower Selection
        else if (towerSelected == "PortalTowerlvl01(Clone)")
        {
            SetTowerStats(PortalTower1, PortalTower2);
        }
        else if (towerSelected == "PortalTowerlvl02(Clone)")
        {
            SetTowerStats(PortalTower2, PortalTower3);
        }
        else if (towerSelected == "PortalTowerlvl03(Clone)")
        {
            SetTowerStatsMax(PortalTower3);
        }
        // Other tower continue from here
        //************************************************************************************************

    }

    private void SetTowerStats(TowerInformation tower1, TowerInformation tower2)
    {
        Towertext = "Damage: " + tower1.damage + "\x0A" + "Range: " + tower1.range + "\x0A" + "Attack Speed: " + tower1.attackSpeed;
        TowerinfoText.SetText(Towertext);
        TowertextUpgrade = "Damage: " + tower2.damage + "\x0A" + "Range: " + tower2.range + "\x0A" + "Attack Speed: " + tower2.attackSpeed;
        UpgradeTowerinfoText.SetText(TowertextUpgrade);

        UpgradeCost.SetText("Upgrade: $" + tower1.upgrade);
        SellCost.SetText("Sell: $" + tower1.sell);
        CurrentTowerLevel.SetText("Current Level: <" + tower1.level.ToString() + ">");
        CurrentTowerName.SetText("Tower: <" + tower1.name + ">");
    }

    private void SetTowerStatsMax(TowerInformation tower1)
    {
        Towertext = "Damage: " + tower1.damage + "\x0A" + "Range: " + tower1.range + "\x0A" + "Attack Speed: " + tower1.attackSpeed;
        TowerinfoText.SetText(Towertext);
        TowertextUpgrade = "Damage: Max" + "\x0A" + "Range: Max" + "\x0A" + "Attack Speed: Max";
        UpgradeTowerinfoText.SetText(TowertextUpgrade);

        UpgradeCost.SetText("Upgrade: $" + tower1.upgrade);
        SellCost.SetText("Sell: $" + tower1.sell);
        CurrentTowerLevel.SetText("Current Level: <" + tower1.level.ToString() + ">");
        CurrentTowerName.SetText("Tower: <" + tower1.name + ">");
    }

    private void UpgradeTowerHelper(TowerInformation oldTower, GameObject newTower)
    {
        if (GameManager.money >= oldTower.upgrade)
        {
            var temp = Instantiate(newTower, towerGameobject.transform.position, newTower.transform.rotation);
            temp.GetComponent<TowerScript>().GroundBelow = towerGameobject.GetComponent<TowerScript>().GroundBelow;
            Destroy(towerGameobject);
            GameManager.money -= oldTower.upgrade;
        }
    }
}

public class TowerInformation
{

    public float damage;
    public float range;
    public float attackSpeed;
    public string name;
    public int level;
    public int upgrade;
    public int sell;

    public TowerInformation(string name, int level, float damage, float range, float attackSpeed, int upgrade, int sell)
    {
        this.name = name;
        this.level = level;
        this.damage = damage;
        this.range = range;
        this.attackSpeed = attackSpeed;
        this.upgrade = upgrade;
        this.sell = sell;
    }
}

