using UnityEngine;
using System.Collections;

public class BombTimer : MonoBehaviour
{
    public GameObject pickup;
    public GameObject target;

    public float BTimer = 5;

    // Use this for initialization
    void Start()
    {
        GetComponent<BombTimer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {


        if (GetComponent<BombTimer>().enabled == true)
        {
            BTimer -= Time.deltaTime;
            target.GetComponent<SpawnAtMe>().enabled = false;
        }

        if (BTimer <= 0)
        {
            GetComponent<BombTimer>().enabled = false;
            target.GetComponent<SpawnAtMe>().enabled = true;
        }


    }

    void OnTriggerEnter(Collider colid)
    {
        if (colid.gameObject.tag == "Player")
        {

            GetComponent<BombTimer>().enabled = true;

            


        }
    }

}
