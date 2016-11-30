using UnityEngine;
using System.Collections;

public class LogMovment8 : MonoBehaviour {


    public float MoveSpeed = 5f;
    public int CurrentPoint8;

    public Transform[] LogMove8;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove8[0].position;
        CurrentPoint8 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove8[CurrentPoint8].position)
        {
            CurrentPoint8++;
        }

        if (CurrentPoint8 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove8[CurrentPoint8].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint8 >= LogMove8.Length)
        {
            GameVariables.LogSpawn8 = false;
            Destroy(gameObject);
        }
    }
}
