using UnityEngine;
using System.Collections;

public class CarMovment4 : MonoBehaviour {

    public float MoveSpeed = 5;
    public int CurrentPoint;

    public Transform[] CarMove4;


    // Use this for initialization
    void Start () {

        transform.position = CarMove4[0].position;
        CurrentPoint = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == CarMove4[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CarMove4[CurrentPoint].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint >= CarMove4.Length)
        {
            GameVariables.CarSpawn4 = false;
            Destroy(gameObject);
        }
    }
}
