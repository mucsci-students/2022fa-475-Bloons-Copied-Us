using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    // Link to the UpOnHover script that is attached to gameObject below tower. Gets set in towerInfo & upOnHover
    public UpOnHover GroundBelow = null;

    public enum TowerType : int
    {
        Ballista = 0,
        Void = 1,
        Fire = 2,
        Lightning = 3,
        Ballista3 = 4,
        Ice = 5
    }

    public TowerType type;

    // Should never be changed since we instantiate a new tower when upgrading
    public int level = 1;

}
