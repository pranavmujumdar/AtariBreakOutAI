using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using MLAgents.Sensors;

public class PaddleAgent : Agent
{
    public bool useVectorObs;
    Rigidbody m_AgentRb;
    Vector3 startPos;
    public float speed = 15f;
    public float rightBound = 8f;
    public float leftBound = -8f;
    private int noOfBricksLeft = 27;

    public GameObject area;
    public GameObject ball;
    [HideInInspector]
    public BreakoutArea areaSettings;


    [HideInInspector]
    public BallBehavior ballSettings;
    void Awake()
    {
        
        areaSettings = area.GetComponent<BreakoutArea>();
        ballSettings = ball.GetComponent<BallBehavior>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }
    /*
    * Initialize is similar to Start, however us it is derived from the Agent class in order to safely configure the agent
    */
    public override void Initialize()
    {
        m_AgentRb = GetComponent<Rigidbody>();

    }

    /*
 * This is the method where the agent is punished when it collides on the obstacle or the ground
 */
    public void Died()
    {
        // Debug.Log("Died");
        AddReward(-2f);
        EndEpisode();
    }
    public void Scored()
    {
        //Debug.Log("Scored");
        noOfBricksLeft--;
        AddReward(1f);
        if (noOfBricksLeft == 0)
        {
            Debug.Log("All bricks hit!");
            AddReward(5f);
            EndEpisode();
        }
    }
    public void hitPaddle()
    {
        // Debug.Log("Hit Paddle");
        AddReward(0.5f);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        {
            AddReward(0.1f);
            int action = Mathf.FloorToInt(vectorAction[0]);
            if (action == 0)
            {
                pushLeft();
            }
            if (action == 1)
            {
                pushRight();
            }
            if (action == 2)
            { 
            }
        }
    }

        public override float[] Heuristic()
    {
        var action = new float[3];
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (x < 0)
        {
            //Debug.Log("going left");
            action[0] = 0;
        }
        else if(x>0)
        {
            //Debug.Log("Going Right");
            action[0] = 1;
        }
        else
        {
            //Debug.Log("Standing");
            action[0] = 2;
        }
        return action;
    }
    public override void OnEpisodeBegin()
    {
        m_AgentRb.velocity = Vector3.zero;
        transform.position = startPos;
        RandomizeX();
        areaSettings.resetArea();
        ballSettings.resetBall();
        noOfBricksLeft = 27;
    }

    private void RandomizeX()
    {
        this.transform.Translate(Vector3.left
            * Random.Range(-0.5f, 0.5f));
    }
    private void pushLeft()
    {
        m_AgentRb.transform.Translate(-1*speed*Time.deltaTime, 0f, 0f);
    }
    private void pushRight()
    {
        m_AgentRb.transform.Translate(1*speed * Time.deltaTime, 0f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        transform.position = new Vector3(Mathf.Clamp(pos.x, leftBound, rightBound), pos.y, pos.z);
    }
}
