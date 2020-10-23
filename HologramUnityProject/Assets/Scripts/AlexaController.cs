using Amazon;
using Amazon.DynamoDBv2.Model;
using AmazonsAlexa.Unity.AlexaCommunicationModule;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AlexaController : GeneralController
{
    string publishKey = "pub-c-d856715d-d10d-439d-913c-b47010f6f5c8",
        subscribeKey = "sub-c-a2d434c2-d70f-11ea-bd4f-26a7cd4b6ab5",
        identityPoolId = "eu-west-2:6967b604-bd6f-419b-b16e-eaccc1be72b8",
        AWSRegion = RegionEndpoint.EUWest2.SystemName;

    static AlexaController instance = null;

    Dictionary<string, Dictionary<string, string>> messagesLocalization;

    [SerializeField]
    string channel = "NGENO",
        tableName = "PeppersAssistant";
    bool debug = true;

    private AmazonAlexaManager alexaManager;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            UnityInitializer.AttachToGameObject(gameObject);
            AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
            alexaManager = new AmazonAlexaManager(publishKey, subscribeKey, channel, tableName, identityPoolId, AWSRegion, this.gameObject, OnAlexaMessage, null, debug);

            InitializeLocalization();

        }
        else Destroy(this);
    }

    public static AlexaController getInstance() 
    {
        return instance;
    }

    void InitializeLocalization() 
    {
        Dictionary<string, string> stringsIT = new Dictionary<string, string>();
        stringsIT.Add("obj", "oggetto");
        stringsIT.Add("det", "dettaglio");
        stringsIT.Add("opn", "apri");
        stringsIT.Add("cls", "chiudi");
        stringsIT.Add("ply", "riproduci");
        stringsIT.Add("pau", "interrompi");

        Dictionary<string, string> stringsEN = new Dictionary<string, string>();
        stringsEN.Add("obj", "object");
        stringsEN.Add("det", "detail");
        stringsEN.Add("opn", "open");
        stringsEN.Add("cls", "close");
        stringsEN.Add("ply", "play");
        stringsEN.Add("pau", "pause");

        messagesLocalization = new Dictionary<string, Dictionary<string, string>>();
        messagesLocalization.Add("en", stringsEN);
        messagesLocalization.Add("it", stringsIT);
    }

    //Callback for when a message from Alexa is recieved
    public void OnAlexaMessage(HandleMessageEventData eventData)
    {
        if (listening) 
        {
            Dictionary<string, object> message = eventData.Message;

            Debug.Log("Received message: " + message["message"] + ", of type: " + message["type"]);
            string responseText = "";

            switch (message["type"])
            {
                case "AlexaID":
                    SelectLanguage((message["message"] as string).Substring(0, 2));                    
                    alexaManager.alexaUserDynamoKey = (message["message"] as string).Substring(2);
                    responseText = "Conn";
                    string objectsCatalogue = "";
                    for (int i = 1; i < ModelController.getInstance().transform.GetChild(0).childCount; i++)
                    {
                        objectsCatalogue += "|" + ModelController.getInstance().transform.GetChild(0).GetChild(i).GetComponent<TitleLocalizer>().getString(language);
                    }
                    SendMessageToAlexa("text", responseText + objectsCatalogue.Substring(1));
                    break;
                case "Start":
                    StartPresentation();
                    CloseMenu();
                    SendMessageToAlexa("text", "Objc" + transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetComponent<TitleLocalizer>().getString(language));
                    break;
                case "Skip":
                    CloseMenu();
                    for (int i = 1; i < ModelController.getInstance().transform.GetChild(0).childCount; i++)
                    {
                        if (transform.GetChild(0).GetChild(i).GetComponent<TitleLocalizer>().getString(language).ToLower() == (message["message"] as string).ToLower())
                        {
                            SetItem(i);
                        }
                    }
                    break;
                case "Next":
                    CloseMenu();
                    if (message["message"] as string == messagesLocalization[language]["obj"])
                    {
                        NextModel();
                        if (ModelController.getInstance().getCurrentModelID() == 0) 
                        {
                            responseText = "Menu";
                            for (int i = 1; i < ModelController.getInstance().transform.GetChild(0).childCount; i++)
                            {
                                responseText += "|" + ModelController.getInstance().transform.GetChild(0).GetChild(i).GetComponent<TitleLocalizer>().getString(language);
                            }
                        }
                        else
                        responseText = "Objc" + transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetComponent<TitleLocalizer>().getString(language);
                        SendMessageToAlexa("text", responseText);
                    }
                    else if (message["message"] as string == messagesLocalization[language]["det"])
                    {
                        NextDetail();
                        responseText = "Detl" + transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetChild(ModelController.getInstance().getCurrentDetailID()).GetComponent<TitleLocalizer>().getString(language);
                        SendMessageToAlexa("text", responseText);
                    }
                    break;
                case "Prev":
                    CloseMenu();
                    if (message["message"] as string == messagesLocalization[language]["obj"])
                    {
                        PreviousModel();
                        if (ModelController.getInstance().getCurrentModelID() == 0)
                        {
                            responseText = "Menu";
                            for (int i = 1; i < ModelController.getInstance().transform.GetChild(0).childCount; i++)
                            {
                                responseText += "|" + ModelController.getInstance().transform.GetChild(0).GetChild(i).GetComponent<TitleLocalizer>().getString(language);
                            }
                        }
                        else
                            responseText = "Objc" + transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetComponent<TitleLocalizer>().getString(language);
                        SendMessageToAlexa("text", responseText);

                    }
                    else if (message["message"] as string == messagesLocalization[language]["det"])
                    {
                        PreviousDetail();
                        responseText = "Detl" + transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetChild(ModelController.getInstance().getCurrentDetailID()).GetComponent<TitleLocalizer>().getString(language);
                        SendMessageToAlexa("text", responseText);
                    }
                    break;
                case "Asnt":
                    Activate();
                    break;
                case "Menu":
                    if (message["message"] as string == messagesLocalization[language]["opn"])
                    {
                        OpenMenu();

                    }
                    else if (message["message"] as string == messagesLocalization[language]["cls"])
                    {
                        CloseMenu();
                    }
                    break;
                case "Desc":
                    if (message["message"] as string == messagesLocalization[language]["ply"])
                    {
                        responseText = "Desc" + transform.GetChild(0).GetChild(ModelController.getInstance().getCurrentModelID()).GetChild(ModelController.getInstance().getCurrentDetailID())
                            .gameObject.GetComponent<DescriptionLocalizer>().getString(language);
                        SendMessageToAlexa("text", responseText);
                    }
                    else if (message["message"] as string == messagesLocalization[language]["pau"])
                    {

                    }
                    break;
                case "Gest":
                    if (message["message"] as string == "true")
                    {
                        responseText = "Gesto";
                        SendMessageToAlexa("text", responseText);
                    }
                    else if (message["message"] as string == messagesLocalization[language]["pau"])
                    {

                    }
                    break;
            }
        }
    }

    public void SendMessageToAlexa(string type, string message)
    {
        Dictionary<string, string> messageToAlexa = new Dictionary<string, string>();
        messageToAlexa.Add(type, message);

        Debug.Log("Sent message: " + message + ", of type: " + type);
        alexaManager.SendToAlexaSkill(messageToAlexa, OnMessageSent);

    }

    public void OnMessageSent(MessageSentEventData eventData)
    {
        if (eventData.IsError)
            Debug.LogError(eventData.Exception.Message);
    }
}