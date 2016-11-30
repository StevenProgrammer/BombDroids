using UnityEngine;
using System.Collections;

public class CarMovment3 : MonoBehaviour {

    public float MoveSpeed = 5;
    public int CurrentPoint;

    public Transform[] CarMove3;

    // Use this for initialization
    void Start () {

        transform.position = CarMove3[0].position;
        CurrentPoint = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == CarMove3[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CarMove3[CurrentPoint].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint >= CarMove3.Length)
        {
            GameVariables.CarSpawn3 = false;
            Destroy(gameObject);
        }
    }
}
