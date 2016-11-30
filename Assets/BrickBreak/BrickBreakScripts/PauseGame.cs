using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

    public bool paused = false;

    public AudioSource PauseG;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PauseInput();
        PauseBoolStuff();
    }

    void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.P) && paused == false)
        {
            paused = true;
            Time.timeScale = 0.0f;

        }
        else if (Input.GetKeyDown(KeyCode.P) && paused == true)
        {
            paused = false;
            Time.timeScale = 1.0f;

        }
    }

    void PauseBoolStuff()
    {
        if (paused == true)
        {
           // PauseG.Play();
            //getcomponents = false
            

        }

        else
        {
            if (paused == false)
            {
                //getcomponents = true
            }
        }
    }





    void OnGUI()
    {
        if (paused == true)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 75, 250, 50), "Quit"))
            {

                Application.Quit();
              
            }

            /*
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 125, 250, 50), "Restart"))
            {
                Application.LoadLevel("Test_test");

            }
           if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 75, 250, 50), "Options"))
            {

            }    */



            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 50), "Main Menu"))
            {
                Application.LoadLevel("MainMenu");
                Time.timeScale = 1.00f;
            }

            /*
                        GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 250, 50), "Resume"))
                        {
                            print (resume);
                        }

                    }

            */




        }
    }

}
