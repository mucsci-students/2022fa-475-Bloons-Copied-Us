using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerScript : MonoBehaviour
{

	public GameObject target;
	public float speed;
	public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
		{
			Destroy (gameObject);
		} else {
			transform.LookAt (target.transform);
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		}
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy"))
		{
			other.GetComponent<EnemyScript>().takeDamage(damage);
			Destroy (gameObject);
		}
	}

}
