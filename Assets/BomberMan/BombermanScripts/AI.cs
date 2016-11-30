using UnityEngine;
using System.Collections.Generic;
using System;

public enum Direction
{
    FORWARD,
    BACK,
    LEFT,
    RIGHT,
    FORWARD_RIGHT,
    BACK_RIGHT,
    FORWARD_LEFT,
    BACK_LEFT
}

public class RaycastInfo
{
    public Vector3 vec;
    public Vector3 localVec;
    public RaycastHit hitInfo;
    public Direction direction;
}
public class StateBase
{
    public StateManager m_owner;
    public StateBase(StateManager owner)
    {
        m_owner = owner;
    }
    virtual public void Update()
    {

    }
}

[Serializable]
public class State : StateBase
{
    public bool running;
    public bool playerFound;
    public Vector3 targetPos;

    public string m_name;

    public List<RaycastInfo> raycasts = new List<RaycastInfo>();


    public State(StateManager owner) : base(owner)
    {
        m_name = ToString();

        //m_owner.m_Pos = m_owner.gObject.transform.position;
        //m_owner.gObject = GameObject.FindWithTag("Player");
        raycasts.Add(new RaycastInfo { localVec = new Vector3(0, 0, 1), direction = Direction.FORWARD });
        raycasts.Add(new RaycastInfo { localVec = new Vector3(0, 0, -1), direction = Direction.BACK });
        raycasts.Add(new RaycastInfo { localVec = new Vector3(1, 0, 0), direction = Direction.RIGHT });
        raycasts.Add(new RaycastInfo { localVec = new Vector3(-1, 0, 0), direction = Direction.LEFT });
        raycasts.Add(new RaycastInfo { localVec = new Vector3(0.707f, 0, 0.707f), direction = Direction.FORWARD_RIGHT });
        raycasts.Add(new RaycastInfo { localVec = new Vector3(0.707f, 0, -0.707f), direction = Direction.BACK_RIGHT });
        raycasts.Add(new RaycastInfo { localVec = new Vector3(-0.707f, 0, 0.707f), direction = Direction.FORWARD_LEFT });
        raycasts.Add(new RaycastInfo { localVec = new Vector3(-0.707f, 0, -0.707f), direction = Direction.BACK_LEFT });
    }


    override public void Update()
    {
        foreach (RaycastInfo raycast in raycasts)
        {
            raycast.vec = m_owner.gObject.transform.TransformDirection(raycast.localVec);
        }
    }
}


[Serializable]
public class State_FindingBlock : State
{
    float targetDist;
    Direction targetDir;
    Vector3 targetDest;
    Vector3 playerPos;
    GameObject[] gameObjects;
    NavMeshAgent agent;

    //Vector3 targetPos;

    public State_FindingBlock(StateManager owner) : base(owner)
    {
        targetDist = 9999.0f;
        targetPos.x = 0.0f;
        targetPos.y = 0.0f;
        agent = owner.gObject.GetComponent<NavMeshAgent>();
        playerPos = owner.gObject.transform.position;
    }

    override public void Update()
    {
        base.Update();
        targetDist = 9999.0f;
        //targetDist = 10.0f;
        // If I found a block, change states
        playerPos = m_owner.gObject.transform.position;

        foreach (RaycastInfo raycast in raycasts)
        {
            if (Physics.Raycast(playerPos, raycast.vec, out raycast.hitInfo, 20.0f))
            {
                if (raycast.hitInfo.collider.gameObject.tag == "DestroyBlock")
                {
                    if (raycast.hitInfo.distance < targetDist)
                    {
                        targetDist = raycast.hitInfo.distance;
                        targetPos = raycast.hitInfo.collider.gameObject.transform.position;
                        targetDir = raycast.direction;
                      //  Debug.Log(raycast.vec);
                        targetDest = raycast.vec;
                    }
                }
                //targetDest = raycast.vec;
            }
            //targetDest = raycast.vec;
        }
        if (targetDir == Direction.BACK)
        {
            m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 180, 0);
            //Debug.Log("Turned Around");
        }
        else if (targetDir == Direction.LEFT)
        {
            m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, -90, 0);
            //Debug.Log("Turned Left");
        }
        else if (targetDir == Direction.RIGHT)
        {
            m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 90, 0);
            //Debug.Log("Turned Right");
        }
        else if (targetDir == Direction.BACK_RIGHT)
        {
            m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 135, 0);
           // Debug.Log("Turned Right");
        }
        else if (targetDir == Direction.BACK_LEFT)
        {
            m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, -135, 0);
           // Debug.Log("Turned Right");
        }
        else if (targetDir == Direction.FORWARD_RIGHT)
        {
            m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 45, 0);
            //Debug.Log("Turned Right");
        }
        else if (targetDir == Direction.FORWARD_LEFT)
        {
            m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, -45, 0);
           // Debug.Log("Turned Right");
        }

        //If no block found, search for block, else go to MovingToBlock State
        if (targetPos.x == 0.0 && targetPos.z == 0.0)
        {
           // Debug.Log("Going to BlockSearch State" + targetDest);
            GameVariables.wallFound = false;
            m_owner.SetState(new State_BlockSearch(targetDest, m_owner));
        }
        else
        {
           // Debug.Log("Finding Block\n" + targetPos);
            GameVariables.wallFound = false;
            m_owner.SetState(new State_MovingToBlock(targetPos, m_owner));
        }
    }
}

[Serializable]
public class State_BlockSearch : State
{
    float rand;
    Vector3 firstTarget;
    Vector3 target;
    GameObject searchDest;
    NavMeshAgent agent;

    public State_BlockSearch(Vector3 direction, StateManager owner) : base(owner)
    {
        agent = m_owner.gObject.GetComponent<NavMeshAgent>();
        firstTarget += m_owner.gObject.transform.forward * 5;
        target = m_owner.gObject.transform.position + firstTarget;
        GameVariables.targetSet = false;
        searchDest = Resources.Load("AI_Destination 1") as GameObject;
        GameObject.Instantiate(searchDest, target, m_owner.gObject.transform.rotation);
       // Debug.Log("Entered BlockSearch");
    }
    override public void Update()
    {
        base.Update();

        //GameObject.Instantiate(destination, target, m_owner.gObject.transform.rotation);
       // Debug.Log("Set Destination\n" + target);
        agent.SetDestination(target);

        //if (target.z == 0)
        //{
        //    //target = m_owner.gObject.;
        //    //target.z += 5;
        //    GameObject.Instantiate(searchDest, target, m_owner.gObject.transform.rotation);
        //    Debug.Log("Set Destination");
        //}

        if (GameVariables.targetSet)
        {
         //   Debug.Log("Entering FindingBlock State");
            //GameObject.Destroy(searchDest, 0.5f);
            m_owner.SetState(new State_FindingBlock(m_owner));
        }
        else
        {
            if (GameVariables.wallFound)
            {
                rand = UnityEngine.Random.value;
                if (rand <= 0.5)
                {
                    //Debug.Log("Hit a wall, changing direction\n");
                    GameVariables.wallFound = false;
                    m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, -90, 0);
                    m_owner.SetState(new State_FindingBlock(m_owner));
                }
                else if (rand >= 0.6)
                {
                  //  Debug.Log("Hit a wall, changing direction\n");
                    GameVariables.wallFound = false;
                    m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 90, 0);
                    m_owner.SetState(new State_FindingBlock(m_owner));
                }
            }
            if (GameVariables.AIDestroyBlockCollide)
            {
                GameVariables.AIDestroyBlockCollide = false;
                m_owner.SetState(new State_PlacingBomb(m_owner));
            }
           // Debug.Log("Searching for Block " + target);
            //m_owner.gObject.GetComponent<AI>().targetPos = target;
        }
    }
}

[Serializable]
public class State_MovingToBlock : State
{
    float rand;
    Vector3 target;
    Vector3 targetDir;
    float dTime;
    float speed;
    NavMeshAgent agent;

    public State_MovingToBlock(Vector3 pos, StateManager owner) : base(owner)
    {
        dTime = Time.deltaTime;

        agent = m_owner.gObject.GetComponent<NavMeshAgent>();
        target = pos;
        speed = 20.0f;
        targetDir = target - m_owner.gObject.transform.position;
    }

    override public void Update()
    {
        base.Update();

        if (m_owner.gObject.transform.position != target)
        {
            //Set Destination on NavMesh
            agent.SetDestination(target);
            //m_owner.gObject.GetComponent<AI>().targetPos = target;                                        // Set target for movement in Main Update
          //  Debug.Log("Moving to Block" + target);

            // If block found, change state to PlacingBomb
            if (GameVariables.AIDestroyBlockCollide)    // ===== If moving alongside a block, not actually colliding
            {
                GameVariables.PlaceBomb = true;
                agent.ResetPath();
                //GameVariables.AIDestroyBlockCollide = false;
                m_owner.SetState(new State_PlacingBomb(m_owner));
            }
            // If non-destrubtible wall hit, change direction and move along wall
            if (GameVariables.wallFound)
            {
                rand = UnityEngine.Random.value;
                if (rand <= 0.5)
                {
                  //  Debug.Log("Hit a wall, changing direction\n");
                    GameVariables.wallFound = false;
                    m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, -90, 0);
                    m_owner.SetState(new State_FindingBlock(m_owner));
                }
                else if (rand >= 0.6)
                {
                 //   Debug.Log("Hit a wall, changing direction\n");
                    GameVariables.wallFound = false;
                    m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 90, 0);
                    m_owner.SetState(new State_FindingBlock(m_owner));
                }
            }
        }
    }
}

[Serializable]
public class State_PlacingBomb : State
{
    GameObject Bomb;
    GameObject currentBomb;
    Vector3 bombPos;
    int bombCount;
    float timer;

    public State_PlacingBomb(StateManager owner) : base(owner)
    {
        //GameVariables.HaveBomb = false;
        Bomb = Resources.Load("Bombo") as GameObject;
        bombCount = 0;
        timer = 5.0f;
    }


    override public void Update()
    {
        if (!GameVariables.HaveBomb)
        {
            bombPos = m_owner.gObject.transform.position + m_owner.gObject.transform.forward;
            GameObject.Instantiate(Bomb, bombPos, m_owner.gObject.transform.rotation);
           // Debug.Log("Placed Bomb");
            GameVariables.HaveBomb = true;
            GameVariables.PlaceBomb = true;
            m_owner.SetState(new State_RunningAwayFromBomb(m_owner, bombPos));
        }
    }
}

[Serializable]
public class State_RunningAwayFromBomb : State
{
    bool turn;
    bool destinationFound;
    //bool running;
    float rand;
    public float bombDist;
    public float rot;
    public Vector3 newPos;
    public Vector3 vel;
    GameObject bomb;
    GameObject destination;
    Vector3 bombPos;
    NavMeshAgent agent;

    public State_RunningAwayFromBomb(StateManager owner, Vector3 bombPosition) : base(owner)
    {
        bombPos = bombPosition;
        turn = false;
        destinationFound = false;
        running = false;
        bombDist = 0.0f;
        newPos.x = 0;
        newPos.y = 0;
        newPos.z = 0;
      //  Debug.Log("Running Away From Bomb");
        destination = Resources.Load("AI_Destination 1") as GameObject;
        destination.SetActive(true);
        GameVariables.targetSet = false;
        agent = owner.gObject.GetComponent<NavMeshAgent>();

    }

    override public void Update()
    {
        base.Update();

        if (!destinationFound)
        {
            foreach (RaycastInfo raycast in raycasts)
            {
                if (raycast.direction == Direction.BACK)
                {
                    newPos = m_owner.gObject.transform.position + raycast.vec * 10;
                    m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 180, 0);
                    GameObject.Instantiate(destination, newPos, m_owner.gObject.transform.rotation);
                    destinationFound = true;
                }


                //Debug.Log("Checking direction vectors");
                //if (Physics.Raycast(m_owner.gObject.transform.position, raycast.vec, out raycast.hitInfo, 20.0f))
                //{
                //    Debug.Log("Checking for hits");
                //    if (raycast.hitInfo.collider.gameObject.tag == "Bomb")                            
                //    {
                //        bomb = raycast.hitInfo.collider.gameObject;
                //        newPos = m_owner.gObject.transform.position - raycast.vec * 10;
                //        //GameObject.Instantiate(destination, newPos, m_owner.gObject.transform.rotation);
                //        //Debug.Log("Found Placed Bomb " + bombDist + "  CurrPos: " + m_owner.gObject.transform.position.z + " newPos: " + newPos.z);
                //        //if (raycast.direction == Direction.FORWARD && !turn)
                //        //{
                //        //    m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 180, 0);
                //        //    turn = true;
                //        //}
                //        //else if (raycast.direction == Direction.LEFT && !turn)
                //        //{
                //        //    m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, -90, 0);
                //        //    turn = true;
                //        //}
                //        //else if (raycast.direction == Direction.RIGHT && !turn)
                //        //{
                //        //    m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 90, 0);
                //        //    turn = true;
                //        //}
                //        //agent.SetDestination(newPos);
                //    }
                //}
            }
        }

        if (destinationFound)
        {
           // Debug.Log("Still running away from Bomb");
            //agent.Warp(newPos);
            //m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 180, 0);
            agent.SetDestination(newPos);

            if (GameVariables.targetSet)
            {
               // Debug.Log("Entering Waiting For Bomb State");
                agent.Stop();
                agent.ResetPath();
                m_owner.SetState(new State_WaitingForBomb(m_owner, bomb));
            }
        }

        //if (GameVariables.targetSet)
        //{
        //    Debug.Log("Entering Waiting For Bomb State");
        //    m_owner.SetState(new State_WaitingForBomb(m_owner, bomb));
        //}
        //else if (m_owner.gObject.transform.position != newPos)
        //{
        //    running = true;
        //    Debug.Log("Still Running Away From Bomb " + newPos);
        //    agent.SetDestination(newPos);
        //    //m_owner.gObject.GetComponent<AI>().targetPos = newPos;
        //}
        //if (GameVariables.wallFound || GameVariables.AIDestroyBlockCollide)
        //{
        //	rand = UnityEngine.Random.value;
        //	if (rand <= 0.5)
        //	{
        //		Debug.Log("Hit a wall, changing direction\n");
        //		GameVariables.wallFound = false;
        //        GameVariables.AIDestroyBlockCollide = false;
        //		m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, -90, 0);
        //		m_owner.SetState(new State_FindingBlock(m_owner));
        //	}
        //	else if (rand >= 0.6)
        //	{
        //		Debug.Log("Hit a wall, changing direction\n");
        //		GameVariables.wallFound = false;
        //        GameVariables.AIDestroyBlockCollide = false;
        //        m_owner.gObject.GetComponent<Rigidbody>().transform.Rotate(0, 90, 0);
        //		m_owner.SetState(new State_FindingBlock(m_owner));
        //	}
        //}
    }
}

[Serializable]
public class State_WaitingForBomb : State
{
    GameObject bomb;
    NavMeshAgent agent;
    Vector3 currentPos;
    float timer;

    public State_WaitingForBomb(StateManager owner, GameObject obj) : base(owner)
    {
        agent = m_owner.gObject.GetComponent<NavMeshAgent>();
        bomb = obj;
        currentPos = m_owner.gObject.transform.position;
        timer = 0.0f;
    }

    public override void Update()
    {
        base.Update();
       // Debug.Log("Waiting for Bomb\n");
        //currentPos = m_owner.gObject.transform.position;
        timer += Time.deltaTime;

        if (timer < 2)
        {
            //m_owner.gObject.transform.Translate(currentPos);
            agent.Warp(currentPos);
            //agent.Stop();
            //agent.speed = 0.0f;

           // Debug.Log("Still Waiting for Bomb..." + timer);
        }
        else
        {
            //if (m_owner.playerFound)
            //{
            //    m_owner.SetState(new State_)
            //}
           // Debug.Log("Going to Finding Block\n");
            GameVariables.HaveBomb = false;
            GameVariables.targetSet = false;
            //agent.speed = 12.0f;
            m_owner.SetState(new State_FindingBlock(m_owner));    // Bomb might be destroyed before block, AI might find block before its is then
        }                                                         // destroyed, moving it to the position of now destroyed block, freezing it
                                                                  // in that position, unable to destroy the nonexistant block
    }

}

[Serializable]
public class State_ChasingPlayer : State
{
    Vector3 playerPos;
    GameObject player;
    float playerDist;
    NavMeshAgent agent;

    public State_ChasingPlayer(StateManager owner, Vector3 pos, GameObject obj) : base(owner)
    {
        playerPos = pos;
        player = obj;

        agent = owner.gObject.GetComponent<NavMeshAgent>();
    }

    public override void Update()
    {
        base.Update();
        //playerPos = player.transform.position;
        playerDist = Vector3.Distance(m_owner.gObject.transform.position, playerPos);

        m_owner.gObject.GetComponent<Rigidbody>().transform.LookAt(playerPos);
        //Debug.Log("In Chasing Player State.");

        agent.SetDestination(playerPos);

        //if (m_owner.gObject.transform.position != playerPos)
        //{
        //    Debug.Log("\nMoving Toward Player");
        //    m_owner.gObject.GetComponent<AI>().targetPos = playerPos;
        //
        //    //if (GameVariables.wallFound)
        //    //{
        //    //    m_owner.SetState(new State_FindingBlock(m_owner));
        //    //}
        //    //if (GameVariables.AIDestroyBlockCollide)
        //    //{
        //    //    Debug.Log("\nBlock Found While Chasing Player");
        //    //    m_owner.SetState(new State_PlacingBomb(m_owner));
        //    //}
        //}

        if (GameVariables.wallFound)
        {
            m_owner.SetState(new State_FindingBlock(m_owner));
        }
        if (GameVariables.AIDestroyBlockCollide)
        {
         //   Debug.Log("\nBlock Found While Chasing Player");
            m_owner.SetState(new State_PlacingBomb(m_owner));
        }

        if (playerDist <= 2)
        {
          //  Debug.Log("Dropped a bomb on the player");
            m_owner.SetState(new State_PlacingBomb(m_owner));
        }
    }
}

[Serializable]
public class StateManager
{
    public bool playerFound;
    public StateBase m_currentState;
    public GameObject gObject;
    public Vector3 m_Pos;

    public void SetState(StateBase newState)
    {
        m_currentState = newState;
    }

    public void Update()
    {
        if (m_currentState != null)
        {
            m_currentState.Update();
        }

    }
}
public class AI : MonoBehaviour
{

    // Global Variables
    #region
    bool newStateSet;
    bool wallReset;
    bool playerFound;
    bool running;
    bool foundBlock;
    float maxSpeed;
    float randNum;
    float forwardDist;
    float backwardDist;
    float rightDist;
    float leftDist;
    float playerDist;
    float currDist;
    float testDist;
    float dTime;
    float velMag;
    public Vector3 targetPos;
    Vector3 pos;
    public Vector3 vel;
    Vector3 testPos;
    Vector3 prevPos;
    Vector3 raycastFwd;
    Vector3 raycastBck;
    Vector3 raycastRight;
    Vector3 raycastLeft;
    Vector3 turn90R;
    Vector3 turn90L;
    GameObject targetPlayer;
    GameObject block;
    GameObject currNode;
    GameObject testNode;
    GameObject targetNode;
    GameObject fwdNode;
    GameObject backNode;
    GameObject rightNode;
    GameObject leftNode;
    GameObject[] gameObjects;
    GameObject[] destinations;
    List<GameObject> players = new List<GameObject>();
    NavMeshAgent AIagent;

    //RaycastHit hit;
    public StateManager stateManager;


    #endregion

    // Use this for initialization
    void Start()
    {
        newStateSet = false;
        playerFound = false;
        wallReset = true;
        foundBlock = false;
        maxSpeed = 10.0f;
        forwardDist = 0;
        backwardDist = 0;
        rightDist = 0;
        leftDist = 0;

        vel = new Vector3(0, 0, 0);
        randNum = 0.0f;

        pos = gameObject.transform.position;
        AIagent = gameObject.GetComponent<NavMeshAgent>();
        //AIagent.speed = maxSpeed;
        //gameObject.GetComponent<Rigidbody>().ro;

        stateManager = new StateManager();
        stateManager.gObject = gameObject;
        stateManager.SetState(new State_FindingBlock(stateManager));
        stateManager.m_Pos = gameObject.transform.position;
    }

    // Update is called once per frame------------------------------------------------//
    void Update()
    {

        playerFound = false;
        dTime = Time.deltaTime;
        pos = gameObject.transform.position;
        prevPos = pos;                                                                          // Set prevPos to current position in case needed to return to position before update
        playerDist = 9999;
        // Clear players list if not empty
        if (players.Count != 0)
        {
            players.Clear();
        }

        gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];                      // Find all game objects in the scene and add to array gameObjects
        foreach (GameObject gObject in gameObjects)
        {
            if (gObject.tag == "Player")                                                          // Find all 'Player' game objects and add to List players
            {
                players.Add(gObject);
            }
        }
        for (int i = 0; i < players.Count; i++)
        {
            if ((Vector3.Distance(pos, players[i].transform.position)) <= playerDist)             // Search through player list to find closest player
            {
                playerDist = Vector3.Distance(pos, players[i].transform.position);                // Save closest player distance and save closest player
                targetPlayer = players[i];
                //print("Found Player");
            }
        }

        if (playerDist < 15 && !foundBlock)
        {
            playerFound = true;
            stateManager.playerFound = true;
           // print("Found Player");
        }
        if (playerDist >= 15)
        {
            playerFound = false;
           // print("Forgot Player");
        }

        // Use closest Player object found to chase the player
        if (playerFound && !newStateSet && !GameVariables.HaveBomb)
        {
        //    print("Chasing Player");
            newStateSet = true;
            stateManager.SetState(new State_ChasingPlayer(stateManager, targetPlayer.gameObject.transform.position, targetPlayer));
        }
        if (!playerFound && newStateSet)
        {
          //  print("Forgot Player and resetting");
            newStateSet = false;
            stateManager.SetState(new State_FindingBlock(stateManager));
        }
        //=================  Fix RunningAwayFromBomb so it doesn't get stuck on walls  ==========================//

        //else if (!playerFound)
        //{
        //    stateManager.SetState(new State_FindingBlock(stateManager));
        //}

        // Destroy all destination game objects if necessary
        if (GameVariables.targetSet)
        {
            destinations = FindObjectsOfType(typeof(GameObject)) as GameObject[];
            foreach (GameObject destination in destinations)
            {
                if (destination.tag == "AIDestination")
                {
                    Destroy(destination);
                   // print("Destroyed destination\n");
                }
            }
        }

        if (GameVariables.wallFound)
        {
            stateManager.SetState(new State_FindingBlock(stateManager));
        }
        //if (GameVariables.AIDestroyBlockCollide && !foundBlock)
        //{
        //    Debug.Log("\nBlock Found While Chasing Player");
        //    foundBlock = true;
        //    stateManager.SetState(new State_PlacingBomb(stateManager));
        //}

        // Update the stateManager and move AI toward target location
        stateManager.Update();
    }


    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "DestroyBlock")
        {
            GameVariables.AIDestroyBlockCollide = true;
          //  print("Collided with Block");
        }
        if (collide.gameObject.tag == "AIDestination")
        {
            GameVariables.targetSet = true;
          //  print("Reached Destination\n");
        }
        if (collide.gameObject.tag == "UnBreakable")
        {
            if (wallReset)
            {
                GameVariables.wallFound = true;
                wallReset = false;
               // print("Collided with wall\n");
            }
        }
    }

    void OnCollisionExit(Collision collide)
    {
        if (collide.gameObject.tag == "DestroyBlock")
        {
            GameVariables.AIDestroyBlockCollide = false;
            foundBlock = false;
          //  print("Left Block");
        }
        if (collide.gameObject.tag == "UnBreakable")
        {
            //GameVariables.wallFound = true;
            wallReset = true;
           // print("Left Wall Block\n");
        }
    }



}