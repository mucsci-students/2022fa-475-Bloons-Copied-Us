using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    // Screens
    [SerializeField] private GameObject MainMenuScreen;
    [SerializeField] private GameObject LevelSelectScreen;
    [SerializeField] private GameObject ControlsScreen;
    [SerializeField] private GameObject HelpScreen;
    [SerializeField] private GameObject SettingsScreen;

    // Loading
    [SerializeField] GameObject LoadingIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        LoadingIcon.SetActive(true);
        StartCoroutine(LoadAsyncScene(1));
    }

    IEnumerator LoadAsyncScene(int index)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void Quit()
    {
        Application.Quit(); 
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OpenMainMenu()
    {
        SetAllInactive();
        MainMenuScreen.SetActive(true);
    }

    public void OpenLevelSelect()
    {
        SetAllInactive();
        LevelSelectScreen.SetActive(true);
    }
    public void OpenControlsScreen()
    {
        SetAllInactive();
        ControlsScreen.SetActive(true);
    }

    public void OpenHelpScreen()
    {
        SetAllInactive();
        HelpScreen.SetActive(true);
    }

    public void OpenSettingsScreen()
    {
        SetAllInactive();
        SettingsScreen.SetActive(true);
    }


    private void SetAllInactive()
    {
        MainMenuScreen.SetActive(false);
        LevelSelectScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        HelpScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }

}
