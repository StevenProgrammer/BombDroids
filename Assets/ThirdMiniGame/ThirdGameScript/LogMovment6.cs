using UnityEngine;
using System.Collections;

public class LogMovment6 : MonoBehaviour {



    public float MoveSpeed = 5f;
    public int CurrentPoint6;

    public Transform[] LogMove6;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove6[0].position;
        CurrentPoint6 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove6[CurrentPoint6].position)
        {
            CurrentPoint6++;
        }

        if (CurrentPoint6 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove6[CurrentPoint6].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint6 >= LogMove6.Length)
        {
            GameVariables.LogSpawn6 = false;
            Destroy(gameObject);
        }
    }
}
