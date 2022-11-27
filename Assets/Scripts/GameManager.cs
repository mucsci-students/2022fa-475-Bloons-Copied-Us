using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum complexity : int{
        Easy = 1,
        Medium, 
        Hard
    }
    // after menu is made update game difficulty
    public complexity choice = complexity.Easy; 

    public static int money = 100;
    public static int health;
    public bool camOn = false;

    [SerializeField] TextMeshProUGUI HelathBar;
    [SerializeField] TextMeshProUGUI MoneyUI;

    // Start is called before the first frame update
    void Start()
    {
        health = (100 / (int)(choice));
        // Debug.Log("health: "+ health);
    }   

    // Update is called once per frame
    void Update()
    {
        HelathBar.SetText("Health: " + health); 
        MoneyUI.SetText("Money: "+ money);

    }
}
