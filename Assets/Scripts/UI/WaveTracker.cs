using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Wave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Wave.SetText("Wave: " + WaveManager.WaveNumber.ToString());
    }
}
