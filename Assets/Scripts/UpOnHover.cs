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

    public GameObject towers;
    public GameObject towers2;

    [SerializeField] GameObject Gridmap;

    public static bool placed = false;
 
    void Start() 
    {
        dnPos = transform.position;
        upPos = transform.position + Vector3.up * upAmount;
        currPos = dnPos;
    }
    
    void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, currPos, speed * Time.deltaTime);
        towers = OpenStore.tower;
        if (towers2 != null)
        {
            towers2.transform.position = transform.position;
            towers2.transform.position += new Vector3(0f, 1f, 0f);
        }
    }

    void OnMouseEnter() 
    { 
        currPos = upPos;
        towers2 = Instantiate(towers);
        towers2.transform.position = transform.position;
        towers2.transform.position += new Vector3(0f, 1f, 0f);
        GameObject range = towers2.transform.GetChild(2).gameObject;
        range.SetActive(true);

        if(Input.GetMouseButtonDown(0) && GameManager.money >= OpenStore.towerprice)
        {
            GameManager.money -= OpenStore.towerprice;
            placed = true;
            Gridmap.SetActive(false);
            OpenStore.tower = null;
            OpenStore.towerprice = 0;
        }
    }

    void OnMouseExit()  
    { 
        currPos = dnPos;
        if(!placed){
            Destroy(towers2);
        }
    }
}
