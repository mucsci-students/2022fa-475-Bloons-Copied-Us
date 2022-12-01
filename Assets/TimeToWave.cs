using UnityEngine;
using TMPro;

public class TimeToWave : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI timerText;
    private string text;

    void Start()
    {
        text = timerText.text;
        timerText.SetText("");
        timer.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveManager.enemies != 0)
        {
            timer.gameObject.SetActive(false);
            timerText.SetText("");
        } 
        else if (WaveManager.WaveNumber > 0)
        {
            timer.gameObject.SetActive(true);
            timerText.SetText(text);
            if (15 - WaveManager.TimerRef >= 0) timer.SetText((15 - (int)WaveManager.TimerRef).ToString());
            else if (15 - WaveManager.TimerRef < 0.0) timer.SetText("0");
        }

    }
}
