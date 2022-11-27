using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FireMode;

public class PortalTower1Script : MonoBehaviour
{

    [SerializeField] float damage;
    [SerializeField] float fireInterval;
    [SerializeField] float cost;
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject FxPrefab;

    public TargetMode targetMode = TargetMode.FIRST;

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

        GameObject first = null;
        GameObject strongest = null;
        GameObject AITarget = null;

        // Loop backwords since we are deleting elements in a list that shift on delete
        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
        {
            // Delete null objects
            if (enemiesInRange[i] == null)
                enemiesInRange.RemoveAt(i);
            else
            {
                // Find farthest enemy
                if (first == null)
                    first = enemiesInRange[i];
                else if (enemiesInRange[i].GetComponent<EnemyMovement>().distanceTraveled > first.GetComponent<EnemyMovement>().distanceTraveled)
                    first = enemiesInRange[i];

                // Find strongest enemy
                if (strongest == null)
                    strongest = enemiesInRange[i];
                else if (enemiesInRange[i].GetComponent<EnemyScript>().health > strongest.GetComponent<EnemyScript>().health)
                    strongest = enemiesInRange[i];

                // AI formula
                if (AITarget == null)
                    AITarget = enemiesInRange[i];
                else if (AIWeight(enemiesInRange[i]) > AIWeight(AITarget))
                    AITarget = enemiesInRange[i];
            }
        }

        if (enemiesInRange.Count > 0)
        {
            Transform target = transform;

            if (targetMode == TargetMode.FIRST)
            {
                target = first.transform;
            } else if (targetMode == TargetMode.STRONGEST)
            {
                target = strongest.transform;
            } else if (targetMode == TargetMode.AI)
            {
                target = AITarget.transform;
            }

            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0;
            Vector3 newDirection = Vector3.RotateTowards(ring.transform.forward, targetDirection, rotateSpeed * Time.deltaTime, 0.0f);
            ring.transform.rotation = Quaternion.LookRotation(newDirection);
            Fire(target);

        }

        timer += Time.deltaTime;
    }

    public void Fire(Transform t)
    {
        if (timer > fireInterval)
        {
            GameObject fx = Instantiate(FxPrefab);
            fx.transform.position = t.position;
            t.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
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
