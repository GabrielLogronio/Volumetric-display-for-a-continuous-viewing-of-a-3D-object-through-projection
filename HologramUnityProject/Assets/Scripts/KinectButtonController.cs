using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In Kinect v1, used to detect collision between hands and controllers
public class KinectButtonController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10) 
        {
            GestureController.getInstance().ButtonPressed(transform.GetSiblingIndex() + "");
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10 && transform.GetSiblingIndex() == 0)
        {
            GestureController.getInstance().ButtonReleased();

        }
    }
    
}
