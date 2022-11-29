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

    string Towertext;
    string TowertextUpgrade;

    string towerSelected;

    

    Ray ray;
    RaycastHit hit;

    

    public TowerInformation Ballista1 = new TowerInformation(1, 35, .75f);

    void Start()
    {
        
    }

        public void TowerInfoClose()
    {
        if (!Pause.isPaused)
        {
            Towerinfotab.SetActive(false);
        }
    }

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
         if(towerSelected == "BallistaTowerlvl01(Clone)"){
            // Debug.Log(Ballista1.damage);
           Towertext = "Damage: " + Ballista1.damage+ "\x0A" + "Range: "+ Ballista1.range+ "\x0A" + "Attack Speed: "+ Ballista1.attackSpeed;
           TowerinfoText.SetText(Towertext);
         }

    }
}
 
public class TowerInformation {
 
    public float damage;
    public float range;
    public float attackSpeed;
 
        public TowerInformation(float damage, float range, float attackSpeed)
    {
        this.damage = damage;
        this.range = range;
        this.attackSpeed = attackSpeed;

    }
}

