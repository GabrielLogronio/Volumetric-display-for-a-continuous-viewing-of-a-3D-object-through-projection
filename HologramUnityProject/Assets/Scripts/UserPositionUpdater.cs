using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to the userHead, register itself as the gameobject to follow and rotate the controller towards he hologram
public class UserPositionUpdater : MonoBehaviour
{
    Vector3 managerPosition;
    GameObject rightHand, leftHand;
    GestureController gc;

    // Start is called before the first frame update
    void Start()
    {
        UserPositionManager.getInstance().AddUser(gameObject);
        rightHand = transform.parent.GetChild(1).gameObject;
        leftHand = transform.parent.GetChild(2).gameObject;

        gc = GestureController.getInstance();

    }

    private void OnDestroy()
    {
        UserPositionManager.getInstance().RemoveUser();
    }

    public void SetPosition(Vector3 toSetPosition) 
    {
        managerPosition = toSetPosition;
    }

    void Update() 
    {
        transform.LookAt(new Vector3(managerPosition.x, transform.position.y, managerPosition.z));
        Debug.DrawLine(transform.position, managerPosition, Color.green);

        if (Vector2.Distance(new Vector2(managerPosition.x, managerPosition.z), new Vector2(rightHand.transform.position.x, rightHand.transform.position.z))
        > Vector2.Distance(new Vector2(managerPosition.x, managerPosition.z), new Vector2(leftHand.transform.position.x, leftHand.transform.position.z)))
        {
            gc.SetCursorPosition(new Vector2(-leftHand.transform.position.x, leftHand.transform.position.y - 9f) / 6);
        }
        else 
        {
            gc.SetCursorPosition(new Vector2(-rightHand.transform.position.x, rightHand.transform.position.y - 9f) / 6);
        }
    }

}
