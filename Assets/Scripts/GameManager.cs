using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum complexity : int
    {
        Easy = 1,
        Medium,
        Hard
    }
    // after menu is made update game difficulty
    public complexity choice = complexity.Easy;

    public static int money = 100;
    public static int moneyPerKill = 5;
    public static int health;
    //deprecated?
    public bool camOn = false;

    [SerializeField] TextMeshProUGUI HealthBar;
    [SerializeField] TextMeshProUGUI MoneyUI;

    private int startMoney;

    // Start is called before the first frame update
    void Start()
    {
        startMoney = money;
        health = (100 / ((int)choice));
        OnRestart();


        // Debug.Log("health: "+ health);
    }

    // Update is called once per frame
    void Update()
    {

        //********************************************
        // controls
        if (GameOver.isDead) return;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!Pause.isPaused)
                {
                    Pause.PauseMenu.SetActive(true);
                    Time.timeScale = 0;
                    Pause.isPaused = !Pause.isPaused;
                }
                else
                {
                    Pause.PauseMenu.SetActive(false);
                    Pause.OptionsMenu.SetActive(false);
                    Time.timeScale = Pause.TimeSliderGet;
                    Pause.isPaused = !Pause.isPaused;
                }
            }
        //********************************************

        HealthBar.SetText("Health: " + health);
        MoneyUI.SetText("Money: " + money);

    }

    void OnRestart()
    {
        //need to reset these class variables after reloading scene
        Time.timeScale = 1;
        GameOver.isDead = false;
        WaveManager.WaveNumber = 0;
        GameManager.money = startMoney;
    }
}
