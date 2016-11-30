using UnityEngine;
using System.Collections;

public class LogMovment5 : MonoBehaviour
{


    public float MoveSpeed = 5f;
    public int CurrentPoint5;

    public Transform[] LogMove5;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove5[0].position;
        CurrentPoint5 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove5[CurrentPoint5].position)
        {
            CurrentPoint5++;
        }

        if (CurrentPoint5 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove5[CurrentPoint5].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint5 >= LogMove5.Length)
        {
            GameVariables.LogSpawn5 = false;
            Destroy(gameObject);
        }
    }
}

