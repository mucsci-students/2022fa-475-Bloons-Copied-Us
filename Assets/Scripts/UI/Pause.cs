using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public Slider timeSlider;
    public TextMeshProUGUI sliderspeed;
    [SerializeField] GameObject PauseScreen;

    public void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseScreen.SetActive(true);
    }

        public void ResumeGame()
    {
        if(Pause.isPaused)
        {
        Time.timeScale = timeSlider.value; //set equal to slider later
        Pause.isPaused = false;
        PauseScreen.SetActive(false);
        }

    }
       
    public void LateUpdate()
    {
        Debug.Log(timeSlider.value);
        Time.timeScale = timeSlider.value;
        sliderspeed.SetText("Speed: " + timeSlider.value + "x");
    }
}
