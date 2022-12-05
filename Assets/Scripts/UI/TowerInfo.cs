using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngineInternal;
using TMPro;
using UnityEngine.UI;
using System;

public class TowerInfo : MonoBehaviour
{
    [SerializeField] GameObject TowerImage;
    public static GameObject towerGameobject;

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

    [SerializeField] GameObject FirePrefab2;
    [SerializeField] GameObject FirePrefab3;

    string Towertext;
    string TowertextUpgrade;

    string towerSelected;

    //***********************************************************************************************
    //Tower Objects

    //TowerInformation(string name, int level, float damage, float range, float attackSpeed, int upgrade, int sell)

    // ballista objects

    // ballista objects
    public TowerInformation Ballista1 = new("Ballista", 1, 1, 35, .75f, 135, 45);
    public TowerInformation Ballista2 = new("Ballista", 2, 2, 40, .6f, 325, 100);
    public TowerInformation Ballista3 = new("Ballista", 3, 4, 45, .45f, 999999, 245);

    // portal tower objects
    public TowerInformation PortalTower1 = new("PortalTower", 1, 2, 30, .9f, 220, 75);
    public TowerInformation PortalTower2 = new("PortalTower", 2, 4, 32.5f, .8f, 400, 158);
    public TowerInformation PortalTower3 = new("PortalTower", 3, 7, 35, .75f, 999999, 300);

    // fire tower objects
    public TowerInformation FireTower1 = new("FireTower", 1, 3, 25, 1.5f, 450, 113);
    public TowerInformation FireTower2 = new("FireTower", 2, 4, 27.5f, 1.5f, 900, 225);
    public TowerInformation FireTower3 = new("FireTower", 3, 5, 30, 1.5f, 999999, 414);
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
        //Fire
        else if (tower.type == TowerScript.TowerType.Fire && tower.level == 1) UpgradeTowerHelper(FireTower1, FirePrefab2);
        else if (tower.type == TowerScript.TowerType.Fire && tower.level == 2) UpgradeTowerHelper(FireTower2, FirePrefab3);
        TowerInfoClose();
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
            case "FireTowerlvl01(Clone)":
                GameManager.money += FireTower1.sell;
                break;
            case "FireTowerlvl02(Clone)":
                GameManager.money += FireTower2.sell;
                break;
            case "FireTowerlvl03(Clone)":
                GameManager.money += FireTower3.sell;
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
        TowerInfoClose();

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

                    // Fix nasa tower bug
                    if (towerGameobject != null) towerGameobject.transform.localPosition -= new Vector3(0.0f, 0.5f, 0.0f);

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
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers1/Ballista1");
        }
        else if (towerSelected == "BallistaTowerlvl02(Clone)")
        {
            SetTowerStats(Ballista2, Ballista3);
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers2/Ballista2");
        }
        else if (towerSelected == "BallistaTowerlvl03(Clone)")
        {
            SetTowerStatsMax(Ballista3);
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers3/Ballista3");
        }

        // PortalTower Selection
        else if (towerSelected == "FireTowerlvl01(Clone)")
        {
            SetTowerStats(FireTower1, FireTower2);
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers1/FireTower1");
        }
        else if (towerSelected == "FireTowerlvl02(Clone)")
        {
            SetTowerStats(FireTower2, FireTower3);
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers2/FireTower2");
        }
        else if (towerSelected == "FireTowerlvl03(Clone)")
        {
            SetTowerStatsMax(PortalTower3);
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers3/FireTower3");
        }

        // FireTower Selection
        else if (towerSelected == "PortalTowerlvl01(Clone)")
        {
            SetTowerStats(PortalTower1, PortalTower2);
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers1/PortalTower1");
        }
        else if (towerSelected == "PortalTowerlvl02(Clone)")
        {
            SetTowerStats(PortalTower2, PortalTower3);
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers2/PortalTower2");
        }
        else if (towerSelected == "PortalTowerlvl03(Clone)")
        {
            SetTowerStatsMax(PortalTower3);
            TowerImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Towers3/PortalTower3");
        }
        // Other tower continue from here
        //************************************************************************************************

    }

    private void SetTowerStats(TowerInformation tower1, TowerInformation tower2)
    {
        Towertext = "Damage: " + tower1.damage + "\x0A" + "Range: " + tower1.range + "\x0A" + "Attack Speed: " + Math.Round(1.0f/tower1.attackSpeed,2);
        TowerinfoText.SetText(Towertext);
        TowertextUpgrade = "Damage: " + tower2.damage + "\x0A" + "Range: " + tower2.range + "\x0A" + "Attack Speed: " + Math.Round(1.0f / tower2.attackSpeed,2);
        UpgradeTowerinfoText.SetText(TowertextUpgrade);

        UpgradeCost.SetText("Upgrade: $" + tower1.upgrade);
        SellCost.SetText("Sell: $" + tower1.sell);
        CurrentTowerLevel.SetText("Current Level: <" + tower1.level.ToString() + ">");
        CurrentTowerName.SetText("Tower: <" + tower1.name + ">");
    }

    private void SetTowerStatsMax(TowerInformation tower1)
    {
        Towertext = "Damage: " + tower1.damage + "\x0A" + "Range: " + tower1.range + "\x0A" + "Attack Speed: " + Math.Round(1.0f / tower1.attackSpeed,2);
        TowerinfoText.SetText(Towertext);
        TowertextUpgrade = "Damage: Max" + "\x0A" + "Range: Max" + "\x0A" + "Attack Speed: Max";
        UpgradeTowerinfoText.SetText(TowertextUpgrade);

        UpgradeCost.SetText("Upgrade: MAX");
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
            towerGameobject = temp;
            towerGameobject.GetComponent<TowerScript>().IsPlaced = true;
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

