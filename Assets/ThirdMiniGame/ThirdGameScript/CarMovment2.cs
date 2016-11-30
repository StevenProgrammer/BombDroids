using UnityEngine;
using System.Collections;

public class CarMovment2 : MonoBehaviour {

    public float MoveSpeed = 5f;
    public int CurrentPoint;

    public Transform[] CarMove2;

    // Use this for initialization
    void Start ()
    {
        transform.position = CarMove2[0].position;
        CurrentPoint = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position == CarMove2[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        if (CurrentPoint == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CarMove2[CurrentPoint].position, MoveSpeed * Time.deltaTime);
        }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint >= CarMove2.Length)
        {
            GameVariables.CarSpawn2 = false;
            Destroy(gameObject);
        }
    }
}

