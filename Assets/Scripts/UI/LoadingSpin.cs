using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSpin : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().Rotate(0, 0, -rotateSpeed * Time.deltaTime);
    }
}
