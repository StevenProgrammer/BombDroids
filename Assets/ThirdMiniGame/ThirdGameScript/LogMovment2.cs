using UnityEngine;
using System.Collections;

public class LogMovment2 : MonoBehaviour {

    public float MoveSpeed = 5f;
    public int CurrentPoint2;

    public Transform[] LogMove2;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove2[0].position;
        CurrentPoint2 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove2[CurrentPoint2].position)
        {
            CurrentPoint2 ++;
        }

        if (CurrentPoint2 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove2[CurrentPoint2].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint2 >= LogMove2.Length)
        {
            GameVariables.LogSpawn2 = false;
            Destroy(gameObject);
        }
    }


}
