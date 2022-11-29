using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngineInternal;

public class TowerInfo : MonoBehaviour
{

    public GameObject Towerinfo;

    Ray ray;
    RaycastHit hit;

    float damage;
    float range;
    float attackSpeed;

        public void TowerInfoClose()
    {
        if (!Pause.isPaused)
        {
            Towerinfo.SetActive(false);
        }
    }

    public TowerInfo(float damage, float range, float attackSpeed)
    {
        this.damage = damage;
        this.range = range;
        this.attackSpeed = attackSpeed;
    }

    TowerInfo Ballista = new TowerInfo(1, 35, .75f);



    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Tower")
            {
                Towerinfo.SetActive(true);
            }
                
        }
    }
}
