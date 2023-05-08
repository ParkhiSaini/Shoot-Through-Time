using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private List<int> enemyCounts = new List<int>();
    [SerializeField] private List<float> spawnDelays = new List<float>();
    [SerializeField] private List<float> waveIntervals = new List<float>();

    [SerializeField] public int maxWaves = 0;
    public int currentWave = 0;
    public TextMeshProUGUI wavenumber;
    public TextMeshProUGUI GameOverwavenumber;
    public TextMeshProUGUI Winwavenumber;
    public int enemiesSpawned = 0;
    public TextMeshProUGUI killcount;
    public TextMeshProUGUI GameOverkillcount;
    public TextMeshProUGUI Winkillcount;
    public int kills = 0;
    public Transform[] spawnPoints;
    public GameObject player;

    private void Start()
    {
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoints = new Transform[spawnPointObjects.Length];

        for (int i = 0; i < spawnPointObjects.Length; i++)
        {
            spawnPoints[i] = spawnPointObjects[i].transform;
        }

        // Call the SpawnEnemies method every "waveIntervals[currentWave]" seconds, starting after "spawnDelays[currentWave]" seconds.
        InvokeRepeating("SpawnEnemies", spawnDelays[currentWave], waveIntervals[currentWave]);
    }

    void Update()
    {
        wavenumber.text = currentWave.ToString()+ "/"+ maxWaves.ToString() ;
        killcount.text = kills.ToString();
        GameOverwavenumber.text = currentWave.ToString()+ "/"+ maxWaves.ToString() ;
        Winwavenumber.text = currentWave.ToString()+ "/"+ maxWaves.ToString() ;
        GameOverkillcount.text = kills.ToString();
        Winkillcount.text = kills.ToString();
    }

    private void SpawnEnemies()
    {
        if (currentWave >= enemyCounts.Count || currentWave >= maxWaves)
        {
            // Stop the InvokeRepeating call when we've spawned all waves.
            CancelInvoke("SpawnEnemies");
            Debug.Log("Cancelled");
            return;
        }

        for (int i = 0; i < enemyCounts[currentWave]; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], GetNearestSpawnPoint().position, Quaternion.identity);
            // Set any additional properties of the enemy here
            enemiesSpawned++;
        }

        Debug.Log("Starting Wave " + (currentWave + 1));
        currentWave++;
    }

    private Transform GetNearestSpawnPoint()
    {
        Transform nearestSpawnPoint = spawnPoints[0];
        float nearestDistance = Mathf.Infinity;
        foreach (Transform spawnPoint in spawnPoints)
        {
            float distance = Vector3.Distance(spawnPoint.position, player.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestSpawnPoint = spawnPoint;
            }
        }
        return nearestSpawnPoint;
    }

    public void EnemyDefeated()
    {
        enemiesSpawned--;
        kills+=1;
        Debug.Log(enemiesSpawned);
    }
}
