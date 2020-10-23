using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// TO TEST
public class GestureController : GeneralController
{
    float resetTime = 1.5f;

    [SerializeField]
    Vector2 cursorPosition = Vector2.zero;

    bool pressing = false, browsing = false, inMenu = false;

    static GestureController instance = null;

    GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else Destroy(this);

        currentlyActive = true;
        cursor = transform.GetChild(1).GetChild(2).gameObject;
    }
    private void Update()
    {
        if (inMenu) 
        {
            cursor.transform.position = cursorPosition - new Vector2(0, 0.66f);
        }
    }

    public static GestureController getInstance() 
    {
        return instance;
    }

    public void ButtonPressed(string buttonID) 
    {
        if (listening) 
        {
            if (inMenu)
            {
                switch (buttonID.Substring(0, 1)) 
                {
                    case "i":
                        Debug.Log("Language: Italian");
                        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                        SelectLanguage("it");
                        break;
                    case "e":
                        Debug.Log("Language: English");
                        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                        SelectLanguage("en");
                        break;
                    case "o":
                        int ID = Int32.Parse(buttonID.Substring(1));
                        Debug.Log("Object " + ID);
                        SetItem(ID + 1);
                        inMenu = false;
                        browsing = true;
                        cursor.transform.position = new Vector3(0, 5f, 0f);
                        string objectName = transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetComponent<TitleLocalizer>().getString(language);
                        Debug.Log("Skipped to: " + objectName);
                        TTSManager.get_Instance().ReadText(objectName);
                        break;
                }
            }
            else if (browsing) 
            {
                if (pressing)
                {
                    if (ModelController.getInstance().getCurrentModelID() != 0)
                    {
                        switch (buttonID)
                        {
                            case "1":
                                Debug.Log("Right button pressed");
                                NextDetail();
                                CancelInvoke();
                                pressing = false;

                                TTSManager.get_Instance().ReadText(transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetChild(ModelController.getInstance().getCurrentDetailID()).GetComponent<TitleLocalizer>().getString(language));
                                break;
                            case "2":
                                Debug.Log("Left button pressed");
                                PreviousDetail();
                                CancelInvoke();
                                pressing = false;

                                TTSManager.get_Instance().ReadText(transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetChild(ModelController.getInstance().getCurrentDetailID()).GetComponent<TitleLocalizer>().getString(language));
                                break;
                            case "3":
                                Debug.Log("Up button pressed");
                                PreviousModel();
                                CancelInvoke();
                                pressing = false;

                                TTSManager.get_Instance().ReadText(transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetComponent<TitleLocalizer>().getString(language));
                                break;
                            case "4":
                                Debug.Log("Down button pressed");
                                NextModel();
                                CancelInvoke();
                                pressing = false;

                                TTSManager.get_Instance().ReadText(transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetComponent<TitleLocalizer>().getString(language));
                                break;
                        }
                        TTSManager.get_Instance().ReadText(transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).gameObject.name);
                    }
                }
                else
                {
                    if (buttonID == "0")
                    {
                        Invoke("CenterPressed", resetTime);
                        pressing = true;
                    }
                }
            }
        }
    }

    public void ButtonReleased() 
    {
        pressing = false;
    }

    public void SetCursorPosition(Vector2 handPosition) 
    {
        if (inMenu) 
        {
            cursorPosition = handPosition;
        }
    }

    public void Browsing(bool toSet) 
    {
        browsing = toSet;
    }

    public override void StartListening() 
    {
        base.StartListening();
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        inMenu = true;
    }


    private void CenterPressed()
    {
        pressing = false;
        TTSManager.get_Instance().ReadText(transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetChild(ModelController.getInstance().getCurrentDetailID())
            .gameObject.GetComponent<DescriptionLocalizer>().getString(language));

    }

}
