using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float health;

    // Used to set dead, so other enemies do not target if this enemy is about to die.
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Die();
    }

    // Made it a method, so in the future we can add animations here
    private void Die ()
    {
        Destroy(gameObject);
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

}
