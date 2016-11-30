using UnityEngine;
using System.Collections;

public class CarController2 : MonoBehaviour

{

    public float Timer = .5f;

    public GameObject[] Cars2;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        TimeS();
        LogSpawner();
    }

    void TimeS()
    {
        if (GameVariables.CarSpawn2 == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.CarSpawn2 == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Cars2[Random.Range(0, Cars2.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.CarSpawn2 = true;
        }
    }
}
