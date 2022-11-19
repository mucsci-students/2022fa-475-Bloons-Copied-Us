using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int curr;


    void FixedUpdate()
    {
        if (transform.position != target[curr].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[curr].position, speed * Time.fixedDeltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        } 
        else
        {
            if (curr != target.Length -1)
            {
                curr = (curr + 1) % target.Length;
            }
        } 
        
    }
}
