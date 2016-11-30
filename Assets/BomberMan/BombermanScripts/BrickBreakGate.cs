using UnityEngine;
using System.Collections;

public class BrickBreakGate : MonoBehaviour {


	
	// Update is called once per frame
	void Update () 
	{
		KeyCheck();
	}

	void KeyCheck()
	{
		if(GameVariables.KeyBrickBreak == true)
		{
			GetComponent<Rigidbody>();
		}
	}
}
