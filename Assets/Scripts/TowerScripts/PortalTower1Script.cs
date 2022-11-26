using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTower1Script : MonoBehaviour
{

    [SerializeField] float damage;
    [SerializeField] float fireInterval;
    [SerializeField] float cost;
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject FxPrefab;

    public int fireMode = FireMode.FIRST;

    private List<GameObject> enemiesInRange = new();
    private GameObject ring;

    private float timer;


    void Start()
    {
        ring = transform.GetChild(0).gameObject;
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

            if (fireMode == FireMode.FIRST)
            {
                target = enemiesInRange[0].transform;
                Fire(enemiesInRange[0]);
            }

            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0;
            Vector3 newDirection = Vector3.RotateTowards(ring.transform.forward, targetDirection, rotateSpeed * Time.deltaTime, 0.0f);
            ring.transform.rotation = Quaternion.LookRotation(newDirection);

        }

        timer += Time.deltaTime;
    }

    public void Fire(GameObject target)
    {
        if (timer > fireInterval)
        {
            GameObject fx = Instantiate(FxPrefab);
            fx.transform.position = target.transform.position;
            target.GetComponent<EnemyScript>().takeDamage(damage);
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
