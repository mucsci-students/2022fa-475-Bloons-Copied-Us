using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeToWave : MonoBehaviour
{
    public TextMeshProUGUI timer;
    int value;
    string holder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(15 - WaveManager.TimerRef >= 0) timer.SetText((15 - WaveManager.TimerRef).ToString());
        if(15 - WaveManager.TimerRef < 0.0) timer.SetText("0");


    }
}
