using UnityEngine;
using System.Collections;

public class PowerUpGetBomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<PowerUpGetBomb>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        GameVariables.BombAdd1 = true;

        print("bombadd1 is true");
	
	}

    void OnTrigerEnter(Collider colli)
    {
       
    }






}
