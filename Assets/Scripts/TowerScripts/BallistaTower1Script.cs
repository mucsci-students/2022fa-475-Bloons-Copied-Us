using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaTower1Script : MonoBehaviour
{

    [SerializeField] float damage;
    [SerializeField] float fireInterval;
    [SerializeField] float cost;
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject ArrowPrefab;

    public int fireMode = FireMode.FIRST;

    private List<GameObject> enemiesInRange = new();
    private GameObject pivot;

    private float timer;


    void Start()
    {
        pivot = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
		{
			if (enemiesInRange[i] == null)
				enemiesInRange.RemoveAt(i);
		}

        if (enemiesInRange.Count > 0)
        {
            Transform target = transform;

            // Update target list

            if (fireMode == FireMode.FIRST)
            {

                target = enemiesInRange[0].transform;
            }

            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0;
            Vector3 newDirection = Vector3.RotateTowards(pivot.transform.forward, targetDirection, rotateSpeed * Time.deltaTime, 0.0f);
            pivot.transform.rotation = Quaternion.LookRotation(newDirection);
            Fire (target);

        }

        timer += Time.deltaTime;
    }

    public void Fire(Transform t)
    {
        if (timer > fireInterval)
        {
            GameObject arrow = Instantiate (ArrowPrefab);
            arrow.transform.rotation = pivot.transform.rotation;
            arrow.transform.position = pivot.transform.position;
            TrackerScript ts = arrow.GetComponent<TrackerScript>();
            ts.target = t.gameObject;
            ts.speed = 20f;
            ts.damage = damage;
            timer = 0f;
        }
    }

    private void Upgrade()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
