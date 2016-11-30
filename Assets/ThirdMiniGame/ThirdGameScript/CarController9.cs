using UnityEngine;
using System.Collections;

public class CarController9 : MonoBehaviour {


    public float Timer = .5f;

    public GameObject[] Cars9;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeS();
        LogSpawner();
    }

    void TimeS()
    {
        if (GameVariables.CarSpawn9 == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.CarSpawn9 == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Cars9[Random.Range(0, Cars9.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.CarSpawn9 = true;
        }
    }
}
