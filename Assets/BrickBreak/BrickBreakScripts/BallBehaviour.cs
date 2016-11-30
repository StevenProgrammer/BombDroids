using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {

    public Texture BallNormal;
    public Texture BallFailed;
    public Texture BallHit;

    public float ballInitialVelocity = 800f;
    private Rigidbody rb;
    private bool BallInPlay;

    bool hitBrick = false;

    


	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.mainTexture = BallNormal;
	}

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        BallBehavior();
        WallStuff();
        CheckForBall();
        BallHitBrick();
        BallDeath();

	}

    void BallBehavior()
    {
        if (Input.GetButtonDown("Fire1") && BallInPlay == false)
        {
            transform.parent = null;
            BallInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));

            GameVariables.BrickBreakStart = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && BallInPlay == false)
        {
            transform.parent = null;
            BallInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));

            GameVariables.BrickBreakStart = true;
        }
        


        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            rb.useGravity = true;
        }

        if (Input.GetKeyUp(KeyCode.Q)) 
        {
            rb.useGravity = false;
        }
    }

    void WallStuff() 
    {
        if(GameVariables.WallHitStuck == true)
        {
            //if the corner points are hit by the ball 
            //then the corners will push the ball out
            //rb.AddForce
        }
    }


    void BallHitBrick() 
    {
        if (hitBrick == true) 
        {
            // increase velocity when the ball hits bricks 


        }
    }

    void CheckForBall() 
    {
        if (GameObject.FindWithTag("Ball") == null)
        {
            Debug.Log("Ball is Dead and You lose");
        }
    }



    void OnCollisionEnter(Collision colli) 
    {
        if (colli.gameObject.tag == "WallCorner") 
        {

            /*
            GameVariables.WallHitStuck = true;
            Debug.Log("I May Be Stuck");
                        */
        }

        if (colli.gameObject.tag == "Brick") 
        {
            hitBrick = true;
        }
    }


    void OnTriggerEnter(Collider colli) 
    {
        if (colli.gameObject.tag == "DeadZone") 
        {
            GameVariables.YouLose = true;
        }
    }

    void BallDeath()
    {
        if (GameVariables.YouLose == true)
        {
            Destroy(gameObject);
            Debug.Log("Ball has died");
        }
    }






}
