using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze_Pointer : MonoBehaviour
{
    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //lr.SetPosition(0, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "Robot_screen")
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
                Debug.Log("Hit Sreen!");
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 100);
            Debug.Log("Nothing!");
        }
    }
}

