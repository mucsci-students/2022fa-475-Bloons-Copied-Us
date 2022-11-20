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
    private GameObject ballista;

    private float timer;


    void Start()
    {
        ballista = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

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
            Vector3 newDirection = Vector3.RotateTowards(ballista.transform.forward, targetDirection, rotateSpeed * Time.deltaTime, 0.0f);
            ballista.transform.rotation = Quaternion.LookRotation(newDirection);

        }

        timer += Time.deltaTime;
    }

    public void Fire()
    {
        if (timer > fireInterval)
        {

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
