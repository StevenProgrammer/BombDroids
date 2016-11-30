using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    bool IsMinigamescreen = false;
    bool IsOptionsMenu = false;
    bool isMainMenu = false;


    public GUIStyle BrickBreakText;
    public GUIStyle SliderPuzzleText;
    public GUIStyle MiniGame3Text;

    //this function only applies when the game first starts
    void Start ()
    {
        //when the game starts main menu is true
        isMainMenu = true;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    void OnGUI()
    {
        
        MiniG();
        OptionsM();
        MainM();
    }

    void MainM()
    {

        //if main menu is true do this
        if(isMainMenu == true)
        {

            //(x position on the screen,y position on the screen,Button Length,Button Height,) 
            //for every button added add 35 on the y position



            //if menu is true show these buttons
            if (GUI.Button(new Rect(155, Screen.height / 2 - 25, 150, 25), "Start Da Game"))
            {
                Application.LoadLevel("BomberManGame");
            }

            if (GUI.Button(new Rect(155, Screen.height / 2 + 10, 150, 25), "MiniGames"))
            {
                IsMinigamescreen = true;
                Debug.Log("Minigamescreen");
                isMainMenu = false;
                IsOptionsMenu = false;

              
            }

            if (GUI.Button(new Rect(155, Screen.height / 2 + 45, 150, 25), "Options"))
            {
                IsOptionsMenu = true;
                isMainMenu = false;
                IsMinigamescreen = false;
            }


            if (GUI.Button(new Rect(155, Screen.height / 2 + 80, 150, 25), "Credits"))
            {
                Application.LoadLevel("Credits");
            }

            if (GUI.Button(new Rect(155, Screen.height / 2 + 115, 150, 25), "Quit"))
            {
                Application.Quit();
            }


        }
    }



    void MiniG()
    {
        //(x position on the screen,y position on the screen,Button Length,Button Height,) 
        //for every button added add 35 on the y position



            if(IsMinigamescreen == true)
            {
            //if the screen is true turn off the options screen 
            IsOptionsMenu = false;


            // GUI.Box(new Rect(Screen.width - 300, 0, Screen.width, Screen.height), "");

            GUI.Box(new Rect(Screen.width - 350, 0, Screen.width /2 +50, Screen.height), "");

            //if minigames menu are true 
            //show these buttons

            // label for the first minigame
            GUI.Label(new Rect(185, Screen.height / 5 + 25, 150, 65), "Brick Break", BrickBreakText);

            //create the brick break button 
            if (GUI.Button(new Rect(155, Screen.height / 4 - 75, 150, 65), ""))
            {
                Application.LoadLevel("BrickBreak");
            }
           

            //label the second minigame
            GUI.Label(new Rect(150, Screen.height / 5 + 130, 150, 65), "Slider Puzzle", BrickBreakText);

            //create the slider puzzle button
            if (GUI.Button(new Rect(155, Screen.height / 4 + 35, 150, 65),""))
            {
                Application.LoadLevel("SliderPuzzle");
            }

            //label the third minigame
            GUI.Label(new Rect(175, Screen.height / 5 + 215, 150, 65), "Game 3", BrickBreakText);

            //create the third game button
            if (GUI.Button(new Rect(155, Screen.height / 4 + 125, 150, 65), "ThirdG"))
            {
                Application.LoadLevel("ThirdMiniG");
            }
            


            //create the back button
            if (GUI.Button(new Rect(10, Screen.height - 35, 50, 25), "Back"))
            {
                Application.LoadLevel("MainMenu");
            }

        }
        }

    
    

    // this funtion does stuff to the options button

    void OptionsM()
    {
        
        
        

          if(IsOptionsMenu == true)
            {

            isMainMenu = false;
            }

            if(isMainMenu == false && IsOptionsMenu == true)
        {

           

            // this is the box that holds the buttons in the options menu
            GUI.Box(new Rect(155, 0, 200 , Screen.height), "");

            // graphics setting button
            if (GUI.Button(new Rect(2, Screen.height / 2 - 25, 150, 25), "Graphics Settings"))
            {
                //when button is pressed add audio functionality to the graphics on the box
            }

            //sound settings button
            if(GUI.Button(new Rect(2, Screen.height / 2 + 10, 150, 25), "Sound Settings"))
            {
                //when button is pressed add audio functionality to the audio on the box
            }

            //back button for options
            if (GUI.Button(new Rect(10, Screen.height - 35, 50, 25), "Back"))
            {
                Application.LoadLevel("MainMenu");
                IsOptionsMenu = false;


            }
            

        }
         
    }
    


}
