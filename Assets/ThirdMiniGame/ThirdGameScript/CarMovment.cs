using UnityEngine;
using System.Collections;

public class CarMovment : MonoBehaviour {


    public float MoveSpeed = 5f;
    public int CurrentPoint;

    public Transform[] CarMove1;


    // Use this for initialization
    void Start ()
    {
        transform.position = CarMove1[0].position;
        CurrentPoint = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position == CarMove1[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CarMove1[CurrentPoint].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint >= CarMove1.Length)
        {
            GameVariables.CarSpawn = false;
            Destroy(gameObject);
        }
    }
}
