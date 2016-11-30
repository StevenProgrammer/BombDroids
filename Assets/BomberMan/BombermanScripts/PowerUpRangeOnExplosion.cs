using UnityEngine;
using System.Collections;

//what i want to do is when the player picks this item up to change how many explosions the bombs he spawns have
// for now ill test this with getcomponent enabling to turn the explosion on and off.



public class PowerUpRangeOnExplosion : MonoBehaviour {

    public GameObject PowerUpTargetPlayer;


    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        /*
	        if(PowerUpTargetPlayer.GetComponent<PowerUpRangeOnExplosion>().enabled == true)
        {
            // PowerUpTargetPlayer.GetComponent<BombSelfAction>().enabled = false;
                PowerUpTargetPlayer.GetComponent<SpawnAtMe>().enabled = false;

        }
        else
        {
            if (PowerUpTargetPlayer.GetComponent<PowerUpRangeOnExplosion>().enabled == false)
            {

            }
        }
    */

	}

   void OnTriggerEnter(Collider Colli)
    {
        if(Colli.gameObject.tag == "Player")
        {
            print("Player has picked up the Explosion powerup");
           PowerUpTargetPlayer.GetComponent<PowerUpRangeOnExplosion>().enabled = true;


        }

        
    }


}
