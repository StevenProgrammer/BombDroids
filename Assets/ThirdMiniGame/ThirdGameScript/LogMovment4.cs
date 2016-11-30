using UnityEngine;
using System.Collections;

public class LogMovment4 : MonoBehaviour {


    public float MoveSpeed = 5f;
    public int CurrentPoint4;

    public Transform[] LogMove4;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove4[0].position;
        CurrentPoint4 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove4[CurrentPoint4].position)
        {
            CurrentPoint4++;
        }

        if (CurrentPoint4 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove4[CurrentPoint4].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint4 >= LogMove4.Length)
        {
            GameVariables.LogSpawn4 = false;
            Destroy(gameObject);
        }
    }


}
