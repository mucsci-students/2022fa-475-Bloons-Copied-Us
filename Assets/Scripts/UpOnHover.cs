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
 
    void Start() {
        dnPos = transform.position;
        upPos = transform.position + Vector3.up * upAmount;
        currPos = dnPos;
    }
    
    void Update() {
            transform.position = Vector3.MoveTowards(transform.position, currPos, speed * Time.deltaTime);
    }
 
    void OnMouseEnter() { currPos = upPos; }
    void OnMouseExit()  { currPos = dnPos; }
}
