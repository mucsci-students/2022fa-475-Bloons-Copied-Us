using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform[] path;
    [SerializeField] private Transform spawn;

    public List<WaveEvent> events = new();

    public int WaveNumber = 0;

    private bool isPlaying = false;

    public void StartWave()
    {
        isPlaying = true;
        ++WaveNumber;
        if (!isPlaying && events.Count != 0)
        {
            events[0].StartEvent();
        }
        else
        {
            Debug.Log("Event ended");
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            StartWave();

        if (!isPlaying)
            return;

        if (!events[0].RunEvent(path, spawn))
        {
            Debug.Log("End Event");
            events.RemoveAt(0);
            if (events.Count == 0)
            {
                Debug.Log("Waves over");
                isPlaying = false;
            }
            else
            {
                GameManager.money += WaveNumber * 5;
                ++WaveNumber;
                events[0].StartEvent();
            }
        }
    }

    [System.Serializable]
    public class WaveEvent
    {
        
        public float duration = 15.0f;
        public List<SpawnInfo> spawnInfos = new();

        private float startTime;

        public void StartEvent()
        {
            startTime = Time.time;
            foreach (var spawnInfo in spawnInfos)
            {
                spawnInfo.Start();
            }
        }

        public bool RunEvent(Transform[] path, Transform spawn)
        {
            if (duration == 0.0f && spawnInfos.Count == 0)
                return false;
            else if (Time.time - startTime > duration && duration != 0.0f)
                return false;

            for (int i = 0; i < spawnInfos.Count; i++)
            {
                spawnInfos[i].ReadyToSpawn(path, spawn);

                if (spawnInfos[i].amount == 0)
                {
                    spawnInfos.RemoveAt(i--);
                }
            }

            return true;
        }

        [System.Serializable]
        public class SpawnInfo
        {

            public GameObject spawnPrefab;
            public int amount;
            public float interval;

            private float lastTime;

            public void Start()
            {
                lastTime = Time.time;
            }

            public void ReadyToSpawn(Transform[] path, Transform spawn)
            {
                if (Time.time - lastTime >= interval)
                {
                    GameObject temp = Instantiate(spawnPrefab);
                    temp.transform.position = spawn.position;
                    temp.transform.rotation = spawn.rotation;
                    temp.GetComponent<EnemyMovement>().target = path;
                    --amount;
                    lastTime = Time.time;
                }
            }

        }

    }

}
