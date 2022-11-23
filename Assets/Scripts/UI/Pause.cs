using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] GameObject PauseScreen;

    public void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseScreen.SetActive(true);
    }
}
