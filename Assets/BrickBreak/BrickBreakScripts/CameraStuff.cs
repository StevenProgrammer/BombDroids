using UnityEngine;
using System.Collections;

public class CameraStuff : MonoBehaviour {

    public  AudioSource HitSound;
    public  AudioSource Taunt;
    public AudioSource BrickDie;
    public AudioSource BallFailed;

    public AudioSource LoseGame;
    public AudioSource WinGame;
    public AudioSource NewLevel;


    public Texture YouWinThis;
    public Texture YouLoseWoop;
    public Texture GameInst;


    public GUIStyle scores;

    bool HasBegun = false;
    


    public int Score = 0;
    public float Lives = 3f;
    public float Timr = 5;



	// Use this for initialization
	void Start () 
    {
       // HasBegun = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        GameStart();

        SoundsViaHit();
        DoStuffIfTrue();
        LifeActions();
        ScoreActions();
        TimerActions();

        CheckScene();


        Timr -= Time.deltaTime;

        if (Timr < 0)
        {
            Debug.Log("Game Over");
        }
    }

    void GameStart() 
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            HasBegun = false;
        }

        if (HasBegun == false) 
        {
           // Time.timeScale = 1.00f;
        }

    }


    void OnGUI()
    {
        if (HasBegun == true)
        {
            GUI.Box(new Rect(Screen.width - 700, 0, Screen.width + 5, Screen.height), GameInst);
            //GUI.Box(new Rect(Screen.width - 700, 0, Screen.width + 5, Screen.height), "");
            //Time.timeScale = 0.00f;
        }

        //x,y,height,length

        //draw the score counter

        //GUI.TextField(new Rect(180, Screen.height / 2 - 25, 150, 25), "Score");

        //draw the life count

        if (GameVariables.YouLose == true)
        {
            GUI.Box(new Rect(Screen.width - 700, 0, Screen.width + 5, Screen.height), YouLoseWoop);
            //Time.timeScale = 0.0f;
                    
            
            // add functionality to these two new buttons
           if(GUI.Button(new Rect(-2, Screen.height - 35, 150, 25), "Try Again"))
            {
                Application.LoadLevel(Application.loadedLevel);
                //Time.timeScale = 1.0f;
                GameVariables.YouLose = false;

            }
            else
            {
                if (GUI.Button(new Rect(275, Screen.height - 35, 150, 25), "Main Menu"))
                {
                    Application.LoadLevel("MainMenu");
                    //Time.timeScale = 1.00f;
                }
            }
        }

        else

        {
            if (GameVariables.YouWin == true)
            {
				/*
				GUI.Box(new Rect(Screen.width - 450, 0, Screen.width + 5, Screen.height),YouWinThis);
                //GUI.Box(new Rect(Screen.width - 500, 0, Screen.width, Screen.height), YouWinThis);
                Time.timeScale = 0.0f;
                Debug.Log("You Win");
                GameVariables.KeyBrickBreak = true;

				if (GUI.Button(new Rect(275, Screen.height - 35, 150, 25), "Main Menu"))
				{
					Application.LoadLevel("MainMenu");
				}
				*/

				GUI.Box(new Rect(Screen.width - 800, 0, Screen.width + 5, Screen.height), YouWinThis);
				//Time.timeScale = 0.0f;

				GameVariables.KeyBrickBreak = true;
				
				
				//make some buttons if gameover screen

				if(GUI.Button(new Rect(-2, Screen.height - 35, 150, 25), "Main Menu"))
				{
					Application.LoadLevel("MainMenu");
				}

            }
        }








 

         //   GUI.Label(new Rect(02, 25, 100, 30), "Timer:" + Timr, scores);
        

        GUI.Label(new Rect(02, 55, 100, 30), "Score:" + Score.ToString(), scores);

        GUI.Label(new Rect(02, 85, 100, 30), "Lives:" + Lives, scores);

    }

    void CheckScene()
    {
        //use this function to check the scene for stuff

        //this function calls on the check ball function
        BallCheck();

        //this function calls on the check brick function
        BrickCheck();
    }

    void BallCheck()
    {

    }

    void BrickCheck()
    {
        if (GameVariables.BrickDead == true)
        {
            //findgameobjectswith tag always returns a number so when the number hits zero the game is over
            GameObject[] numbricks = GameObject.FindGameObjectsWithTag("Brick");
            int length = numbricks.Length;

            if (length == 0)
            {
                GameVariables.BricksDead = true;
                Debug.Log("cant find bricks");
            }

            if (GameVariables.BricksDead == true)
            {
                GameVariables.YouWin = true;
                Debug.Log("Huzzah");
            }
        }
       
    }

    void OnDestroy()
    {
       
    }

    void DoStuffIfTrue()
    {

        /*
        GUI.Label(new Rect(10, Screen.height / 2 - 200, 200, 50), "Rawr")
        {

        }

    */
    if(GameVariables.YouWin == true)
        {
            
        }
        else
        {
           if(GameVariables.YouLose == true)
            {
               
            }
        }

    if(GameVariables.AddScore == true)
        {
            Score += 1;
        }




        
    }


    void SoundsViaHit()
    {
        if (GameVariables.hitSound)
        {
            HitSound.Play();
        }
        else
        {
            if (!GameVariables.hitSound)
            {

            }
        }
        if (GameVariables.BrickDead)
        {
            //BrickDie.Play();
        }

        if (GameVariables.BricksDead == true)
        {
      
           // WinGame.Play();
            Debug.Log("You Win");
        }
    }
    void LifeActions()
    {

    }

    void ScoreActions()
    {
        
        if(Score >= 100)
        {
            //if score is 100 or more
            //give the player something
        }
    }

    void TimerActions()
    {
        /*
        if(GameVariables.BrickBreakStart == true)
        {
            Timr -= Time.deltaTime;

            if(Timr < 0)
            {
                Debug.Log("Game Over");
            }

        }
        */
    }


}
