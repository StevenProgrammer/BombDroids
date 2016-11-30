using UnityEngine;
using System.Collections;

public class CreditsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void CreditsM()
    {
        if (GUI.Button(new Rect(10, Screen.height - 35, 150, 25), "Back"))
        {
            Application.LoadLevel("MainMenu");
        }
    }

    void OnGUI()
    {
        CreditsM();
    }
}
