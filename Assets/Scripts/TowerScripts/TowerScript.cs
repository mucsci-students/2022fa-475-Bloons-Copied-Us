using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;


public enum TargetMode : int
{
    FIRST = 0,
    STRONGEST = 1,
    AI = 2
}
public class TowerScript : MonoBehaviour
{
    // Link to the UpOnHover script that is attached to gameObject below tower. Gets set in towerInfo & upOnHover
    public UpOnHover GroundBelow = null;
    public TowerType type;
    public TargetMode target;

    // Should never be changed since we instantiate a new tower when upgrading
    public int level = 1;

    // Only target if tower is placed
    public bool IsPlaced = false;

    public enum TowerType : int
    {
        Ballista = 0,
        Void = 1,
        Fire = 2,
        Lightning = 3,
        Ballista3 = 4,
        Ice = 5
    }

    //void LateUpdate()
    //{
    //    if (TowerInfo.towerGameobject == null)
    //    {
    //        return;
    //    }

    //    //accesses and sets tower mode in respective tower scripts
    //    //if (TowerInfo.towerGameobject.GetComponent<TowerScript>().type == TowerType.Ballista)
    //    //{

    //    //    TowerInfo.towerGameobject.GetComponent<BallistaTower1Script>().targetMode = target;
    //    //}
    //    //Debug.Log(TowerInfo.towerGameobject.GetComponent<BallistaTower1Script>().targetMode);


    //    //if (TowerInfo.towerGameobject.GetComponent<TowerScript>().type == TowerType.Void)
    //    //{
    //    //    TowerInfo.towerGameobject.GetComponent<PortalTower1Script>().targetMode = target;
    //    //}
    //    //else if(TowerInfo.towerGameobject.GetComponent<TowerScript>().type == TowerType.Fire)
    //    //{
    //    //    TowerInfo.towerGameobject.GetComponent<PortalTower1Script>().targetMode = target;
    //    //}        
    //    //else if(TowerInfo.towerGameobject.GetComponent<TowerScript>().type == TowerType.Lightning)
    //    //{
    //    //    TowerInfo.towerGameobject.GetComponent<PortalTower1Script>().targetMode = target;
    //    //}        
    //    //else if(TowerInfo.towerGameobject.GetComponent<TowerScript>().type == TowerType.Ballista3)
    //    //{
    //    //    TowerInfo.towerGameobject.GetComponent<PortalTower1Script>().targetMode = target;
    //    //}      
    //    //else if(TowerInfo.towerGameobject.GetComponent<TowerScript>().type == TowerType.Ice)
    //    //{
    //    //    TowerInfo.towerGameobject.GetComponent<PortalTower1Script>().targetMode = target;
    //    //}
    //}


    public static float AIWeight(GameObject target)
    {
        float travelWeight = 0.5f;
        float healthWeight = 0.4f;
        float speedWeight = 1f;
        return (target.GetComponent<EnemyScript>().health * healthWeight) + (travelWeight * target.GetComponent<EnemyMovement>().distanceTraveled) + (speedWeight * target.GetComponent<EnemyMovement>().speed);
    }

}
