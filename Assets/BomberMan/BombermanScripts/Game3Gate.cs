using UnityEngine;
using System.Collections;

public class Game3Gate : MonoBehaviour {

	void Update () 
	{
		KeyCheck();
	}
	
	void KeyCheck()
	{
		if(GameVariables.Game3Key == true)
		{
			GetComponent<Rigidbody>();
		}
	}
}
