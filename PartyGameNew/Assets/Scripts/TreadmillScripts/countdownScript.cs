using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownScript : MonoBehaviour
{
    //Types of treadmills
    private GameObject[] treadmillFoward;

    private GameObject[] treadmillBackward;



    //Types of materials
    public Material materialF;
    public Material materialB;

    //Timer for switching directions
    public float currentTime = 0;
    public float startingTime = Random.Range(0.5f,7f);

    public Text countdown;

    //Spawner System
    public GameObject[] spawners;

    //Spawnable objects
    public GameObject[] spawnableObject;

    //Chosen spawner and object
    GameObject chosenSpawner;
    GameObject chosenObject;

    //Spawner index
    int spawnerIndex;
    

    public int rotationNum = 0;



    // Start is called before the first frame update
    void Start()
    {
        //Set current time to starting time
        currentTime = startingTime;

        //Get a random spawner
        spawnerIndex = Random.Range(0, spawners.Length);
        chosenSpawner = spawners[spawnerIndex];

        //Get random Object
        chosenObject = spawnableObject[Random.Range(0, spawnableObject.Length)];


    }

    // Update is called once per frame
    void Update()
    {
        //Count down by 1 second
        currentTime -= 1 * Time.deltaTime;
        countdown.text = "Countdown until switch: " + currentTime.ToString("0");

        //Once it hits 0
        if (currentTime <= 0)
        {
            //Increase number of round
            rotationNum++;
            Debug.Log(rotationNum);

            //Once rounds hit 5, start spawning objects
            if(rotationNum >= 5)
            {
                Instantiate(chosenObject, chosenSpawner.transform.position,chosenSpawner.transform.rotation);
                spawnerIndex = Random.Range(0, spawners.Length);
                chosenSpawner = spawners[spawnerIndex];
            }

            //Set time back
            currentTime = Random.Range(0.5f, 7f);

            //find every treadmill
            treadmillFoward = GameObject.FindGameObjectsWithTag("Treadmill");
            treadmillBackward = GameObject.FindGameObjectsWithTag("TreadmillB");

            //Switch tags
            foreach(GameObject item in treadmillFoward)
            {
                item.gameObject.tag = "TreadmillB";
                item.gameObject.GetComponent<MeshRenderer>().material = materialB;
            }
            foreach (GameObject item in treadmillBackward)
            {
                item.gameObject.tag = "Treadmill";
                item.gameObject.GetComponent<MeshRenderer>().material = materialF;
            }

        }
    }

}
