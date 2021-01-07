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
    public float spawn_distance = 1.0f;
    private Vector3 StartingPosition;
    private bool signal_check;
    private bool execute_check;

    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private float signal_distance = 4.0f;
    [SerializeField]
    private float execute_distance = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
       
        StartingPosition = robot.transform.position;
        signal_check = false;
        execute_check = false;
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

        if(Distance_robot_player < signal_distance && !signal_check)
        {
            signal_check = true;
            StartCoroutine(IdleToGazeLeft());
            //animator.SetFloat("Speed", 1.0f);
        }
        else if(Distance_robot_player > signal_distance)
        {
            animator.SetFloat("GazePosition", 0.0f);
            
            signal_check = false;
            execute_check = false;

            GameObject cube = GameObject.Find("cube_block");
            if(cube)
            {
                Destroy(cube.gameObject);
                Debug.Log("Cube Destroyed");
            }
        }

        if(Distance_robot_player < execute_distance && !execute_check)
        {
            execute_check = true;
            Spawn();
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

    private void Spawn()
    {
        Vector3 robot_transform = robot.transform.position;
        robot_transform.y = 0;
        robot_transform.z = robot_transform.z + spawn_distance;

        Debug.Log("Cube Spawned");
        GameObject cube = Instantiate(cubePrefab, robot_transform , robot.transform.rotation);
        cube.name = "cube_block";
    }
}
