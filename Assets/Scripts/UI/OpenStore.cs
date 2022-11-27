using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    [SerializeField] GameObject storeui;

    //gridmap display when click on tower to buy
    [SerializeField] GameObject Gridmap;

    [SerializeField] GameObject Ballista;
    // [SerializeField] GameObject MultiBallista;
    // [SerializeField] GameObject FireTower;
    // [SerializeField] GameObject IceTower;
    // [SerializeField] GameObject LightningTower;
    [SerializeField] GameObject PortalTower;
    // multiply prices by complexity? 
    // upgrade prices later
    int BallistaPrice = 75;
    int MultiBallistaPrice = 10;
    int FireTowerPrice = 125;
    int IceTowerPrice = 20;
    int LightningTowerPrice = 25;
    int PortalTowerPrice = 100;
    //*********************************************
    // open and close store
    public void storeOpen()
    {
        if(!Pause.isPaused) storeui.SetActive(true);
        Gridmap.SetActive(true);
    }
    public void storeClose()
    {
        if (!Pause.isPaused) storeui.SetActive(false);
        Gridmap.SetActive(false);
    }
    //**********************************************
    // tower buying
    public static GameObject tower;
    public static int towerprice = 0;

    public void buyBallista()
    {
        tower = Ballista;
        towerprice = BallistaPrice;
    }
    // public void buyMultiBallista()
    // {
    //     Gridmap.SetActive(true);
    //     TowerID = 2;
    // }
    // public void buyFireTower()
    // {
    //     Gridmap.SetActive(true);
    //     TowerID = 3;
    // }
    // public void buyIceTower()
    // {
    //     Gridmap.SetActive(true);
    //     TowerID = 4;
    // }
    // public void buyLightningTower()
    // {
    //     Gridmap.SetActive(true);
    //     TowerID = 5;
    // }
    public void buyPortalTower()
    { 
        tower = PortalTower;
        towerprice = PortalTowerPrice;
    }


}
