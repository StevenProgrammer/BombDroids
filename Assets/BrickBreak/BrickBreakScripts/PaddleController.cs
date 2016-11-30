using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PaddleController : MonoBehaviour {


    public Texture PaddleNormal;
    public Texture PaddleMiss;
    public Texture PaddleHit;



   


    public float paddleSpeed = 1f;

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    

	// Use this for initialization
	void Start () {

        GetComponent<Renderer>().material.mainTexture = PaddleNormal;
	
	}
	
	// Update is called once per frame
	void Update () {
        PaddleMovement();
        PMiss();
        PInput();
	
	}

    void PaddleMovement()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        //mathf.clamp limits a number between 3 peramaters 
        //value clamped, minimum, maximum.

        //this clamp limits how far the paddle can move along x axis
        //game max and min for x are -27 and 36

        // playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);

        playerPos = new Vector3(Mathf.Clamp(xPos, -9.55f, 11.66f), -9.5f, 0f);

        transform.position = playerPos;



    }


    void PInput()
    {
        if (Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.W))
        {
            //want to rotate the paddle slightly up
            //or
            //raise the paddle up for a few seconds

            //transform.eulerAngles = PlayerRot;

            transform.Rotate(new Vector3(20, 0, 0));

        }

        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.W)) 
        {
            //when the key is released return to where the paddle was

            transform.Rotate(new Vector3(-20, 0, 0));

        }

        if (Input.GetKeyDown(KeyCode.R)|| Input.GetKeyDown(KeyCode.S)) 
        {
            transform.Rotate(new Vector3(-20, 0, 0));
        }

        if (Input.GetKeyUp(KeyCode.R)|| Input.GetKeyUp(KeyCode.S)) 
        {
            transform.Rotate(new Vector3(20, 0, 0));
        }




    }



    void PMiss()
    {

    }

    void OnCollisionEnter(Collision colli)
    {
        if (colli.gameObject.tag == "ball")
        {
            GetComponent<Renderer>().material.mainTexture = PaddleHit;
        }
    }

    void OnCollisionExit(Collision colli)
    {
        GetComponent<Renderer>().material.mainTexture = PaddleNormal;

    }



}
