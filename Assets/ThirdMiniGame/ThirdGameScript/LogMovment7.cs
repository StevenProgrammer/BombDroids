using UnityEngine;
using System.Collections;

public class LogMovment7 : MonoBehaviour {


    public float MoveSpeed = 5f;
    public int CurrentPoint7;

    public Transform[] LogMove7;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove7[0].position;
        CurrentPoint7 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove7[CurrentPoint7].position)
        {
            CurrentPoint7++;
        }

        if (CurrentPoint7 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove7[CurrentPoint7].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint7 >= LogMove7.Length)
        {
            GameVariables.LogSpawn7 = false;
            Destroy(gameObject);
        }
    }
}
