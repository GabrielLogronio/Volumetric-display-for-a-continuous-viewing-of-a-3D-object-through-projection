using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to "Camera Controller" in Reflection Testing, manually rotate the hologram instead of the Kinect
public class ManualRotatorManager : MonoBehaviour
{
    public float speed;
    public bool yAxis, direction = false;

    public GameObject Nike, Venere;

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            if (yAxis)
                transform.Rotate(Vector3.up * Time.deltaTime * speed);
            else
                transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            if (yAxis)
                transform.Rotate(Vector3.up * Time.deltaTime * -speed);
            else
                transform.Rotate(Vector3.forward * Time.deltaTime * -speed);
        }

        if (Input.GetMouseButtonDown(0)) direction = !direction;

        if (Input.GetMouseButtonDown(1)) 
        {
            if (yAxis)
            {
                Nike.SetActive(!Nike.activeInHierarchy);
                Venere.SetActive(!Venere.activeInHierarchy);
            }
        }

        /*
        if (Input.GetAxis("Horizontal") > 0.5f || Input.GetMouseButton(0)) 
        {
            if(yAxis)
                transform.Rotate(Vector3.up * Time.deltaTime * speed);
            else
                transform.Rotate(Vector3.forward * Time.deltaTime * speed);

        }
        else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetMouseButton(1))
        {
            if (yAxis)
                transform.Rotate(Vector3.up * Time.deltaTime * - speed);
            else
                transform.Rotate(Vector3.forward * Time.deltaTime * - speed);
        }
        */
    }
}
