using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesRemaining : MonoBehaviour
{
    public TextMeshProUGUI enemiesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesRemaining.SetText(WaveManager.enemies.ToString());
    }
}
