using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    [SerializeField] GameObject storeui;

    //gridmap display when click on tower to buy
    [SerializeField] GameObject Gridmap;
    [SerializeField] GameObject Ballista;
    [SerializeField] GameObject MultiBallista;
    [SerializeField] GameObject FireTower;
    [SerializeField] GameObject IceTower;
    [SerializeField] GameObject LightningTower;
    [SerializeField] GameObject PortalTower;
    // multiply prices by complexity? 
    // upgrade prices later
    [SerializeField] int BallistaPrice = 5;
    [SerializeField] int MultiBallistaPrice = 10;
    [SerializeField] int FireTowerPrice = 15;
    [SerializeField] int IceTowerPrice = 20;
    [SerializeField] int LightningTowerPrice = 25;
    [SerializeField] int PortalTowerPrice = 30;
    //*********************************************
    // open and close store
    public void storeOpen()
    {
        if(!Pause.isPaused) storeui.SetActive(true);
    }
    public void storeClose()
    {
        if (!Pause.isPaused) storeui.SetActive(false);
    }
    //**********************************************
    // tower buying
    public void buyBallista()
    {
        Gridmap.SetActive(true);
    }
    public void buyMultiBallista()
    {
        Gridmap.SetActive(true);
    }
    public void buyFireTower()
    {
        Gridmap.SetActive(true);
    }
    public void buyIceTower()
    {
        Gridmap.SetActive(true);
    }
    public void buyLightningTower()
    {
        Gridmap.SetActive(true);
    }
    public void buyPortalTower()
    {
        Gridmap.SetActive(true);
    }

}
