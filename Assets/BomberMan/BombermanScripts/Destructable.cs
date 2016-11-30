using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   
        void OnTriggerStay(Collider collision)
    {
       // print("owie");
            if (collision.gameObject.tag == "paul1")
            {
                Destroy(gameObject);
                 print("owie");
            }
        }


    /*
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "paul1")
            {
                Destroy(gameObject);
                 print("owie");
            }
        }
    
 */


}
