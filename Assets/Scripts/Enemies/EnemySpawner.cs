using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
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
}
