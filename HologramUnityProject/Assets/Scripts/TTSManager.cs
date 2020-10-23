using IBM.Watson.TextToSpeech.V1;
using IBM.Watson.TextToSpeech.V1.Model;
using IBM.Cloud.SDK.Utilities;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Cloud.SDK;

/* Credentials
{
  "apikey": "6_ocCnBENN5XveAQs-EvqHjPDFAnwjXwNhepeTqBXRHM",
  "iam_apikey_description": "Auto-generated for key bb27b8bd-65ae-4775-b117-677084efce18",
  "iam_apikey_name": "PeppersAssistantCredential",
  "iam_role_crn": "crn:v1:bluemix:public:iam::::serviceRole:Manager",
  "iam_serviceid_crn": "crn:v1:bluemix:public:iam-identity::a/97f4284439534887877e5303df91b8c3::serviceid:ServiceId-51de276f-b07b-41e4-a402-e3f8bde17c86",
  "url": "https://api.eu-de.text-to-speech.watson.cloud.ibm.com/instances/23ccfbd4-e010-4eb3-a03b-aaecfb2d6969"
}
*/
public class TTSManager : MonoBehaviour
{
    private string iamApikey = "6_ocCnBENN5XveAQs-EvqHjPDFAnwjXwNhepeTqBXRHM";
    private string serviceUrl = "https://api.eu-de.text-to-speech.watson.cloud.ibm.com/instances/23ccfbd4-e010-4eb3-a03b-aaecfb2d6969";
    private TextToSpeechService service;
    private string allisionVoice = "en-US_AllisonV3Voice";
    private string synthesizeText = "Hello, welcome to the Watson Unity SDK!";
    private string placeholderText = "Please type text here and press enter.";
    private string waitingText = "Watson Text to Speech service is synthesizing the audio!";
    private string synthesizeMimeType = "audio/wav";
    private bool _textEntered = false;
    private AudioClip _recording = null;
    private byte[] audioStream = null;

    static TTSManager _instance = null;

    private void Start()
    {
        LogSystem.InstallDefaultReactors();
        Runnable.Run(CreateService());

        if (_instance == null) _instance = this;
        else Destroy(this);
    }

    public static TTSManager get_Instance()
    {
        return _instance;
    }

    public void ReadText(string toRead) 
    {
        Runnable.Run(ExampleSynthesize(toRead));
    }

    private IEnumerator CreateService()
    {
        if (string.IsNullOrEmpty(iamApikey))
        {
            throw new IBMException("Please add IAM ApiKey to the Iam Apikey field in the inspector.");
        }

        IamAuthenticator authenticator = new IamAuthenticator(apikey: iamApikey);

        while (!authenticator.CanAuthenticate())
        {
            yield return null;
        }

        service = new TextToSpeechService(authenticator);
        if (!string.IsNullOrEmpty(serviceUrl))
        {
            service.SetServiceUrl(serviceUrl);
        }
    }

    private IEnumerator ExampleSynthesize(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            text = synthesizeText;
            Log.Debug("ExampleTextToSpeechV1", "Using default text, please enter your own text in dialog box!");

        }
        byte[] synthesizeResponse = null;
        AudioClip clip = null;
        service.Synthesize(
            callback: (DetailedResponse<byte[]> response, IBMError error) =>
            {
                synthesizeResponse = response.Result;
                Log.Debug("ExampleTextToSpeechV1", "Synthesize done!");
                clip = WaveFile.ParseWAV("myClip", synthesizeResponse);
                PlayClip(clip);
            },
            text: text,
            voice: allisionVoice,
            accept: synthesizeMimeType
        );

        while (synthesizeResponse == null)
            yield return null;

        yield return new WaitForSeconds(clip.length);
    }

    private void PlayClip(AudioClip clip)
    {
        if (Application.isPlaying && clip != null)
        {
            GameObject audioObject = new GameObject("AudioObject");
            AudioSource source = audioObject.AddComponent<AudioSource>();
            source.spatialBlend = 0.0f;
            source.loop = false;
            source.clip = clip;
            source.Play();

            GameObject.Destroy(audioObject, clip.length);
        }
    }

}