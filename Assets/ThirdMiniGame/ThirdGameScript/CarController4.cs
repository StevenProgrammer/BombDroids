using UnityEngine;
using System.Collections;

public class CarController4 : MonoBehaviour {


    public float Timer = .5f;

    public GameObject[] Cars4;

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
        if (GameVariables.CarSpawn4 == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.CarSpawn4 == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Cars4[Random.Range(0, Cars4.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.CarSpawn4 = true;
        }
    }
}
