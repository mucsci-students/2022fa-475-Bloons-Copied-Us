using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngineInternal;
using TMPro;


public class TowerInfo : MonoBehaviour
{

    public GameObject Towerinfotab;
    [SerializeField] TextMeshProUGUI TowerinfoText;
    [SerializeField] TextMeshProUGUI UpgradeTowerinfoText;
    [SerializeField] TextMeshProUGUI CurrentTowerLevel;
    [SerializeField] TextMeshProUGUI CurrentTowerName;
    [SerializeField] TextMeshProUGUI UpgradeCost;
    [SerializeField] TextMeshProUGUI SellCost;

    string Towertext;
    string TowertextUpgrade;


    string towerSelected;

    Ray ray;
    RaycastHit hit;

    //***********************************************************************************************
                                            //Tower Objects

    //ballista objects
    public TowerInformation Ballista1 = new TowerInformation("Ballista", 1, 1, 35, .75f, 100, 60 );
    public TowerInformation Ballista2 = new TowerInformation("Ballista", 2, 2, 40, .5f, 200, 120);
    public TowerInformation Ballista3 = new TowerInformation("Ballista", 3, 3, 50, .25f, 999999, 180);

    // portal tower objects
    public TowerInformation PortalTower1 = new TowerInformation("PortalTower", 1, 3, 3, .9f, 120, 80);
    public TowerInformation PortalTower2 = new TowerInformation("PortalTower", 2, 4, 32.5f, .8f, 240, 160);
    public TowerInformation PortalTower3 = new TowerInformation("PortalTower", 3, 5, 35, .75f, 999999, 240);
    //continue with towers


    //************************************************************************************************
                                            //OnClickMethods

    //Buy Upgrade Method
    public void UpgradeTower()
    { 

    }

    //Sell Tower Method
        public void SellTower()
    { 

    }
    //************************************************************************************************
                                        //Close info interface
        public void TowerInfoClose()
    {
        if (!Pause.isPaused)
        {
            Towerinfotab.SetActive(false);
        }
    }
    //************************************************************************************************

    void Update()
    {
        // TowerInfo Ballista1 = new TowerInfo(1, 35, .75f);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Tower")
            {
                Towerinfotab.SetActive(true);
                towerSelected = hit.collider.name; 
            }
                
        }

        //************************************************************************************************
                                            // Ballista Selection
         if(towerSelected == "BallistaTowerlvl01(Clone)"){
           Towertext = "Damage: " + Ballista1.damage+ "\x0A" + "Range: "+ Ballista1.range+ "\x0A" + "Attack Speed: "+ Ballista1.attackSpeed;
           TowerinfoText.SetText(Towertext);
           TowertextUpgrade = "Damage: " + Ballista2.damage+ "\x0A" + "Range: "+ Ballista2.range+ "\x0A" + "Attack Speed: "+ Ballista2.attackSpeed;
           UpgradeTowerinfoText.SetText(TowertextUpgrade);

           UpgradeCost.SetText("Upgrade: $"+Ballista1.upgrade);
           SellCost.SetText("Sell: $"+Ballista1.sell);
           CurrentTowerLevel.SetText("Current Level: <"+Ballista1.level.ToString()+">");
           CurrentTowerName.SetText("Tower: <"+Ballista1.name+">");
         }
         if(towerSelected == "BallistaTowerlvl02(Clone)"){
           Towertext = "Damage: " + Ballista2.damage+ "\x0A" + "Range: "+ Ballista2.range+ "\x0A" + "Attack Speed: "+ Ballista2.attackSpeed;
           TowerinfoText.SetText(Towertext);
           TowertextUpgrade = "Damage: " + Ballista3.damage+ "\x0A" + "Range: "+ Ballista3.range+ "\x0A" + "Attack Speed: "+ Ballista3.attackSpeed;
           UpgradeTowerinfoText.SetText(TowertextUpgrade);

           UpgradeCost.SetText("Upgrade: $"+Ballista2.upgrade);
           SellCost.SetText("Sell: $"+Ballista2.sell);
           CurrentTowerLevel.SetText("Current Level: <"+Ballista2.level.ToString()+">");
           CurrentTowerName.SetText("Tower: <"+Ballista2.name+">");
         }
         if(towerSelected == "BallistaTowerlvl03(Clone)"){
           Towertext = "Damage: Max"+ "\x0A" + "Range: Max"+  "\x0A" + "Attack Speed: Max";
           TowerinfoText.SetText(Towertext);
           TowertextUpgrade = "Damage: " + Ballista3.damage+ "\x0A" + "Range: "+ Ballista3.range+ "\x0A" + "Attack Speed: "+ Ballista3.attackSpeed;
           UpgradeTowerinfoText.SetText(TowertextUpgrade);

           UpgradeCost.SetText("Upgrade: MAX");
           SellCost.SetText("Sell: $"+Ballista3.sell);
           CurrentTowerLevel.SetText("Current Level: <"+Ballista3.level.ToString()+">");
           CurrentTowerName.SetText("Tower: <"+Ballista3.name+">");
         }

                                            // PortalTower Selection
        if(towerSelected == "PortalTowerlvl01(Clone)"){
           Towertext = "Damage: " + PortalTower1.damage+ "\x0A" + "Range: "+ PortalTower1.range+ "\x0A" + "Attack Speed: "+ PortalTower1.attackSpeed;
           TowerinfoText.SetText(Towertext);
           TowertextUpgrade = "Damage: " + PortalTower2.damage+ "\x0A" + "Range: "+ PortalTower2.range+ "\x0A" + "Attack Speed: "+ PortalTower2.attackSpeed;
           UpgradeTowerinfoText.SetText(TowertextUpgrade);

           UpgradeCost.SetText("Upgrade: $"+PortalTower1.upgrade);
           SellCost.SetText("Sell: $"+PortalTower1.sell);
           CurrentTowerLevel.SetText("Current Level: <"+PortalTower1.level.ToString()+">");
           CurrentTowerName.SetText("Tower: <"+PortalTower1.name+">");
         }
         if(towerSelected == "PortalTowerlvl02(Clone)"){
           Towertext = "Damage: " + PortalTower2.damage+ "\x0A" + "Range: "+ PortalTower2.range+ "\x0A" + "Attack Speed: "+ PortalTower2.attackSpeed;
           TowerinfoText.SetText(Towertext);
           TowertextUpgrade = "Damage: " + PortalTower3.damage+ "\x0A" + "Range: "+ PortalTower3.range+ "\x0A" + "Attack Speed: "+ PortalTower3.attackSpeed;
           UpgradeTowerinfoText.SetText(TowertextUpgrade);

           UpgradeCost.SetText("Upgrade: $"+PortalTower2.upgrade);
           SellCost.SetText("Sell: $"+PortalTower2.sell);
           CurrentTowerLevel.SetText("Current Level: <"+PortalTower2.level.ToString()+">");
           CurrentTowerName.SetText("Tower: <"+PortalTower2.name+">");
         }
         if(towerSelected == "PortalTowerlvl03(Clone)"){
           Towertext = "Damage: Max"+ "\x0A" + "Range: Max"+  "\x0A" + "Attack Speed: Max";
           TowerinfoText.SetText(Towertext);
           TowertextUpgrade = "Damage: " + PortalTower3.damage+ "\x0A" + "Range: "+ PortalTower3.range+ "\x0A" + "Attack Speed: "+ PortalTower3.attackSpeed;
           UpgradeTowerinfoText.SetText(TowertextUpgrade);

           UpgradeCost.SetText("Upgrade: MAX");
           SellCost.SetText("Sell: $"+PortalTower2.sell);
           CurrentTowerLevel.SetText("Current Level: <"+PortalTower3.level.ToString()+">");
           CurrentTowerName.SetText("Tower: <"+PortalTower3.name+">");
         }
         // Other tower continue from here
         //************************************************************************************************

    }
}
 
public class TowerInformation {
 
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

