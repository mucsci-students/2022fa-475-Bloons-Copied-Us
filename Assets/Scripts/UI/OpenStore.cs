using System.Collections;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    [SerializeField] GameObject storeui;
    [SerializeField] GameObject removeui;
    [SerializeField] GameObject InsuffFundsMessage;

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
    int BallistaPrice = 60;
    int MultiBallistaPrice = 85;
    int FireTowerPrice = 150;
    int IceTowerPrice = 140;
    int LightningTowerPrice = 160;
    int PortalTowerPrice = 100;

    public static bool isStoreOpen = false;
    //*********************************************
    // open and close store
    public void StoreOpen()
    {
        if (!Pause.isPaused)
        {
            isStoreOpen = true;
            storeui.SetActive(true);
            Gridmap.SetActive(true);
        }
    }
    public void StoreClose()
    {
        if (!Pause.isPaused)
        {
            isStoreOpen = false;
            storeui.SetActive(false);
            Gridmap.SetActive(false);
        }
    }
    //**********************************************
    // tower buying
    public static GameObject tower;
    public static int towerprice = 0;

    public void BuyBallista()
    {
        bool check = StoreHelper(BallistaPrice);
        if (!check) return;
        tower = Ballista;
        towerprice = BallistaPrice;
    }
    public void Buymultiballista()
    {
        bool check = StoreHelper(MultiBallistaPrice);
        if (!check) return;
        tower = MultiBallista;
        towerprice = BallistaPrice;
    }
    public void Buyfiretower()
    {
        bool check = StoreHelper(FireTowerPrice);
        if (!check) return;
        tower = FireTower;
        towerprice = FireTowerPrice;
    }
    public void Buyicetower()
    {
        bool check = StoreHelper(IceTowerPrice);
        if (!check) return;
        tower = IceTower;
        towerprice = IceTowerPrice;
    }
    public void Buylightningtower()
    {
        bool check = StoreHelper(LightningTowerPrice);
        if (!check) return;
        tower = LightningTower;
        towerprice = LightningTowerPrice;
    }
    public void BuyPortalTower()
    {
        bool check = StoreHelper(PortalTowerPrice);
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
    public bool StoreHelper(int moneycheck)
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




