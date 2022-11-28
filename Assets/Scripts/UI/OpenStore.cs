using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    [SerializeField] GameObject storeui;
    [SerializeField] GameObject InsuffFundsMessage;

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
    int MultiBallistaPrice = 85;
    int FireTowerPrice = 125;
    int IceTowerPrice = 140;
    int LightningTowerPrice = 160;
    int PortalTowerPrice = 100;
    //*********************************************
    // open and close store
    public void storeOpen()
    {
        if(!Pause.isPaused)
        {
            storeui.SetActive(true);
            Gridmap.SetActive(true);
        }
    }
    public void storeClose()
    {
        if (!Pause.isPaused)
        {
            storeui.SetActive(false);
            Gridmap.SetActive(false);
        }
    }
    //**********************************************
    // tower buying
    public static GameObject tower;
    public static int towerprice = 0;

    public void buyBallista()
    {
        bool check = storeHelper(BallistaPrice);
        if (!check) return;
        tower = Ballista;
        towerprice = BallistaPrice;
    }
    //public void buymultiballista()
    //{
    //    bool check = storeHelper(MultiBallistaPrice);
    //    if (!check) return;
    //    tower = MultiBallista;
    //    towerprice =  BallistaPrice;
    //}
    //public void buyfiretower()
    //{
    //    bool check =storeHelper(FireTowerPrice);
    //    if (!check) return;
    //    tower = FireTower;
    //    towerprice = FireTowerPrice
    //}
    //public void buyicetower()
    //{
    //    bool check = storeHelper(IceTowerPrice);
    //    if (!check) return;
    //    tower = IceTower;
    //    towerprice = IceTowerPrice;
    //}
    //public void buylightningtower()
    //{
    //    bool check = storeHelper(LightningTowerPrice);
    //    if (!check) return;
    //    tower = LightningTower;
    //    towerprice = LightningTowerPrice;
    //}
    public void buyPortalTower()
    { 
        bool check = storeHelper(PortalTowerPrice);
        if (!check) return;
        tower = PortalTower;
        towerprice = PortalTowerPrice;
    }

    IEnumerator Waiter(float time)
    {
        InsuffFundsMessage.SetActive(true);
        yield return new WaitForSeconds(time);
        InsuffFundsMessage.SetActive(false);
    }
    public bool storeHelper(int moneycheck)
    {
        if (Pause.isPaused) return false;

        if (GameManager.money < moneycheck)
        {
            StartCoroutine(Waiter(1f));
            return false;
        }
        else
        {
            return true;
        }
    }

}
