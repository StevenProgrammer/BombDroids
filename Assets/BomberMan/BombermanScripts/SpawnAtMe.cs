using UnityEngine;
using System.Collections;

public class SpawnAtMe : MonoBehaviour
{
    #region Public Variables
    public AudioSource SpawnItemSound;
    public float Timer = 5;
    GameObject Bomb;

    public int BombsList = 0;
    #endregion

    // Use this for initialization
    void Start()
    {
        Bomb = Resources.Load("Bombo") as GameObject;
    }
    // Update is called once per frame
    void Update()
    {
        PickupPowerUp();
        BaseAction();
        Base();
        
    }

        void PickupPowerUp()
    {
        if (GameVariables.BombAdd1 == true)
        {
            PowerUpMoreBombs();
        }
    }

    void PowerUpMoreBombs()
    {

    }


    void Base()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {

            //if press o have bomb is true
            GameVariables.HaveBomb = true;



            //if have bomb is true
            //start a timer
            //and plant a bomb
            if (GameVariables.HaveBomb == true)
            {
                Instantiate(Bomb, transform.position + (transform.forward * 2), transform.rotation);
                print("Banana Has Been Split");
                Timer -= Time.deltaTime;
                GameVariables.PlaceBomb = true;
            }
            else
            {

                if (GameVariables.PlaceBomb == true)
                {
                    print("bomb stop");
                }
            }

            /*
            //if timer is 0 let us plant a second bomb
            if(Timer <= 0 && GameVariables.HaveBomb == true)
            {
               
            }
            */
            



        }
    }


    

    void BaseAction()
    {

        /*
        if (Input.GetKeyDown(KeyCode.O))
        {

            GameVariables.HaveBomb = true;
            BombsList++;

            // Instantiate(Banana, transform.position + 50 * (transform.forward / 90), transform.rotation);
            Instantiate(Bomb, transform.position + (transform.forward * 2), transform.rotation);
            print("Banana Has Been Split");
                //when bomb is spawned a timer will play
            Timer -= Time.deltaTime;

        }

        //
        if (GameVariables.HaveBomb == true && BombsList <= 1 && Timer > 0)
        {
            GetComponent<SpawnAtMe>().enabled = false;

        }
        else
        {
            //
            if (GameVariables.HaveBomb == true && GameVariables.BombAdd1 == true && GameVariables.BombCount <= 2 && Timer <= 0)
            {
                GetComponent<SpawnAtMe>().enabled = true;
            }
        }
        */
    }



}


