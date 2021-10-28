using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject[] Candy; // an array of our candy types
    public Transform[] Spawners; // an array of all the possible spawn locations

    public float Timer; // timer variables to help us keep track of when to spawn
    public float SpawnCandy = 5f;

    public float oldScore; // variable that keeps track of when to increase difficulty

    // Update is called once per frame
    void Update()
    {
        if (Timer >= SpawnCandy) // when our timer hits the spawn time, randomize both candy and location then spawn and reset timer to 0
        {
            int pickSpawn = Random.Range(0, Spawners.Length);
            int pickCandy = Random.Range(0, Candy.Length);

            Instantiate(Candy[pickCandy], Spawners[pickSpawn].position, Quaternion.identity);

            Timer = 0;
        }
        Timer += Time.deltaTime;

        if(FindObjectOfType<BagMovement>().score >= oldScore + 10 && SpawnCandy > 0.5) // every 10 points set the oldscore to the last score (or +10) and make the spawn time a little faster
        {
            oldScore += 10;
            SpawnCandy -= 0.5f;
        }
    }
}
