using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;
using static TowerScript;
using static UnityEngine.GraphicsBuffer;

public class FireModeUI : MonoBehaviour
{
    [SerializeField] Dropdown Dropdown;
    TargetMode First = TargetMode.FIRST; // 0 index
    TargetMode Strongest = TargetMode.STRONGEST; // 1 index
    TargetMode Optimal = TargetMode.AI; // 2 index

    TargetMode selected;




    //called on event selection
    void Update()
    {
        if (TowerInfo.towerGameobject == null) return;

            Dropdown.GetComponentInChildren<Text>().text = TowerInfo.towerGameobject.GetComponent<TowerScript>().target.ToString();

    }

    public void OnSubmit()
    {

        switch (Dropdown.value)
        {
            case 0:
                   selected = First;
                break;
            case 1:
                   selected = Strongest;
                break;
            case 2:
                selected = Optimal;
                break;
            default:
                break;
        }
        TowerInfo.towerGameobject.GetComponent<TowerScript>().target = selected;

        if(TowerInfo.towerGameobject.GetComponent<TowerScript>().type == TowerType.Ballista)
        {
            TowerInfo.towerGameobject.GetComponent<BallistaTower1Script>().targetMode = selected;
        }
        else if (TowerInfo.towerGameobject.GetComponent<TowerScript>().type == TowerType.Void)
        {
            TowerInfo.towerGameobject.GetComponent<PortalTower1Script>().targetMode = selected;
        }
            
    }
}
