using UnityEngine;
using System.Collections;

public class CameraThird : MonoBehaviour {

    public Texture YouWinThis;
    public Texture YouLoseWoop;
    public Texture GameInst;


    public bool HasBegun = false;


    


    // Use this for initialization
    void Start ()
    {
       // HasBegun = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        PreGameStartInput();
       // CheckForPlayer();
	}


    void PreGameStartInput() 
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            HasBegun = false;
        }

        if (HasBegun == false)
        {
            Time.timeScale = 1.00f;
        }

        if (Input.GetKeyDown(KeyCode.F)&& HasBegun == true)
        {
            Time.timeScale = 0.00f;
        }
        else 
        {
            if (Input.GetKeyUp(KeyCode.F) && HasBegun == true)
            {
                Time.timeScale = 1.00f;
            }
        }
    }

    void PreGameStart() 
    {
        if (HasBegun == true)
        {
            GUI.Box(new Rect(Screen.width - 700, 0, Screen.width + 5, Screen.height), GameInst);
            //GUI.Box(new Rect(Screen.width - 700, 0, Screen.width + 5, Screen.height), "");
            Time.timeScale = 0.00f;
        }
    }


    void CheckForPlayer()
    {

        if (GameVariables.IsAlive == false) 
        {
            GUI.Box(new Rect(Screen.width - 600, 0, Screen.width + 5, Screen.height), YouLoseWoop);
            Time.timeScale = 0.0f;


            // add functionality to these two new buttons
            if (GUI.Button(new Rect(-2, Screen.height - 35, 150, 25), "Try Again"))
            {
                Application.LoadLevel(Application.loadedLevel);
                Time.timeScale = 1.0f;
                GameVariables.YouLose = false;

            }
            else
            {
                if (GUI.Button(new Rect(275, Screen.height - 35, 150, 25), "Main Menu"))
                {
                    Application.LoadLevel("MainMenu");
                }
            }
        }

        if(GameVariables.Game3IsWin == true)
        {
            Time.timeScale = 0.0f;
            GUI.Box(new Rect(Screen.width - 600, 0, Screen.width + 5, Screen.height), YouWinThis);
            
            GameVariables.Game3Key = true;

            if (GUI.Button(new Rect(-2, Screen.height - 35, 150, 25), "Main Menu"))
            {
                Application.LoadLevel("MainMenu");
            }


        }

        /*
        if (GameObject.FindWithTag("Player") == null)
        {
            GUI.Box(new Rect(Screen.width - 600, 0, Screen.width + 5, Screen.height), YouLoseWoop);
            Time.timeScale = 0.0f;


            // add functionality to these two new buttons
            if (GUI.Button(new Rect(-2, Screen.height - 35, 150, 25), "Try Again"))
            {
                Application.LoadLevel(Application.loadedLevel);
                Time.timeScale = 1.0f;
                GameVariables.YouLose = false;

            }
            else
            {
                if (GUI.Button(new Rect(275, Screen.height - 35, 150, 25), "Main Menu"))
                {
                    Application.LoadLevel("MainMenu");
                }
            }
        }*/

       
    }

    void OnGUI() 
    {
        PreGameStart();
        CheckForPlayer();
        Stuff();

    }

    void Stuff() 
    {

        if (GameVariables.IsAlive == false)
        {
            GUI.Box(new Rect(Screen.width - 600, 0, Screen.width + 5, Screen.height), YouLoseWoop);
            Time.timeScale = 0.0f;


            // add functionality to these two new buttons
            if (GUI.Button(new Rect(-2, Screen.height - 35, 150, 25), "Try Again"))
            {
                Application.LoadLevel(Application.loadedLevel);
                Time.timeScale = 1.0f;
                GameVariables.YouLose = false;

            }
            else
            {
                if (GUI.Button(new Rect(275, Screen.height - 35, 150, 25), "Main Menu"))
                {
                    Application.LoadLevel("MainMenu");
                }
            }
        }

        if (GameVariables.Game3IsWin == true)
        {
            Time.timeScale = 0.0f;
            GUI.Box(new Rect(Screen.width - 600, 0, Screen.width + 5, Screen.height), YouWinThis);

            GameVariables.Game3Key = true;

            if (GUI.Button(new Rect(-2, Screen.height - 35, 150, 25), "Main Menu"))
            {
                Application.LoadLevel("MainMenu");
            }


        }
    }
}
