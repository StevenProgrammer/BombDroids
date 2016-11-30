using UnityEngine;
using System.Collections;




public class BrickBehaviour : MonoBehaviour {

    public Texture T_Taunt;
    public Texture T_Hit;
    public Texture T_Laugh;
    public Texture T_Miss;
    public Texture T_Taunt2;
    public Texture StartTaunt;
    public Texture B_Death;
    public Texture Normalbrick;

     float DeathTimer = 3f;
    public bool DeathTimerB = false;
    // Use this for initialization
    void Start () 
    {
        GetComponent<Renderer>().material.mainTexture = Normalbrick;
    }
	
	// Update is called once per frame
	void Update () 
    {

	//Hit();
    NotHit();
    TimeStuff();
    CheckForBrick();

	}

    void Hit()
    {
        if (GameVariables.IsHit)
        {
            GetComponent<Renderer>().material.mainTexture = T_Hit;
            GameVariables.hitSound = true;
            DeathTimerB = true;         
        }
        else
        {
            if (!GameVariables.IsHit)
            {
                GetComponent<Renderer>().material.mainTexture = Normalbrick;
                DeathTimerB = false;
                GameVariables.AddScore = false;
            }
        }
    }
    

    void NotHit()
    {
        if (GameVariables.IsMiss)
        {
            GetComponent<Renderer>().material.mainTexture = T_Miss;

        }
    }

    void TimeStuff()
    {
        if (DeathTimerB)
        {
            DeathTimer -= Time.deltaTime;

            if (DeathTimer <= 0)
            {
                GameVariables.BrickDead = true;
                Destroy(gameObject);
                Debug.Log("Brick is dead");
             
            }
            //check for brick in scene
            //if true 
            // addScore = true;

            
            if (DeathTimer == 0)
            {
                GameVariables.AddScore = true;
                Debug.Log("Add score");
            }
        }
    }

    void CheckForBrick()
    {
       // if (GameObject.FindWithTag("Brick") == null)
    }




    void OnCollisionEnter(Collision colli)
    {
        
        if(colli.gameObject.tag == "Ball")
        {
            GameVariables.IsHit = true;         
            GetComponent<Renderer>().material.mainTexture = T_Hit;

            if (GameVariables.IsHit)
            {
                DeathTimerB = true;
            }
        }
    }
    void OnCollisionExit(Collision colli)
    {

    }
}
