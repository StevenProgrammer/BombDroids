using UnityEngine;
using System.Collections;

public class LogController5 : MonoBehaviour {


    public float Timer = .5f;

    public GameObject[] Logs5;

    // Update is called once per frame
    void Update()
    {
        TimeS();
        LogSpawner();
        // LogDirection();
    }

    void TimeS()
    {
        if (GameVariables.LogSpawn5 == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.LogSpawn5 == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Logs5[Random.Range(0, Logs5.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.LogSpawn5 = true;
        }
    }
}
