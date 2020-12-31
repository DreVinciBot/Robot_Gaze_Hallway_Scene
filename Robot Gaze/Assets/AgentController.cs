using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public GameObject robot;
    public GameObject player;
    public GameObject DestinationPosition;
    public NavMeshAgent agent;
    private Vector3 StartingPosition;


    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = robot.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(DestinationPosition.transform.position);

        float Distance_robot_goal = Vector3.Distance(robot.transform.position, DestinationPosition.transform.position);
        float Distance_robot_player = Vector3.Distance(robot.transform.position, player.transform.position);
 
        if(Distance_robot_goal < 0.1)
        {
            robot.transform.position = StartingPosition;
        }
    }
}
