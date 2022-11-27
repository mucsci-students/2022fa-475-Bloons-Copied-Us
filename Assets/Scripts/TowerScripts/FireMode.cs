using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FireMode
{

    public enum TargetMode : int
    {
        FIRST = 0,
        LAST = 1,
        STRONGEST = 2,
        AI = 3
    }

    public static float AIWeight(GameObject target)
    {
        float travelWeight = 0.5f;
        float healthWeight = 0.4f;
        float speedWeight = 1f;
        return (target.GetComponent<EnemyScript>().health * healthWeight) + (travelWeight * target.GetComponent<EnemyMovement>().distanceTraveled) + (speedWeight * target.GetComponent<EnemyMovement>().speed);
    }

}
