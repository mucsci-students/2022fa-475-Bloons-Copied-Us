using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower1Script : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float fireInterval;
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject FireBallPrefab;

    public TargetMode targetMode = TargetMode.FIRST;

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
        if (!gameObject.GetComponent<TowerScript>().IsPlaced)
        {
            return;
        }

        GameObject first = null;
        GameObject strongest = null;
        GameObject AITarget = null;

        // Loop backwords since we are deleting elements in a list that shift on delete
        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
        {
            // Delete null objects
            if (enemiesInRange[i] == null || enemiesInRange[i].GetComponent<EnemyScript>().isDead)
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
                else if (TowerScript.AIWeight(enemiesInRange[i]) > TowerScript.AIWeight(AITarget))
                    AITarget = enemiesInRange[i];
            }
        }

        if (enemiesInRange.Count > 0)
        {
            Transform target = transform;

            // Update target list

            if (targetMode == TargetMode.FIRST)
            {
                target = first.transform;
            }
            else if (targetMode == TargetMode.STRONGEST)
            {
                target = strongest.transform;
            }
            else if (targetMode == TargetMode.AI)
            {
                target = AITarget.transform;
            }

            Fire(target);
        }

        timer += Time.deltaTime;
    }

    public void Fire(Transform t)
    {
        if (timer > fireInterval)
        {
            GameObject FireBall = Instantiate(FireBallPrefab);
            FireBall.transform.SetPositionAndRotation(pivot.transform.position, pivot.transform.rotation);
            ExplosionScript ts = FireBall.GetComponent<ExplosionScript>();
            ts.target = t.gameObject;
            ts.speed = speed;
            ts.damage = damage;
            ts.range = transform.Find("Range").localScale.x / 2.0f;
            timer = 0f;

            // Testing
            //if (t.gameObject.GetComponent<EnemyScript>().health - damage <= 0)
            //t.gameObject.GetComponent<EnemyScript>().isDead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
