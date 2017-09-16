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
        ProgressLevel();
    }

    void ProgressLevel()
    {
        //If we have a scroll reference
        if (scroll != null)
        {
            //If no gates have been destroyed
            if (!gateADetsroyed && !gateBdestroyed && !gateCdestroyed)
            {
                //Set the scroll level and material
                scroll.level = BackgroundLevel.FOREST;
                // Make our timer count up
                timerA += Time.deltaTime;
                //Once our timer reaches a certain point
                if (timerA >= 90)
                {
                    //Instantiate the current gate
                    currentGate = Instantiate(gateA, gateSpawn.position, gateSpawn.rotation);
                }
                //Once that is destroyed(making sure to reference the timer so it does not happen before the gate spawns)
                if (timerA >= 90 && !currentGate.activeInHierarchy)
                {
                    //Set our first gate to be destroyed and progress to the next level
                    gateADetsroyed = true;
                }
            }
            //Once the first gate is destroyed
            if (gateADetsroyed && !gateBdestroyed && !gateCdestroyed)
            {
                //Set the scroll level and material
                scroll.level = BackgroundLevel.LAKE;
                // Make our timer count up
                timerB += Time.deltaTime;
                //Once our timer reaches a certain point
                if (timerB >= 90)
                {
                    //Instantiate the current gate
                    currentGate = Instantiate(gateB, gateSpawn.position, gateSpawn.rotation);
                }
                //Once that is destroyed(making sure to reference the timer so it does not happen before the gate spawns)
                if (timerB >= 90 && !currentGate.activeInHierarchy)
                {
                    //Set our first gate to be destroyed and progress to the next level
                    gateBdestroyed = true;
                }
            }
            //Once the SECOND Gate is detsroyed
            if (gateADetsroyed && gateBdestroyed && !gateCdestroyed)
            {
                //Set the scroll level and material
                scroll.level = BackgroundLevel.CASTLE;
                // Make our timer count up
                timerC += Time.deltaTime;
                //Once our timer reaches a certain point
                if (timerC >= 90)
                {
                    //Instantiate the current gate
                    currentGate = Instantiate(gateC, gateSpawn.position, gateSpawn.rotation);
                }
                //Once that is destroyed(making sure to reference the timer so it does not happen before the gate spawns)
                if (timerC >= 90 && !currentGate.activeInHierarchy)
                {
                    //Set our first gate to be destroyed and progress to the next level
                    gateCdestroyed = true;
                }
            }
        }
    }
}
