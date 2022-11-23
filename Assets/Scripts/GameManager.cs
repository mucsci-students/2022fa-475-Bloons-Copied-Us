using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum complexity : int{
        Easy = 1,
        Medium, 
        Hard
    }
    public complexity choice = complexity.Easy; // after menu is made update game difficulty

    public static int money;
    public static int health;

    // Start is called before the first frame update
    void Start()
    {
        health = (100 / (int)(choice));
        // Debug.Log(health);
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
