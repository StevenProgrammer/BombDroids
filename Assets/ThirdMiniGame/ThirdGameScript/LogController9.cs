using UnityEngine;
using System.Collections;

public class LogController9 : MonoBehaviour {



    public float Timer = .5f;

    public GameObject[] Logs9;

    // Update is called once per frame
    void Update()
    {
        TimeS();
        LogSpawner();
        // LogDirection();
    }

    void TimeS()
    {
        if (GameVariables.LogSpawn9 == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.LogSpawn9 == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Logs9[Random.Range(0, Logs9.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.LogSpawn9 = true;
        }
    }
}
