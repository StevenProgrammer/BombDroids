using UnityEngine;
using System.Collections;

public class CarController5 : MonoBehaviour {


    public float Timer = .5f;

    public GameObject[] Cars5;

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
        if (GameVariables.CarSpawn5 == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.CarSpawn5 == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Cars5[Random.Range(0, Cars5.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.CarSpawn5 = true;
        }
    }
}
