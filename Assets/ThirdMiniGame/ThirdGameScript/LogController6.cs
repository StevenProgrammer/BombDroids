using UnityEngine;
using System.Collections;

public class LogController6 : MonoBehaviour {


    public float Timer = .5f;

    public GameObject[] Logs6;

    // Update is called once per frame
    void Update()
    {
        TimeS();
        LogSpawner();
        // LogDirection();
    }

    void TimeS()
    {
        if (GameVariables.LogSpawn6 == false)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (GameVariables.LogSpawn6 == true)
            {
                Timer = 0.5f;
            }

        }
    }


    void LogSpawner()
    {


        if (Timer <= 0)
        {
            Instantiate(Logs6[Random.Range(0, Logs6.Length)], transform.position, transform.rotation);


            /*
            Instantiate(ls, transform.position + (transform.forward * 2), transform.rotation);
			*/

            GameVariables.LogSpawn6 = true;
        }
    }
}
