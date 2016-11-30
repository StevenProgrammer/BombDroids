using UnityEngine;
using System.Collections;

public class LogController8 : MonoBehaviour {



    public float Timer = .5f;

    public GameObject[] Logs8;

    // Update is called once per frame
    void Update()
    {
        TimeS();
        LogSpawner();
        // LogDirection();
    }

    void TimeS()
    {
        if (GameVariables.LogSpawn8 == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.LogSpawn8 == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Logs8[Random.Range(0, Logs8.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.LogSpawn8 = true;
        }
    }
}
