using UnityEngine;
using System.Collections;

public class Paul1Script : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider collision)
    {
      

            if (collision.gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
            }

        if (collision.gameObject.tag == "AI")
        {
            Destroy(collision.gameObject);
        }
    }


    void OnTriggerStay(Collider collision)
        {

        if (collision.gameObject.tag == "DestroyBlock")
        {
            Destroy(collision.gameObject);

        }
    }
   

    }

