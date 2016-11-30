using UnityEngine;
using System.Collections;

public class LogMovment : MonoBehaviour {

    public float MoveSpeed;
    public int CurrentPoint;

    public Transform[] LogMove;
    

    // Use this for initialization
    void Start ()
    {
        transform.position = LogMove[0].position;
        CurrentPoint = 0;
       
    }
	
	// Update is called once per frame
	void Update ()
    {
	        if(transform.position == LogMove[CurrentPoint].position)
        {
            CurrentPoint ++ ;
        }

        if (CurrentPoint == 1) {
            transform.position = Vector3.MoveTowards(transform.position, LogMove[CurrentPoint].position, MoveSpeed * Time.deltaTime);
              }

        //if log gets to other side destry object


        //when the logs destroy themselves set GameVariables.LogSpawn = false;

        if (CurrentPoint >= LogMove.Length)
        {
            GameVariables.LogSpawn = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider colli)
    {
        if(colli.gameObject.tag == "DeadZone")
        {
            Debug.Log("d");
        }
    }



    

}
