using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    public GameObject robot;
    public GameObject player;
    public float robot_signal = 4.0f;
    private bool robot_signal_check;

    public Material[] allMaterials = new Material[3];
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        robot_signal_check = false;

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = allMaterials[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        float Distance_robot_player = Vector3.Distance(robot.transform.position, player.transform.position);

        if (Distance_robot_player < robot_signal && !robot_signal_check)
        {
            MaterialSwap();
            robot_signal_check = true;
        }

        if (Distance_robot_player > robot_signal && robot_signal_check)
        {
            MaterialSwap();
            robot_signal_check = false;
        }
    }

    void MaterialSwap()
    {
        if (rend.sharedMaterial == allMaterials[1])
        {
            rend.sharedMaterial = allMaterials[0];
        }

        else if (rend.sharedMaterial == allMaterials[0])
        {
            rend.sharedMaterial = allMaterials[1];
        }
    }
}
