using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;

    public void ResumeGame()
    {
        if(Pause.isPaused)
        {
        Time.timeScale = 1; //set equal to slider later
        Pause.isPaused = false;
        PauseScreen.SetActive(false);
        }

    }
}
