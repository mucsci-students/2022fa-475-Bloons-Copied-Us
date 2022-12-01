using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LayerChange : MonoBehaviour
{

    private readonly int DEFAULT_LAYER = 0;
    private readonly int IGNORE_RAYCAST_LAYER = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This should be changed to only be ran when the store button is clicked, find is a slow method
        GameObject[] towersList = GameObject.FindGameObjectsWithTag("Tower");
        if (OpenStore.isStoreOpen)
        {
            foreach (GameObject tower in towersList)
            {
                tower.layer = IGNORE_RAYCAST_LAYER;
            }
        }
        else
        {
            foreach (GameObject tower in towersList)
            {
                tower.layer = DEFAULT_LAYER;
            }
        }
    }
}
