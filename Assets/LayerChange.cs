using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LayerChange : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] towersList = GameObject.FindGameObjectsWithTag("Tower");
        Debug.Log(towersList);
        if (OpenStore.isStoreOpen)
        {
            foreach (GameObject go in towersList)
            {
                go.layer = 2;
            }
        }
        else
        {
            foreach (GameObject go in towersList)
            {
                go.layer = 0;
            }
        }
    }
}
