using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneralController : MonoBehaviour
{
    [SerializeField]
    protected bool currentlyActive = false, listening = false;
    protected float activateTime = 10f;
    [SerializeField]
    protected string language;
    protected void SelectLanguage(string language)
    {
        this.language = language;
        ListManager.getInstance().InitializeList(language);
        OpenMenu();
    }
    protected void Activate()
    {
        Debug.Log("Command: Activate");

        CancelInvoke();
        //Invoke("Deactivate", activateTime);

        if (ModelController.getInstance().getCurrentModelID() == 0)
        {
            if (!currentlyActive)
            {
                ModelController.getInstance().showModel();
            }
        }
        else
        {
            ModelController.getInstance().showModel(0);
            EnteringAssistant();
        }

        transform.GetChild(0).GetChild(0).GetComponent<AssistantAnimationController>().Waving();
        //AudioController.getInstance().PlayIntro();

        currentlyActive = true;

    }
    public virtual void StartListening() 
    {
        listening = true;
    }
    public void StopListening() 
    {
        listening = false;
    }
    protected void Rotate()
    {
        ModelController.getInstance().rotateModels(UserPositionManager.getInstance().getUserDirection());

    }
    protected void StartPresentation()
    {
        if (listening) 
        {
            LeavingAssistant();
            currentlyActive = true;
            ModelController.getInstance().showModel(1);
        }
    }
    protected void NextModel()
    {
        Debug.Log("Command: Show Next Model");
        if (listening && currentlyActive && ModelController.getInstance().getCurrentModelID() != 0)
        {
            LeavingAssistant();

            ModelController.getInstance().ShowNextModel();

            EnteringAssistant();
        }
    }
    protected void PreviousModel()
    {
        Debug.Log("Command: Show Previous Model");

        if (listening && currentlyActive && ModelController.getInstance().getCurrentModelID() != 0)
        {
            LeavingAssistant();

            ModelController.getInstance().ShowPreviousModel();

            EnteringAssistant();
        }
    }
    protected void NextDetail()
    {
        Debug.Log("Command: Show Next Detail");
        if (listening && currentlyActive && ModelController.getInstance().getCurrentModelID() != 0)
        {
            ModelController.getInstance().ShowNextDetail();
        }
    }
    protected void PreviousDetail()
    {
        Debug.Log("Command: Show Previous Detail");

        if (listening && currentlyActive && ModelController.getInstance().getCurrentModelID() != 0)
        {
            ModelController.getInstance().ShowPreviousDetail();
        }
    }
    protected void PlayAudioDescription()
    {
        Debug.Log("Play audio description");
        //AudioController.getInstance().PlayAudio();
    }
    protected void StopAudioDescription()
    {
        Debug.Log("Stop audio description");
        //AudioController.getInstance().PauseAudio();
    }
    protected void SetItem(int i)
    {
        Debug.Log("Opening " + i + "th model");
        LeavingAssistant();
        currentlyActive = true;
        ModelController.getInstance().showModel(i);
    }
    public void OpenMenu()
    {
        if (listening) 
        {
            Debug.Log("Command: Open UI");

            transform.GetChild(0).GetChild(0).GetComponent<AssistantAnimationController>().OpenUI(true);
            if (ModelController.getInstance().getCurrentModelID() == 0) Invoke("InvokeOpenMenu", 0.75f);
            else InvokeOpenMenu();

        }
    }
    protected void CloseMenu()
    {
        if (listening) 
        {
            Debug.Log("Command: Close UI");

            CancelInvoke();
            transform.GetChild(0).GetChild(0).GetComponent<AssistantAnimationController>().OpenUI(false);
            transform.GetChild(1).GetChild(0).gameObject.SetActive(false);

        }
    }

    protected void Deactivate()
    {
        if (ModelController.getInstance().getCurrentModelID() == 0)
        {
            currentlyActive = false;
            ModelController.getInstance().hideModel();
        }
    }

    protected void InvokeOpenMenu()
    {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
    }

    protected void LeavingAssistant()
    {
        CancelInvoke();
        if (ModelController.getInstance().getCurrentModelID() == 0)
        {
            transform.GetChild(0).GetChild(0).GetComponent<AssistantAnimationController>().Reset();
            CloseMenu();
        }
    }

    protected void EnteringAssistant()
    {
        if (ModelController.getInstance().getCurrentModelID() == 0)
        {
            //Invoke("Deactivate", activateTime);
        }
    }
}
