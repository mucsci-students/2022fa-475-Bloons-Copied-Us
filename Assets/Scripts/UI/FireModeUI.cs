using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class FireModeUI : MonoBehaviour
{
    [SerializeField] Dropdown Dropdown;
    TargetMode First = TargetMode.FIRST; // 0 index
    TargetMode Strongest = TargetMode.STRONGEST; // 1 index
    TargetMode Optimal = TargetMode.AI; // 2 index


    //called on event selection
    public void OnSubmit()
    {
        Debug.Log(Dropdown.value);
        switch (Dropdown.value)
        {
            case 0:
                TowerInfo.towerGameobject.GetComponent<TowerScript>().target = First;
                break;
            case 1:
                TowerInfo.towerGameobject.GetComponent<TowerScript>().target = Strongest;
                break;
            case 2:
                TowerInfo.towerGameobject.GetComponent<TowerScript>().target = Optimal;
                break;
            default:
                break;
        }
        Debug.Log(TowerInfo.towerGameobject.GetComponent<TowerScript>().target);
    }
}
