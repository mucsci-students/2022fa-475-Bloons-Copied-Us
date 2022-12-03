using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int curr;
    public float distanceTraveled = 0;

    void FixedUpdate()
    {
        // Enemy reaches player base
        if (gameObject.transform.position == target[target.Length - 1].position)
        {
            GameManager.health -= Mathf.CeilToInt(gameObject.GetComponent<EnemyScript>().health);
            gameObject.GetComponent<EnemyScript>().Die();
        }

        if (transform.position != target[curr].position)
        {
            Vector3 previousPos = transform.position;
            Vector3 pos = Vector3.MoveTowards(transform.position, target[curr].position, speed * Time.fixedDeltaTime);
            distanceTraveled += Vector3.Distance(previousPos, pos);
            GetComponent<Rigidbody>().MovePosition(pos);
        } 
        else
        {
            if (curr != target.Length -1)
            {
                curr = (curr + 1);
            }
        }

        transform.LookAt(target[curr].position);
        
    }
}
