using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
    
{
    public static int EnemiesKilled = 0;

    [SerializeField] GameObject GameOverMenu;
    [SerializeField] TextMeshProUGUI WaveReached;
    [SerializeField] TextMeshProUGUI EnemiesSlain;
    public static bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Called in late update so updates after health display 
    void LateUpdate()
    {
        if (GameManager.health <= 0)
        {
            //Debug.Log("health gone");
            death();

        }
    }

    public void death()
    {
        WaveReached.SetText("Wave Reached: " + WaveManager.WaveNumber.ToString());
        EnemiesSlain.SetText("Enemies Slain: "+EnemiesKilled);
        GameOverMenu.SetActive(true);
        Time.timeScale = 0;
        isDead = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
