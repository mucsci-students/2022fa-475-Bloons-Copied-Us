using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    public Transform[] target;
    public float speed = 3;
    private int curr;
    public float distanceTraveled = 0;
    
    public bool isActive = false;
    public float damage = 1;
    public int price = 200;

    private Animator anim;

    BoxCollider coll;

    void Awake()
    {
        coll = this.GetComponent<BoxCollider>();
        coll.enabled = false;
    }

    public void startGoblin(){
        anim = gameObject.GetComponent<Animator>();

        if(isActive == false){
            Debug.Log("Goblin Started");
            isActive = true;
            coll.enabled = true;
            anim.Play("Move01");
        }
    }

    public void buyGoblin(){
        if(isActive == false){
            if(GameManager.money > price){
                GameManager.money -= price;
                startGoblin();
            }
        }
    }

    void FixedUpdate()
    {
        if(isActive){

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
                    curr = (curr + 1) % target.Length;
                }
                else 
                {
                    curr = 0;
                    isActive = false;
                    coll.enabled = false;
                }
            } 

            if (target[curr].position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f,270f,0f);
                //Debug.Log("triggered");
            }
            if (target[curr].position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f,90f,0f);
                //Debug.Log("triggered");
            }
            if (target[curr].position.z < transform.position.z)
            {
                transform.rotation = Quaternion.Euler(0f,180f,0f);
                //Debug.Log("triggered");
            }
            if (target[curr].position.z > transform.position.z)
            {
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                //Debug.Log("triggered");
            }
        }
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy"))
		{
            //Debug.Log("COLLIDER");
			other.GetComponent<EnemyScript>().TakeDamage(damage);
            anim.Play("Attack01");
			//Destroy (gameObject);
		}
	}
}
