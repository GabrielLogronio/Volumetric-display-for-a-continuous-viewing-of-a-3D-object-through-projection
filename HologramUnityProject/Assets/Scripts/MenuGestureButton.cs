using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGestureButton : MonoBehaviour
{
    float timer = 2.5f;
    [SerializeField]
    string toSend;

    void OnTriggerEnter2D(Collider2D col)
    {
        Invoke("PressedButton", timer);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
    }

    void PressedButton() 
    {
        GestureController.getInstance().ButtonPressed(toSend);
    }

    public void setString(string toSet) 
    {
        toSend = toSet;
    }
}
