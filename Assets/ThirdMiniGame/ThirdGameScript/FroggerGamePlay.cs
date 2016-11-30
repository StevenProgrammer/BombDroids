using UnityEngine;
using System.Collections;

//things this script will do
// // // // // // // // // // //

//control the movements of the Player
//
//when the inputs are used will move a fixed amount in the direction pressed


// if the player enters the triggers that kill he will die
// when the player dies he will lose a life

//when the end is reached the level will end;




public class FroggerGamePlay : MonoBehaviour {


	/*
	public float FrogSpeed = 1f;

	public float playerSpeed = 5.0f;
	*/

	//private Vector3 X_Position = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start () 
	{
		GameVariables.IsAlive = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(GameVariables.IsAlive == true)
		{
			//calls on the movement function
		Movement();

			//calls on the death function
		Death();

		}

	}

	void Movement()
	{



		#region True Movement
            
        // true Vertical Movment
		if(Input.GetKeyDown(KeyCode.W))
		{
			//if w is pressed the character will move a fixed amount of space up
			//transform.Translate moves the gameobject using x,y,z and
			//transform.rotate rotates the gameobject on x,y,z
			//transform.Translate(Vector3.up * 50 * Time.deltaTime);
			transform.Translate(Vector3.forward * 50 * Time.deltaTime);



		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			//if S is pressed the character will move a fixed amount of space Down
			//transform.Translate(Vector3.up * -50 * Time.deltaTime);
			transform.Translate(Vector3.forward * -50 * Time.deltaTime);
		}


		// need to set some rules later for turning
	
	

		// True Horizontal Movment
		if(Input.GetKeyDown(KeyCode.A))
		{
			//if A is pressed the character will move a fixed amount of space Left
			transform.Translate(Vector3.left * 50 * Time.deltaTime);

			//turns left
			//transform.Rotate(new Vector3(0,0,90));

		}

		if(Input.GetKeyDown(KeyCode.D))
		{
			//if D is pressed the character will move a fixed amount of space Right
			transform.Translate(Vector3.right * 50 * Time.deltaTime);



			//turns right
			//transform.Rotate(new Vector3(0,0,-90));
		}

		#endregion
	}

	void Death()
	{
        //function for actions to do on player death
        if(GameVariables.IsAlive == false)
        {
            Debug.Log("f");
        }

        
    }


	void TriggerEnter(Collider colli)
	{



		//if player collides with water or cars 
		if(colli.gameObject.tag == "Car")
		{
			Death();
            GameVariables.IsAlive = false;
            
        }

        if (colli.gameObject.tag == "LilyPad")
        {
            GameVariables.Game3IsWin = true;
            Debug.Log("Lilly is true");

        }


    }

	void OnCollisionEnter(Collision Colli)
	{
		if(Colli.gameObject.tag == "Water")
		{
			Debug.Log("Water is collide");
            GameVariables.IsAlive = false;
			Destroy(gameObject);
		}

		if(Colli.gameObject.tag == "Road")
		{
			Debug.Log("Road is collide");
		}

		if(Colli.gameObject.tag == "Grass")
		{
			Debug.Log("Grass is collide");
		}

        if (Colli.gameObject.tag == "Car")
        {

            Destroy(gameObject);
        }

        if (Colli.gameObject.tag == "LilyPad")
        {
            GameVariables.Game3IsWin = true;
            Debug.Log("Lillyc is true");

        }




    }


}
