using UnityEngine;
using System.Collections;

public class LogMovment9 : MonoBehaviour {

    public float MoveSpeed = 5f;
    public int CurrentPoint9;

    public Transform[] LogMove9;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove9[0].position;
        CurrentPoint9 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove9[CurrentPoint9].position)
        {
            CurrentPoint9++;
        }

        if (CurrentPoint9 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove9[CurrentPoint9].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint9 >= LogMove9.Length)
        {
            GameVariables.LogSpawn9 = false;
            Destroy(gameObject);
        }
    }
}
