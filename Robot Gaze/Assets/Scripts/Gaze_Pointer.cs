using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze_Pointer : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject Target;
    public GameObject rayCastObject;

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        //rb = this.GetComponent<Rigidbody>();
        //lr.SetPosition(1, (transform.forward * 100));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Target.transform.position - transform.position;

        float singleStep = speed * Time.deltaTime;

        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 2 * Mathf.PI, 0.0f);


        //Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);

        //lr.SetPosition(0, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider != null)
            {

                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
                //Debug.Log("Hit " + hit.collider.gameObject.name);

                if (hit.collider.gameObject.name == "quantum_eyes")
                {
                    rayCastObject.transform.position = hit.point;
                    //rayCastObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                }
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 100);
            //lr.SetPosition(1, Target.transform.position);
            //Debug.Log("Nothing!");
        }
    }
}

