using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject robot;
    public GameObject player;
    public float robot_signal;
    public float robot_conflict;
    public float robot_execute;
    public bool videoCheck;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
        videoCheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance_robot_player = Vector3.Distance(robot.transform.position, player.transform.position);

        if(Distance_robot_player < robot_signal && videoCheck)
        {
            PlayVideoSignal();
            videoCheck = false;
        }

        if (Distance_robot_player < robot_execute)
        {

        }
    }

    void ResetPosition()
    {
        //Debug.Log("Here!");
    }

    void PlayVideoSignal()
    {
        videoPlayer.SetActive(true);

    }
}
