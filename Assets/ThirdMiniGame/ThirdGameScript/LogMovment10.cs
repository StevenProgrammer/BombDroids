using UnityEngine;
using System.Collections;

public class LogMovment10 : MonoBehaviour {


    public float MoveSpeed = 5f;
    public int CurrentPoint10;

    public Transform[] LogMove10;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove10[0].position;
        CurrentPoint10 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove10[CurrentPoint10].position)
        {
            CurrentPoint10++;
        }

        if (CurrentPoint10 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove10[CurrentPoint10].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint10 >= LogMove10.Length)
        {
            GameVariables.LogSpawn10 = false;
            Destroy(gameObject);
        }
    }
}
