using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// Control displaying child models. Traverse through all its childern when showNextModel is called.
public class ModelController : MonoBehaviour {

    static ModelController _instance = null;

    int currentModel = 0, currentDetail = 0;
	// Use this for initialization
	void Start () {

        if (_instance == null) _instance = this;
        else Destroy(this);
	}

    public static ModelController getInstance()
    {
        return _instance;
    }

    public void ShowNextModel()
    {
		transform.GetChild(0).GetChild(currentModel).gameObject.SetActive(false);
        currentModel = (currentModel + 1) % transform.GetChild(0).childCount;
        if (currentModel == 0) 
        {
            // currentModel = 1;
            AlexaController.getInstance().OpenMenu();
            GestureController.getInstance().OpenMenu();
        } else
        transform.GetChild(0).GetChild(currentModel).gameObject.SetActive(true);

        ShowDetail(0);
    }
    public void ShowPreviousModel() 
    {
        transform.GetChild(0).GetChild(currentModel).gameObject.SetActive(false);
        currentModel = ((currentModel - 1) + transform.GetChild(0).childCount) % transform.GetChild(0).childCount;
        if (currentModel == 0) 
        {
            // currentModel = transform.GetChild(0).childCount - 1;
            AlexaController.getInstance().OpenMenu();
            GestureController.getInstance().OpenMenu();
        } else
        transform.GetChild(0).GetChild(currentModel).gameObject.SetActive(true);

        ShowDetail(0);
    }

    public void ShowNextDetail()
    {
        transform.GetChild(0).GetChild(currentModel).GetChild(currentDetail).gameObject.SetActive(false);
        currentDetail = (currentDetail + 1) % transform.GetChild(0).GetChild(currentModel).childCount;
        transform.GetChild(0).GetChild(currentModel).GetChild(currentDetail).gameObject.SetActive(true);

        transform.GetChild(0).GetChild(currentModel).GetChild(0).gameObject.SetActive(true);
    }
    public void ShowPreviousDetail()
    {
        transform.GetChild(0).GetChild(currentModel).GetChild(currentDetail).gameObject.SetActive(false);
        currentDetail = ((currentModel - 1) + transform.GetChild(0).GetChild(currentModel).childCount) % transform.GetChild(0).GetChild(currentModel).childCount;
        transform.GetChild(0).GetChild(currentModel).GetChild(currentDetail).gameObject.SetActive(true);

        transform.GetChild(0).GetChild(currentModel).GetChild(0).gameObject.SetActive(true);
    }

    public void showModel(int idx)
    {
        showModel();

        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            transform.GetChild(0).GetChild(i).gameObject.SetActive(i == idx);
        }
        currentModel = idx;

        //AudioController.getInstance().PlayTitle();

        ShowDetail(0);
    }

    void ShowDetail(int idx) 
    {
        if (currentModel != 0) 
        {
            for (int i = 0; i < transform.GetChild(0).GetChild(currentModel).childCount; i++)
            {
                transform.GetChild(0).GetChild(currentModel).GetChild(i).gameObject.SetActive(i == idx);
            }
            transform.GetChild(0).GetChild(currentModel).GetChild(0).gameObject.SetActive(true);
            currentDetail = idx;
        }
    }

    public void rotateModels(Vector3 direction) 
    {
        transform.GetChild(0).transform.LookAt(new Vector3(transform.position.x + direction.x, 0, transform.position.z + direction.z).normalized);
    }

    public void showModel() 
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void hideModel() 
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public int getCurrentModelID() 
    {
        return currentModel;
    }
    public int getCurrentDetailID()
    {
        return currentDetail;
    }
}
