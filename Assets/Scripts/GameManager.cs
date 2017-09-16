using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;


    [Header("Progress")]
    public bool gateADetsroyed, gateBdestroyed, gateCdestroyed;
    public float timerA, timerB, timerC;
    public GameObject currentGate;

    [Header("References")]
    public BackgroundScroll scroll;
    public Player player;
    public GameObject gateA, gateB, gateC;
    public Transform gateSpawn;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scroll != null)
        {
            if (!gateADetsroyed && !gateBdestroyed && !gateCdestroyed)
            {
                scroll.level = BackgroundLevel.FOREST;
                timerA += Time.deltaTime;
                if (timerA >= 90)
                {
                   currentGate =  Instantiate(gateA, gateSpawn.position, gateSpawn.rotation);
                }
                if(timerA >= 90 && !currentGate.activeInHierarchy)
                {
                    gateADetsroyed = true;
                }
            }
        }
    }
}
