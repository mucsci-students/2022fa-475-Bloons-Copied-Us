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

    //called on event selection
    void Update()
    {
        if (TowerInfo.towerGameobject == null) return;

        Dropdown.GetComponentInChildren<Text>().text = TowerInfo.towerGameobject.GetComponent<TowerScript>().target.ToString();
        Dropdown.value = (int) TowerInfo.towerGameobject.GetComponent<TowerScript>().target;
        //Debug.Log(Dropdown.value);

    }

    public void OnSubmit()
    {

        TowerInfo.towerGameobject.GetComponent<TowerScript>().target = (TargetMode) Dropdown.value;
            
    }
}
