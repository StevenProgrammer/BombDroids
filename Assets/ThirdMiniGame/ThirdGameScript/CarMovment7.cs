using UnityEngine;
using System.Collections;

public class CarMovment7 : MonoBehaviour {

    public float MoveSpeed = 5;
    public int CurrentPoint;

    public Transform[] CarMove7;

    // Use this for initialization
    void Start()
    {

        transform.position = CarMove7[0].position;
        CurrentPoint = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == CarMove7[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CarMove7[CurrentPoint].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint >= CarMove7.Length)
        {
            GameVariables.CarSpawn7 = false;
            Destroy(gameObject);
        }
    }
}
