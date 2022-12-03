using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

	public GameObject target;
	public GameObject ExplosionFxPrefab;
	public float speed;
	public float damage;
	public float range;
	private Vector3 start;
	public List<GameObject> inRange = new();

	// Start is called before the first frame update
	void Start()
	{
		start = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < inRange.Count; ++i)
		{
			if (inRange[i].gameObject != null && Vector3.Distance(transform.position, inRange[i].transform.position) < 1f)
			{
				Explode();
			}
		}

		if (Vector3.Distance(transform.position, start) > range)
		{
			Destroy(gameObject);
		}
		else if (target != null)
		{
			transform.LookAt(target.transform);
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		}
		else
		{
			transform.position += speed * Time.deltaTime * transform.forward;
		}
	}

	private void Explode()
    {
		for (int i = 0; i < inRange.Count; ++i)
		{
			if (inRange[i].gameObject != null)
			{
				inRange[i].GetComponent<EnemyScript>().TakeDamage(damage);
			}
		}

		Instantiate(ExplosionFxPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			inRange.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			inRange.Remove(other.gameObject);
		}
	}

}
