using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuScript : MonoBehaviour
{

    // Screens
    [SerializeField] private GameObject MainMenuScreen;
    [SerializeField] private GameObject LevelSelectScreen;
    [SerializeField] private GameObject ControlsScreen;
    [SerializeField] private GameObject HelpScreen;
    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private GameObject CreditsScreen;

    // Loading
    [SerializeField] GameObject LoadingIcon;

    // Settings
    [SerializeField] TMPro.TMP_Dropdown Resolution;
    [SerializeField] Toggle Fullscreen;

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

    public void Play(int level)
    {
        LoadingIcon.SetActive(true);
        StartCoroutine(LoadAsyncScene(level));
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
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
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

    public void OpenCreditsScreen()
    {
        SetAllInactive();
        CreditsScreen.SetActive(true);
    }

    public void ResolutionChange()
    {
        if (Resolution.value == 0)
        {
            Screen.SetResolution(1366, 768, Fullscreen.isOn, 0);
        } if (Resolution.value == 1)
        {
            Screen.SetResolution(1920, 1080, Fullscreen.isOn, 0);
        } else if (Resolution.value == 2)
        {
            Screen.SetResolution(2560, 1440, Fullscreen.isOn, 0);
        }
        else if (Resolution.value == 3)
        {
            Screen.SetResolution(3840, 2160, Fullscreen.isOn, 0);
        }
    }

    public void FullscreenChange()
    {
        Screen.fullScreen = Fullscreen.isOn; 
    }


    private void SetAllInactive()
    {
        MainMenuScreen.SetActive(false);
        LevelSelectScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        HelpScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        CreditsScreen.SetActive(false);
    }

}
