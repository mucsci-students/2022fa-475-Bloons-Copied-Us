using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerScript : MonoBehaviour
{

	public GameObject target;
	public float speed;
	public float damage;
	public float range;
	private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
		start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, start) > range)
		{
			Destroy (gameObject);
		} else if (target != null) 
		{
			transform.LookAt (target.transform);
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		} else
        {
			transform.position += speed * Time.deltaTime * transform.forward;
		}
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy"))
		{
			other.GetComponent<EnemyScript>().TakeDamage(damage);
			Destroy (gameObject);
		}
	}

}
