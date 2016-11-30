using UnityEngine;
using System.Collections;

public class SlidePuzzleCam : MonoBehaviour {


    public GUIStyle hinto;
    public Texture ImageKey;
    public Texture GameInstructions;



    bool HasBegun = false;
    bool IsHint = false;

	// Use this for initialization
	void Start () 
    {
       // HasBegun = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.H))
        {
            IsHint = true;
        }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                HasBegun = false;
            }

        else
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                IsHint = false;
            }
        }


       
       
	
	}

    void OnGUI()
    {
        if (IsHint == true)
        {
            GUI.Label(new Rect(525, 20, 200, Screen.height / 3), "This is a hint", hinto);
            GUI.Box(new Rect(490, 50, 200, Screen.height / 3), ImageKey);
        }

        if (HasBegun == true) 
        {
            GUI.Box(new Rect(Screen.width - 700, 0, Screen.width + 5, Screen.height), GameInstructions);
            //GUI.Box(new Rect(Screen.width - 700, 0, Screen.width + 5, Screen.height), "");
            Time.timeScale = 0.00f;
        }
            
        
       
    }

   
   
}
