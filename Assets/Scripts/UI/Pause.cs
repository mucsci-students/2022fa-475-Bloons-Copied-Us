using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public Slider timeSlider;
    public TextMeshProUGUI sliderspeed;
    [SerializeField] GameObject PauseScreen;
    [SerializeField] GameObject OptionsScreen;
    public static float TimeSliderGet;
    public static GameObject PauseMenu;
    public static GameObject OptionsMenu;

    void Awake()
    {
        PauseMenu = PauseScreen;
        OptionsMenu = OptionsScreen;
    }
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
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
    public void Options()
    {
        PauseScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }
    public void Return()
    {
        OptionsScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void LateUpdate()
    {
        // Debug.Log(timeSlider.value);
        if(!Pause.isPaused && !GameOver.isDead)
        {
            TimeSliderGet = timeSlider.value;
            Time.timeScale = timeSlider.value;
            sliderspeed.SetText("Speed: " + timeSlider.value + "x");
        }
    }
}
