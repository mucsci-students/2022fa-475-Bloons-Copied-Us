using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

	public float delay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }

}
