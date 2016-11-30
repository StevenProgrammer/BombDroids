using UnityEngine;
using System.Collections;

public class CarMovment10 : MonoBehaviour {

    public float MoveSpeed = 5;
    public int CurrentPoint;

    public Transform[] CarMove10;

    // Use this for initialization
    void Start()
    {

        transform.position = CarMove10[0].position;
        CurrentPoint = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == CarMove10[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CarMove10[CurrentPoint].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint >= CarMove10.Length)
        {
            GameVariables.CarSpawn10 = false;
            Destroy(gameObject);
        }
    }
}
