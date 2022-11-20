using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpOnHover : MonoBehaviour
{
 
    public float upAmount = .7f;
    public float speed = 1f;
    
    private Vector3 dnPos;
    private Vector3 upPos;
    private Vector3 currPos;

    public GameObject tower;
    public GameObject tower2;
 
    void Start() {
        dnPos = transform.position;
        upPos = transform.position + Vector3.up * upAmount;
        currPos = dnPos;
    }
    
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, currPos, speed * Time.deltaTime);
        if (tower2 != null)
        {
            tower2.transform.position = transform.position;
            tower2.transform.position += new Vector3(0f, 1f, 0f);
        }
    }
 
    void OnMouseEnter() { 
        currPos = upPos;
        tower2 = Instantiate(tower);
        tower2.transform.position = transform.position;
        tower2.transform.position += new Vector3(0f, 1f, 0f);
        GameObject range = tower2.transform.GetChild(2).gameObject;
        range.SetActive(true);
    }
    void OnMouseExit()  { 
        currPos = dnPos;
        Destroy(tower2);
    }
}
