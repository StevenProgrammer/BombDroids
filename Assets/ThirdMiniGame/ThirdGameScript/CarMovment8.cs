using UnityEngine;
using System.Collections;

public class CarMovment8 : MonoBehaviour {

    public float MoveSpeed = 5;
    public int CurrentPoint;

    public Transform[] CarMove8;

    // Use this for initialization
    void Start()
    {

        transform.position = CarMove8[0].position;
        CurrentPoint = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == CarMove8[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CarMove8[CurrentPoint].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint >= CarMove8.Length)
        {
            GameVariables.CarSpawn8 = false;
            Destroy(gameObject);
        }
    }
}
