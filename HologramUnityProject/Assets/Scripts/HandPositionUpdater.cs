using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// In Kinect v2, links hands to UI
public class HandPositionUpdater : MonoBehaviour
{
    [SerializeField]
    bool Righthand;

    Image ButtonImage;

    float currentValue = 0f, maxValue = 3f;

    bool charging = false;

    private void Start()
    {
        if (Righthand) ButtonImage = GameObject.Find("NextButton").GetComponent<Image>();
        else ButtonImage = GameObject.Find("PreviousButton").GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == gameObject.layer)
            charging = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == gameObject.layer)
            charging = false;
        currentValue = 0f;

    }

    private void OnDestroy()
    {
        ButtonImage.fillAmount = 0f;
    }

    private void Update()
    {
        if (charging) currentValue += Time.deltaTime;
        ButtonImage.fillAmount = currentValue / maxValue;

        if (currentValue >= maxValue) 
        {
            currentValue = 0f;
            if (Righthand) ModelController.getInstance().ShowNextModel();
            else ModelController.getInstance().ShowPreviousModel();

        }
    }
}
