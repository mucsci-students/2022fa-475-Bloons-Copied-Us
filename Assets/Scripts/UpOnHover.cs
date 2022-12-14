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
        if (tower != null)
        {
            tower.transform.position = transform.position;
            tower.transform.position += new Vector3(0f, 1f, 0f);
        }

        if (Input.GetMouseButtonDown(0) && GameManager.money >= OpenStore.towerprice && tower != null && !placed && !Pause.isPaused)
        {
            GameManager.money -= OpenStore.towerprice;
            placed = true;
            tower.transform.Find("Range").gameObject.SetActive(false);
            OpenStore.tower = null;
            OpenStore.towerprice = 0;
            tower.GetComponent<TowerScript>().GroundBelow = this;
            tower.GetComponent<TowerScript>().IsPlaced = true;
        }

    }

    void OnMouseEnter()
    {
        if (OpenStore.tower != null && !placed)
        {
            currPos = upPos;
            tower = Instantiate(OpenStore.tower);
            tower.transform.position = transform.position;
            tower.transform.position += new Vector3(0f, 1f, 0f);
            tower.transform.Find("Range").gameObject.SetActive(true);
        }
        else
        {
            //Debug.Log("Null tower");
        }
    }

    void OnMouseExit()
    {
        //Debug.Log("exit");
        currPos = dnPos;
        if (!placed)
        {
            Destroy(tower);
        }
    }
}
