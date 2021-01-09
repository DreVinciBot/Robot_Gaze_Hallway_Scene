using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour
{
    public Transform eyeDest;
    public GameObject Eyeball;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(eyeDest);
        Gaze_Pointer();
    }

    void Gaze_Pointer()
    {
        RaycastHit hit;

        if(Physics.Raycast(Eyeball.transform.position, Eyeball.transform.forward, out hit))
        {
            if(hit.collider.tag == "Robot_screen")
            {
                print("Hit : " + hit.collider.gameObject.name);
            }
        }
    }
}
