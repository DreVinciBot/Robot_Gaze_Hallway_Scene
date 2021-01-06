using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Animator animator;
    public GameObject robot;
    public GameObject player;
    public GameObject DestinationPosition;
    public NavMeshAgent agent;
    private Vector3 StartingPosition;
    private bool signal_check;


    // Start is called before the first frame update
    void Start()
    {
       
        StartingPosition = robot.transform.position;
        signal_check = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(DestinationPosition.transform.position);

        Vector3 robot2D = robot.transform.position;
        robot2D.y = 0;
        float Distance_robot_goal = Vector3.Distance(robot2D, DestinationPosition.transform.position);

        float Distance_robot_player = Vector3.Distance(robot.transform.position, player.transform.position);


        if(Distance_robot_goal < 0.1)
        {
            robot.transform.position = StartingPosition;
        }

        if(Distance_robot_player < 4 && !signal_check)
        {
            signal_check = true;
            StartCoroutine(IdleToGazeLeft());
            //animator.SetFloat("Speed", 1.0f);
        }
        else if(Distance_robot_player > 4)
        {
            animator.SetFloat("GazePosition", 0.0f);
            signal_check = false;
        }
    }

    IEnumerator IdleToGazeLeft()
    {
        Debug.Log("Gaze Call!");
        WaitForSeconds wait = new WaitForSeconds(0.001f);

        for (int i = 0; i < 100; i++)
        {
            animator.SetFloat("GazePosition", i);
            yield return wait;
        }
    }
}
