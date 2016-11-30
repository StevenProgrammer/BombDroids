using UnityEngine;
using System.Collections;

//what this script will do

//have a timer

//set up a few differnt log gameobjects

//use random to  determine which log gameobject it is using

//instantiate several differnt logs based on that random

//have the logs spawn at random times

// determine which direction the logs will go with random.range


public class LogController : MonoBehaviour {

    public float Timer = .5f;

	public GameObject [] Logs;

	// Update is called once per frame
	void Update ()
    {
        TimeS();
        LogSpawner();
       // LogDirection();
	}

    void TimeS()
    {
        if(GameVariables.LogSpawn == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if(GameVariables.LogSpawn == true)
            {
                Timer = 0.5f;
            }
           
        }
    }


    void LogSpawner()
    {

        
        if (Timer <= 0)
        {
			 Instantiate(Logs[Random.Range(0,Logs.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.LogSpawn = true;
        }
    } 
}
