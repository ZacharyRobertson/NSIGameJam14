using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Variables")]
    public float spawnDelay = 1;
    public int enemyIndex;
    public Vector3 spawnPos;

    [Header("Enemy Types")]
    public GameObject[] forestEnemies;
    public GameObject[] lakeEnemies;
    public GameObject[] castleEnemies;
    public GameObject[] currentEnemies;

    [Header("References")]
    public BackgroundScroll scroll;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetEnemies();
        enemyIndex = Random.Range(0, currentEnemies.Length);
        float spawnZ = Random.Range(-30, 30);
        spawnPos = new Vector3(-35, 0, spawnZ);
    }

    void SetEnemies()
    {
        if (scroll != null)
        {
            switch (scroll.level)
            {
                case BackgroundLevel.NULL:
                    break;
                case BackgroundLevel.FOREST:
                    currentEnemies = forestEnemies;
                    break;
                case BackgroundLevel.LAKE:
                    currentEnemies = lakeEnemies;
                    break;
                case BackgroundLevel.CASTLE:
                    currentEnemies = castleEnemies;
                    break;
            }
        }
    }

    IEnumerator SpawnEnemies()
    {
        GameObject clone = Instantiate(currentEnemies[enemyIndex], spawnPos, transform.rotation);
        yield return new WaitForSeconds(spawnDelay);
        spawnDelay = 1;
    }
}
