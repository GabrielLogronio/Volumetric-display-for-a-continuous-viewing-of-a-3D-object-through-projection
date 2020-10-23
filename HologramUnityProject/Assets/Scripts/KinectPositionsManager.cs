using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In Kinect v1, track the position of the head and hands
public class KinectPositionsManager : MonoBehaviour
{
    public GameObject userPrefab;
    public int[] bonesID;

    KinectManager manager;
    [SerializeField]
    int currentUserID = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager = KinectManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        uint player1ID = manager != null ? manager.GetPlayer1ID() : 0;
        //uint player2ID = manager != null ? manager.GetPlayer1ID() : 0;

        // No Players
        if (player1ID <= 0) DeleteChildren();
        // Only 1 Player or at least 1
        else //if (player2ID <= 0)
        {
            // Track same user
            if (player1ID == currentUserID)
            {
                for (int i = 0; i < transform.GetChild(0).childCount; i++) 
                {
                    Vector3 posJoint = manager.GetJointPosition(player1ID, bonesID[i]);
                    posJoint = new Vector3(-posJoint.x * 10, posJoint.y * 10, posJoint.z * 10);
                    transform.GetChild(0).GetChild(i).position = posJoint;
                }

            }
            // New user
            else
            {
                DeleteChildren();
                currentUserID = (int)player1ID;
                GameObject newUser = Instantiate(userPrefab);
                newUser.name = "User " + player1ID;
                newUser.transform.SetParent(transform);
            }
        }
    }

    void DeleteChildren() 
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
