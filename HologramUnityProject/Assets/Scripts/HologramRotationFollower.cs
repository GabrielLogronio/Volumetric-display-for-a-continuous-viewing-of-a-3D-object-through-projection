using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Follow the rottion of the Initializer and applies it to the hologram
public class HologramRotationFollower : MonoBehaviour
{
    [SerializeField]
    Transform RotationToFollow;

    [SerializeField]
    float Correction;

    float setCorrection;

    // Update is called once per 

    void Start() 
    {
        Invoke("Set", 1f);
    }

    void Set() 
    {
        setCorrection = Correction;
    }

    void Update()
    {
        // Indica il verso della rotazione
        transform.eulerAngles = new Vector3(0f, 0f, RotationToFollow.eulerAngles.y + setCorrection);
    }
}
