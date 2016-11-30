using UnityEngine;
using System.Collections;

public class BombermanTimer : MonoBehaviour {

    public float timeRemaining = 5;

    public AudioSource finalSound;
    public AudioSource RegularMusic;

    public GUIStyle CountStyle;



    void Start () 
    {
        gameObject.GetComponent<BombermanTimer>().enabled = false;
	}
	void Update () 
    {
        timeRemaining -= Time.deltaTime;
        
        #region Timer = 0 do stuff
        if (timeRemaining == 0) 
        {
         


        }
        #endregion 

        if (timeRemaining < 5)
        {
            finalSound.Play();


        }


        if (timeRemaining > 5)
        {

            RegularMusic.Play();

        }

    }



void OnGUI()
    {
        if(timeRemaining > 0)
        {
            GUI.Label(new Rect(Screen.width*0.4f, Screen.height*0.001f, 200, 400), "" + (int)timeRemaining, CountStyle);
        }
       
    }
    



        }
	

  






