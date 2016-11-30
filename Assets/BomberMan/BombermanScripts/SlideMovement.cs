using UnityEngine;
using System.Collections;

public class SlideMovement : MonoBehaviour
{

    public Texture WinScreen;

    public GameObject slot;


    float xtemp;
    float ytemp;


    // variables that define each of the cubes we reference later to end the game;

    #region GameObjects

    public GameObject ThirdLeftEnd;
    public GameObject ThirdSecondEnd;
    public GameObject ThirdThirdEnd;
    public GameObject ThirdForthEnd;

    public GameObject ForthLeftEnd;
    public GameObject ForthSecondEnd;
    public GameObject ForthThirdEnd;
    public GameObject ForthForthEnd;

    public GameObject SecondLeftEnd;
    public GameObject SecondSecondEnd;
    public GameObject SecondThirdEnd;

    public GameObject FirstLeftEnd;
    public GameObject FirstSecondEnd;
    public GameObject FirstThirdEnd;
    public GameObject FirstForthEnd;

    #endregion



    // Use this for initialization
    void Start()
    {

        //0,1,2,3

        //4 of 3
        //3 of 2
        //4 of 1
        //4 of 0


        FirstLeftEnd.transform.position = new Vector3(0, 0,0);
        FirstSecondEnd.transform.position = new Vector3(1, 0, 0);
        FirstThirdEnd.transform.position = new Vector3(2, 0,0);
        FirstForthEnd.transform.position = new Vector3(3, 0, 0 );


      SecondLeftEnd.transform.position = new Vector3(0, 1,0 );
      SecondSecondEnd.transform.position = new Vector3(1, 2,0 );
      SecondThirdEnd.transform.position = new Vector3(0, 3, 0);
        

       ThirdLeftEnd.transform.position = new Vector3(1, 3, 0);
       ThirdSecondEnd.transform.position = new Vector3(3, 1,0 );
       ThirdThirdEnd.transform.position = new Vector3(2, 2, 0);
       ThirdForthEnd.transform.position = new Vector3(3, 3, 0);

        ForthLeftEnd.transform.position = new Vector3(1, 1, 0);
        ForthSecondEnd.transform.position = new Vector3(2, 3, 0);
        ForthThirdEnd.transform.position = new Vector3(0, 2, 0);
        ForthForthEnd.transform.position = new Vector3(2, 1, 0);

    }

    // Update is called once per frame

    void OnMouseUp()
    {
        //If theDistance==1 between tiles then swap tiles
        if (Vector3.Distance(transform.localPosition, slot.transform.position) == 1)
        {

            xtemp = transform.localPosition.x;
            ytemp = transform.localPosition.y;
            transform.localPosition = new Vector3(slot.transform.position.x, slot.transform.position.y, 0f);
            slot.transform.position = new Vector3(xtemp, ytemp, 0f);

        }

        // how to end the game
        // need to set some variables to defind each of the cubes

 
       

        if(FirstLeftEnd.transform.position == new Vector3(0, 3, 0) && FirstSecondEnd.transform.position == new Vector3(1, 3, 0) && FirstThirdEnd.transform.position == new Vector3(2, 3, 0) 
        && FirstForthEnd.transform.position == new Vector3(3, 3, 0) && SecondLeftEnd.transform.position == new Vector3(0,2,0) && SecondSecondEnd.transform.position == new Vector3(1,2,0) 
        && SecondThirdEnd.transform.position == new Vector3(2,2,0) && ThirdLeftEnd.transform.position == new Vector3(0,1,0) && ThirdSecondEnd.transform.position == new Vector3(1,1,0) 
        && ThirdThirdEnd.transform.position == new Vector3(2, 1, 0) && ThirdForthEnd.transform.position == new Vector3(3, 1, 0) && ForthLeftEnd.transform.position == new Vector3(0, 0, 0) 
        && ForthSecondEnd.transform.position == new Vector3(1, 0, 0) && ForthThirdEnd.transform.position == new Vector3(2, 0, 0) && ForthForthEnd.transform.position == new Vector3(3, 0, 0))

        {
            GUI.Box(new Rect(Screen.width - 400, 0, Screen.width + 5, Screen.height), WinScreen);
            Time.timeScale = 0.0f;
			GameVariables.KeySlidePuzzle = true;
        }
        
		//LastLeftEnd.transform.position == new Vector3(0, -1, 0) && 
        

    }




  
}

