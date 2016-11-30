using UnityEngine;
using System.Collections;



public class UnitPlayer : Unit {

   // protected PowerUpRangeOnExplosion PowerUpR;

    public AudioSource FootSteps;

    public AudioSource bombsound;

     float cameraRotX = 0f;

    public float cameraPitchMax = 45f;


	// Use this for initialization
	public override void Start ()
    {
        base.Start ();
        /*
        GetComponent<PowerUpRangeOnExplosion>().enabled = false;
        GetComponent<PowerUpGetBomb>().enabled = false;
        */

        

    }
	
	// Update is called once per frame
	public override void Update ()

    {

        Cursor.visible = false;

        SecretRooms();
        // rotation

        transform.Rotate(0f, Input.GetAxis ("Mouse X") * TurnSpeed * Time.deltaTime,0f);

        cameraRotX -= Input.GetAxis ("Mouse Y");

        cameraRotX = Mathf.Clamp(cameraRotX, -cameraPitchMax, cameraPitchMax);

       Camera.main.transform.forward = transform.forward;
       Camera.main.transform.Rotate (cameraRotX, 0f, 0f);

        //movement 

        move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        move.Normalize();

        move = transform.TransformDirection(move);

        if (Input.GetKeyDown(KeyCode.Space) && control.isGrounded)
        {
            jump = true;
        }

        running = Input.GetKey(KeyCode.LeftShift);

        if (GameVariables.RangeAddUp == true)
        {
            print("RangeAddUp == true");
        }
 

        base.Update();




        #region GameVariables.HaveBomb == false



        if (GameVariables.HaveBomb == false)
        {
            //GetComponent<SpawnAtMe>().enabled = true;

            //print("I AM DA BANANA KING");
        }
        #endregion 



        #region GameVariables.BombArmed == true



        if (GameVariables.BombArmed == true)
        {
           

            print("I AM ALIVE AND I DO BELIEVE THAT DAMIEN NEEDS JESUS");
        }
        #endregion 


        #region GameVariables.HaveBomb == true



        if (GameVariables.HaveBomb == true)
        {
           // GetComponent<SpawnAtMe>().enabled = false;
            bombsound.Play();

            //print("WOOT WOOP");
        }
        #endregion 


    }

    //this function only applies if the player played the minigames and got the keys
    void SecretRooms()
    {
        //these three if statments require the player to have played the minigames and won all 3

        if (GameVariables.KeyBrickBreak == true)
        {
            //this funtion needs the brick break minigame to have been played and won
            
        }

        if(GameVariables.KeySlidePuzzle == true)
        {
            //this funtion needs the Slider Puzzle minigame to have been played and won
        }

        if (GameVariables.Game3Key == true)
        {
            //this funtion needs the Third minigame to have been played and won
        }

    }


    void OnCollisionEnter(Collision Colli)
    {
        if (GameVariables.KeyBrickBreak == true)
        {
            //this funtion needs the brick break minigame to have been played and won

            if(Colli.gameObject.tag == "")
            {

            }
        }

        if (GameVariables.KeySlidePuzzle == true)
        {
            //this funtion needs the Slider Puzzle minigame to have been played and won

            if (Colli.gameObject.tag == "")
            {

            }
        }

        if (GameVariables.Game3Key == true)
        {
            //this funtion needs the Third minigame to have been played and won

            if (Colli.gameObject.tag == "")
            {

            }
        }


    }
	/*

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "paul1")
        {
            Debug.Log("Please Die");
            Application.LoadLevel("Game_Over");
        }
*/
       
        
        /*
        if(collision.gameObject.tag == "PickUpRange")
        {
            print("range+ has been picked up and now you gain a component");

            GameVariables.RangeAddUp = true;


        }
*/
/*

        if (collision.gameObject.tag == "PickUpBombs")
        {
            print("Bomb+ has been picked up and now you gain a component");
            GameVariables.BombCount++;
        }
*/

/*
        if (collision.gameObject.tag == "BombtempOff")
        {
            print("You cant spawn bombs till timer runs out");
           // GetComponent<SpawnAtMe>().enabled = false;

        }
*/
/*
        if (collision.gameObject.tag == "BombPowerUp")
        {
            //GetComponent<PowerUpGetBomb>().enabled = true;

        }
*/


    //}


    

}
