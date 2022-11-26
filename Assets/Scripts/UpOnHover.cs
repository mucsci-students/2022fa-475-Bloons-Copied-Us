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

    public bool placed = false;
 
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

        if (Input.GetMouseButtonDown(0) && GameManager.money >= OpenStore.towerprice && towers2 != null && !placed)
        {
            Debug.Log(gameObject.name);
            GameManager.money -= OpenStore.towerprice;
            placed = true;
            towers2.transform.Find("Range").gameObject.SetActive(false);
            OpenStore.tower = null;
            OpenStore.towerprice = 0;
        }
    }

    void OnMouseEnter() 
    {
        Debug.Log("enter");
        if (towers != null && !placed)
        {
            currPos = upPos;
            towers2 = Instantiate(towers);
            towers2.transform.position = transform.position;
            towers2.transform.position += new Vector3(0f, 1f, 0f);
            towers2.transform.Find("Range").gameObject.SetActive(true);
        } else
        {
            Debug.Log("Null tower");
        }
    }

    void OnMouseExit()  
    {
        Debug.Log("exit");
        currPos = dnPos;
        if(!placed){
            Destroy(towers2);
        }
    }
}
