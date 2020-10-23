using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amazon;
using AmazonsAlexa.Unity.AlexaCommunicationModule;

public class CodeSnippetsForPaper : MonoBehaviour
{
    string publishKey = "pub-c-d856715d-d10d-439d-913c-b47010f6f5c8",
    subscribeKey = "sub-c-a2d434c2-d70f-11ea-bd4f-26a7cd4b6ab5",
    identityPoolId = "eu-west-2:6967b604-bd6f-419b-b16e-eaccc1be72b8",
    AWSRegion = RegionEndpoint.EUWest2.SystemName;
    string channel = "NGENO",
    tableName = "PeppersAssistant";

    private void Start()
    {
        float sen = -0.5f, cos = 0.5f;
        float angle = Mathf.Asin(sen);
        angle *= Mathf.Rad2Deg;

        (float sen, float cos) angles = (sen, cos);

        switch (angles)
        {
            case var _ when cos > 0 && sen > 0:
                angle += 0;
                break;
            case var _ when cos <= 0 && sen > 0:
                angle = 180 - angle;
                break;
            case var _ when cos <= 0 && sen <= 0:
                angle = 180 - angle;
                break;
            case var _ when cos > 0 && sen <= 0:
                angle = 360 + angle;
                break;
        }

        Debug.Log(angle);


    }

    void RotationCalculusSnippet()
    {
        Vector2 UserPosition = Vector2.zero, ScreenPosition = Vector2.zero;

        // Calculate the direction Vector
        Vector2 pointOfViewDirection = UserPosition - ScreenPosition;
        // Normalize the direction Vector
        pointOfViewDirection = pointOfViewDirection.normalized;

        // Calculate the ArcSine of the y value
        float angle = Mathf.Asin(pointOfViewDirection.y);
        // Convert from Radiants to Degrees
        angle *= Mathf.Rad2Deg;

        // Correct the angle
        switch (pointOfViewDirection) 
        {
            case var _ when pointOfViewDirection.x > 0 && pointOfViewDirection.y > 0:
                angle += 0;
                break;
            case var _ when pointOfViewDirection.x <= 0 && pointOfViewDirection.y > 0:
                angle = 180 - angle;
                break;
            case var _ when pointOfViewDirection.x <= 0 && pointOfViewDirection.y <= 0:
                angle = 180 - angle;
                break;
            case var _ when pointOfViewDirection.x > 0 && pointOfViewDirection.y <= 0:
                angle = 360 + angle;
                break;
        }




        float angleFromX = Mathf.Asin(pointOfViewDirection.x);










        float directionRatio = pointOfViewDirection.y / pointOfViewDirection.x;

        float directionAngle = Mathf.Tan(directionRatio);

        (Vector2 UserPosition, Vector2 ScreenPosition) rotationFix = (UserPosition, ScreenPosition);
        switch (rotationFix)
        {
            case var _ when UserPosition.x < 0 && ScreenPosition.x < 0:
                directionAngle += 0;
                break;
            case var _ when UserPosition.x >= 0 && ScreenPosition.x < 0:
                directionAngle += 90;
                break;
            case var _ when UserPosition.x < 0 && ScreenPosition.x >= 0:
                directionAngle += 180;
                break;
            case var _ when UserPosition.x >= 0 && ScreenPosition.x >= 0:
                directionAngle += 70;
                break;
        }

        directionRatio = directionAngle;
        directionAngle = directionRatio;
    }

    public void OnAlexaMessage(HandleMessageEventData eventData)
    {
        AmazonAlexaManager AmazonAlexaManager = new AmazonAlexaManager(publishKey, subscribeKey, channel, tableName, identityPoolId, AWSRegion, this.gameObject, OnAlexaMessage, null, true);

        Dictionary<string, object> message = eventData.Message;

        switch (message["type"] as string)
        {
            case "Skip":
                string objectToOpen = message["message"] as string;

                // Checks if the "objectToOpen" is in the catalogue, and finds it

                string responseMessage = "true",
                       responseType = "response";

                Dictionary<string, string> messageToAlexa = new Dictionary<string, string>();
                messageToAlexa.Add(responseType, responseMessage);

                AmazonAlexaManager.SendToAlexaSkill(messageToAlexa, OnMessageSent); 
                
                break;
        }
    }

    public void OnMessageSent(MessageSentEventData eventData)
    {
        if (eventData.IsError)
            Debug.LogError(eventData.Exception.Message);
    }

    void RotateObject() 
    {
        Vector2 UserPosition = Vector2.zero;

        transform.LookAt(UserPosition);
        float directionAngle = transform.localEulerAngles.y;

        directionAngle += 1;


    }
}
