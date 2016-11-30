using UnityEngine;
using System.Collections;

//what this script will do

//have a timer

//set up a few differnt car gameobjects

//use random to  determine which car classes it is using

//instantiate several differnt cars based on that random

//have the cars spawn at random times



public class CarController : MonoBehaviour {

    public float Timer = .5f;

    public GameObject[] Cars1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeS();
        LogSpawner();
    }

    void TimeS()
    {
        if (GameVariables.CarSpawn == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.CarSpawn == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Cars1[Random.Range(0, Cars1.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.CarSpawn = true;
        }
    }
}
