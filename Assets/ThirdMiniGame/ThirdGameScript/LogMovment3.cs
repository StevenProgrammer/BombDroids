using UnityEngine;
using System.Collections;

public class LogMovment3 : MonoBehaviour {

    public float MoveSpeed = 5f;
    public int CurrentPoint3;

    public Transform[] LogMove3;


    // Use this for initialization
    void Start()
    {
        transform.position = LogMove3[0].position;
        CurrentPoint3 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == LogMove3[CurrentPoint3].position)
        {
            CurrentPoint3++;
        }

        if (CurrentPoint3 == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LogMove3[CurrentPoint3].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint3 >= LogMove3.Length)
        {
            GameVariables.LogSpawn3 = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider colli)
    {
        if (colli.gameObject.tag == "DeadZone")
        {
            Debug.Log("d");
        }
    }
}
