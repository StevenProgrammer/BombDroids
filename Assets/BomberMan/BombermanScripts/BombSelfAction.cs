using UnityEngine;
using System.Collections;

// Paul = The GameObject!!!!!!!!!!!!!!
//----------------------------------------------------------------------------------------------------------------------------------


public class BombSelfAction : MonoBehaviour
{

    public float Timer = 5;

    public AudioSource BombSound;



    Vector3 tempPos;

    Rigidbody rb;
    //Vector3 velocity;

    #region Public Variables for all the Empties
    //range 1 for bomb
    public GameObject Left1;
    public GameObject Right1;
    public GameObject North1;
    public GameObject South1;

    //range 2 for bomb
    public GameObject Left2;
    public GameObject Right2;
    public GameObject North2;
    public GameObject South2;

    //range 3 for bomb

    public GameObject Left3;
    public GameObject Right3;
    public GameObject North3;
    public GameObject South3;

    //range 4 for bomb

    public GameObject Left4;
    public GameObject Right4;
    public GameObject North4;
    public GameObject South4;

    //range 5 for bomb

    public GameObject Left5;
    public GameObject Right5;
    public GameObject North5;
    public GameObject South5;

    //range 6 for bomb

    public GameObject Left6;
    public GameObject Right6;
    public GameObject North6;
    public GameObject South6;

    //range 7 for bomb

    public GameObject Left7;
    public GameObject Right7;
    public GameObject North7;
    public GameObject South7;

    //range 8 for bomb

    public GameObject Left8;
    public GameObject Right8;
    public GameObject North8;
    public GameObject South8;

    //range 9 for bomb

    public GameObject Left9;
    public GameObject Right9;
    public GameObject North9;
    public GameObject South9;

    //range 10 for bomb

    public GameObject Left10;
    public GameObject Right10;
    public GameObject North10;
    public GameObject South10;

    #endregion

    //bool spawned = false;


    // Use this for initialization
    void Start()
    {
        tempPos = transform.position;
        rb = GetComponent<Rigidbody>();
       gameObject.GetComponent<BombSelfAction>().enabled = true;

        /*
        Timer -= Time.deltaTime;
        //GameVariables.BombArmed = false;
        Debug.Log("Timer is working");
        */

        
      
        


    }

    // Update is called once per frame
    void Update()
    {


        //if 

        /*
        if (gameObject.GetComponent<BombSelfAction>().enabled == true)
        {
            Timer -= Time.deltaTime;
            // GameVariables.BombArmed = false;
            //Debug.Log("Timer is working");
        }

        */
        TimerActions();

        InstantiateBombRow1();
    

        PickupPowerUp();


    }


    /*
        InstantiateBombRow2();
        InstantiateBombRow3();
        InstantiateBombRow4();
        InstantiateBombRow5();
        InstantiateBombRow6();
        InstantiateBombRow7();
        InstantiateBombRow8();
        InstantiateBombRow9();
        InstantiateBombRow10();
    */


    void TimerActions()
    {
        if(GameVariables.PlaceBomb == true)
        {
            Timer -= Time.deltaTime;
        }


        if (Timer <= 0)
        {
            GameVariables.BombArmed = true;
			GameVariables.HaveBomb = false;
        }

    }





    void InstantiateBombRow1()
    {


                if (GameVariables.BombArmed == true)
                {
                    #region instance the first row
                    // left1
                    GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
                    GameObject ExplosionTriggerLeft1 = Instantiate(ExplosionTriggerRef, Left1.transform.position, Quaternion.identity) as GameObject;
                    GameObject ExplosionTriggerRight1 = Instantiate(ExplosionTriggerRef, Right1.transform.position, Quaternion.identity) as GameObject;
                    GameObject ExplosionTriggerNorth1 = Instantiate(ExplosionTriggerRef, North1.transform.position, Quaternion.identity) as GameObject;
                    GameObject ExplosionTriggerSouth1 = Instantiate(ExplosionTriggerRef, South1.transform.position, Quaternion.identity) as GameObject;

                    GameObject explode = Resources.Load("Explosion") as GameObject;
                    GameObject ExplosionLeft1 = Instantiate(explode, Left1.transform.position, Quaternion.identity) as GameObject;
                    GameObject ExplosionRight1 = Instantiate(explode, Right1.transform.position, Quaternion.identity) as GameObject;
                    GameObject ExplosionNorth1 = Instantiate(explode, North1.transform.position, Quaternion.identity) as GameObject;
                    GameObject ExplosionSouth1 = Instantiate(explode, South1.transform.position, Quaternion.identity) as GameObject;

                    GameVariables.HahahahaIWillWin = true;



            #endregion

                 
                    #region Destroy Instance



                    Destroy(ExplosionLeft1, 3);
                    Destroy(gameObject);




                    Destroy(ExplosionTriggerRight1, 1);
                    Destroy(gameObject);

                    Destroy(ExplosionTriggerLeft1, 1);
                    Destroy(gameObject);

                    Destroy(ExplosionTriggerNorth1, 1);
                    Destroy(gameObject);

                    Destroy(ExplosionTriggerSouth1, 1);
                    Destroy(gameObject);

            GameVariables.BombArmed = false;

            #endregion



            //GameVariables.HaveBomb = false;
        }

      

    }



    void InstantiateBombRow2()
     {
            #region Instance the second row

            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft2 = Instantiate(ExplosionTriggerRef, Left2.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight2 = Instantiate(ExplosionTriggerRef, Right2.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth2 = Instantiate(ExplosionTriggerRef, North2.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth2 = Instantiate(ExplosionTriggerRef, South2.transform.position, Quaternion.identity) as GameObject;



            #endregion

            #region Destroy the Second row instance

            Destroy(ExplosionTriggerRight2, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft2, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth2, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth2, 1);
            Destroy(gameObject);

            #endregion
        }

        void InstantiateBombRow3()
     {
            #region Instance the Third row


            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft3 = Instantiate(ExplosionTriggerRef, Left3.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight3 = Instantiate(ExplosionTriggerRef, Right3.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth3 = Instantiate(ExplosionTriggerRef, North3.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth3 = Instantiate(ExplosionTriggerRef, South3.transform.position, Quaternion.identity) as GameObject;



            #endregion

            #region Destroy the Third row instance

            Destroy(ExplosionTriggerRight3, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft3, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth3, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth3, 1);
            Destroy(gameObject);

            #endregion
        }

        void InstantiateBombRow4()
     {
            #region Instance the Forth row

            // left1
            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft4 = Instantiate(ExplosionTriggerRef, Left4.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight4 = Instantiate(ExplosionTriggerRef, Right4.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth4 = Instantiate(ExplosionTriggerRef, North4.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth4 = Instantiate(ExplosionTriggerRef, South4.transform.position, Quaternion.identity) as GameObject;



            #endregion

            #region Destroy the Forth row instance

            Destroy(ExplosionTriggerRight4, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft4, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth4, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth4, 1);
            Destroy(gameObject);

            #endregion
        }

        void InstantiateBombRow5()
     {
            #region Instance the Fifth row

            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft5 = Instantiate(ExplosionTriggerRef, Left5.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight5 = Instantiate(ExplosionTriggerRef, Right5.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth5 = Instantiate(ExplosionTriggerRef, North5.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth5 = Instantiate(ExplosionTriggerRef, South5.transform.position, Quaternion.identity) as GameObject;


            #endregion

            #region Destroy the fifth row instance

            Destroy(ExplosionTriggerRight5, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft5, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth5, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth5, 1);
            Destroy(gameObject);

            #endregion
        }

        void InstantiateBombRow6()
     {
            #region Instance the Sixth row

            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft6 = Instantiate(ExplosionTriggerRef, Left6.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight6 = Instantiate(ExplosionTriggerRef, Right6.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth6 = Instantiate(ExplosionTriggerRef, North6.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth6 = Instantiate(ExplosionTriggerRef, South6.transform.position, Quaternion.identity) as GameObject;

            #endregion

            #region Destroy the Sixth row instance

            Destroy(ExplosionTriggerRight6, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft6, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth6, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth6, 1);
            Destroy(gameObject);

            #endregion
        }

        void InstantiateBombRow7()
     {
            #region Instance the Seventh row

            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft7 = Instantiate(ExplosionTriggerRef, Left7.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight7 = Instantiate(ExplosionTriggerRef, Right7.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth7 = Instantiate(ExplosionTriggerRef, North7.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth7 = Instantiate(ExplosionTriggerRef, South7.transform.position, Quaternion.identity) as GameObject;

            #endregion

            #region Destroy the Seventh row instance

            Destroy(ExplosionTriggerRight7, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft7, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth7, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth7, 1);
            Destroy(gameObject);

            #endregion
        }

        void InstantiateBombRow8()
     {
            #region Instance the Eighth row

            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft8 = Instantiate(ExplosionTriggerRef, Left8.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight8 = Instantiate(ExplosionTriggerRef, Right8.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth8 = Instantiate(ExplosionTriggerRef, North8.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth8 = Instantiate(ExplosionTriggerRef, South8.transform.position, Quaternion.identity) as GameObject;

            #endregion

            #region Destroy the Eighth row instance

            Destroy(ExplosionTriggerRight8, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft8, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth8, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth8, 1);
            Destroy(gameObject);

            #endregion
        }

        void InstantiateBombRow9()
     {
            #region Instance the Ninth row

            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft9 = Instantiate(ExplosionTriggerRef, Left9.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight9 = Instantiate(ExplosionTriggerRef, Right9.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth9 = Instantiate(ExplosionTriggerRef, North9.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth9 = Instantiate(ExplosionTriggerRef, South9.transform.position, Quaternion.identity) as GameObject;

            #endregion

            #region Destroy the Ninth row instance

            Destroy(ExplosionTriggerRight9, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft9, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth9, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth9, 1);
            Destroy(gameObject);

            #endregion
        }

        void InstantiateBombRow10()
     {
            #region Instance the Tenth row

            GameObject ExplosionTriggerRef = Resources.Load("paul1") as GameObject;
            GameObject ExplosionTriggerLeft10 = Instantiate(ExplosionTriggerRef, Left10.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerRight10 = Instantiate(ExplosionTriggerRef, Right10.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerNorth10 = Instantiate(ExplosionTriggerRef, North10.transform.position, Quaternion.identity) as GameObject;
            GameObject ExplosionTriggerSouth10 = Instantiate(ExplosionTriggerRef, South10.transform.position, Quaternion.identity) as GameObject;

            #endregion

            #region Destroy the Tenth row instance

            Destroy(ExplosionTriggerRight10, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerLeft10, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerNorth10, 1);
            Destroy(gameObject);

            Destroy(ExplosionTriggerSouth10, 1);
            Destroy(gameObject);

            #endregion
        }







        void OnCollisionEnter(Collision colli) 
        {
            if (colli.gameObject.tag == "Destructable") 
            {
                Destroy(colli.gameObject);
            }


        }


        void PickupPowerUp()
     {
            if (GameVariables.KickBomb == true)
            {
                //if kick bomb is true use  PowerUpKick function
                PowerUpKick();
            }

            if (GameVariables.RangeAddUp == true)
            {
                //if rabge addup is true poweruprange function gets used

                PowerUpRange();
            }
        }

        void PowerUpKick()
     {

        }

        void PowerUpRange()
     {
            //when range add max is true all the rows will be active
            if (GameVariables.RangeAddMax == true)
            {
                InstantiateBombRow2();
                InstantiateBombRow3();
                InstantiateBombRow4();
                InstantiateBombRow5();
                InstantiateBombRow6();
                InstantiateBombRow7();
                InstantiateBombRow8();
                InstantiateBombRow9();
                InstantiateBombRow10();
                GameVariables.RangeAddUp = false;
            }

            if (GameVariables.RangeAddUp == true)
            {
                //what i want to do is, if the power up is picked up it gives the player an int
                //for each int the player has it will activate the next row of range

            }


        }



    
}
