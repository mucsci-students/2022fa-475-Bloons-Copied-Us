using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField] float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        float speedDelt = speed * Time.fixedDeltaTime;
        transform.Rotate(0, speedDelt, 0);
    }
}