using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{

	public GameObject target;
	public float speed;
	public float damage;
	public float range;
	public float maxDistance = 0;

	private Vector3 start;
	public float distanceTraveled = 0;

	private Vector3 pos;
	private bool hitOnce = false;

	// Start is called before the first frame update
	void Start()
	{
		start = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		// Phase 1
		if (!hitOnce)
		{

			// Move
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

		// Phase 2
		else
		{
			// Move
			if (Vector3.Distance(transform.position, start) > range || distanceTraveled > maxDistance)
			{
				Destroy(gameObject);
			}
			else if (transform.position != pos)
			{
				Vector3 next = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
				distanceTraveled += Vector3.Distance(transform.position, next);
				transform.position = next;
			} else
            {
				Destroy(gameObject);
            }
		}
	}

	private void Hit(GameObject hit)
	{
		hitOnce = true;
		pos = hit.GetComponent<EnemyMovement>().LastPosition();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			if (!hitOnce)
            {
				Hit(other.gameObject);
            }
			other.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
			hitOnce = true;
		}
	}
}
