using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    public int mapChange = 0;

    public Image[] maps;
    public Sprite Nmap0;
    public Sprite Nmap1;
    public Sprite Nmap2;
    public Sprite Nmap3;

    private bool finishedSpawning;

    public GameObject boss;
    public Transform bossSpawnPoint;

    public GameObject healthbar;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));

    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for(int i=0; i<currentWave.count; i++)
        {
            if(player == null)
            {
                yield break;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if(i == currentWave.count - 1)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }
            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }

    private void Update()
    {
        if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;             
                StartCoroutine(StartNextWave(currentWaveIndex));                
            }
            else
            {
                maps[mapChange].sprite = Nmap3;
                Debug.Log("GAME FINISHED!!!!");
                Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
                healthbar.SetActive(true);
            }
            ChangeMap(mapChange);
        }
    }

    void ChangeMap(int mapChangeh)
    {
        Debug.Log("NEW WAVEEEEEEEEEEEEEEEE");
        if(mapChange == 0)
        {
            maps[mapChange].sprite = Nmap0;
        }
        else if(mapChange == 1)
        {
            maps[mapChange].sprite = Nmap1;
        }
        else if (mapChange == 2)
        {
            maps[mapChange].sprite = Nmap2;
        }
        else if (mapChange == 3)
        {
            maps[mapChange].sprite = Nmap3;
        }        
        mapChange += 1;
    }
}
