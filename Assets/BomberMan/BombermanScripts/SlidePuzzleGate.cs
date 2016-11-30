using UnityEngine;
using System.Collections;

public class SlidePuzzleGate : MonoBehaviour {


	
	void Update () 
	{
		KeyCheck();
	}
	
	void KeyCheck()
	{
		if(GameVariables.KeySlidePuzzle == true)
		{
			GetComponent<Rigidbody>();
		}
	}
}
