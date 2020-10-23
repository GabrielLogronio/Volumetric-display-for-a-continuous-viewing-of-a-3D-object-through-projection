using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

// Save the user gameobject and follows it
public class UserPositionManager : MonoBehaviour
{
    // Setup to work with only 1 User
    static UserPositionManager _instance = null;

    int currentUsersNumber = 0, maxConcurrentUsers = 1;

    bool started = false;

    Vector3 CurrentDirection;

    [SerializeField]
    GameObject SetupCanvas, HologramCanvas;

    [SerializeField]
    InputField text;

    GameObject userHead;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);

        ModelController.getInstance().hideModel();

    }

    public static UserPositionManager getInstance() 
    {
        return _instance;
    }

    public void AddUser(GameObject toFollow) 
    {
        if (currentUsersNumber < maxConcurrentUsers) 
        {
            userHead = toFollow;
            currentUsersNumber++;

            if (started) 
            {
                toFollow.GetComponent<UserPositionUpdater>().SetPosition(transform.position);
            }
        }
        else Debug.Log("Too many users, maximum is set to 6");
    }

    public void RemoveUser()
    {
        if (currentUsersNumber > 0) 
        {
            userHead = null;
            currentUsersNumber--;
        }
        else Debug.Log("Negative users");
    }

    public void PrintPosition() 
    {
        Debug.Log(userHead.transform.position.x + " / " + userHead.transform.position.z);
    }

    public void StartAlexa() 
    {
        AlexaController.getInstance().StartListening();
        SetCenter();
    }

    public void StartGesture() 
    {
        GestureController.getInstance().StartListening();
        SetCenter();
    }

    void SetCenter() 
    {
        float inputNumber = float.Parse(text.text, CultureInfo.InvariantCulture);
        inputNumber *= 10;
        if (inputNumber >= 0 )
        {
            //VoiceController.getInstance().StartListening();
            transform.position = new Vector3(0f, 0f, inputNumber);
            started = true;

            //ModelController.getInstance().gameObject.GetComponent<AlexaController>().enabled = true;

            SetupCanvas.SetActive(false);
            HologramCanvas.SetActive(true);
        }
        if (currentUsersNumber == 1) 
        {
            userHead.GetComponent<UserPositionUpdater>().SetPosition(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentUsersNumber == maxConcurrentUsers && started) 
        {
            CurrentDirection = new Vector3(userHead.transform.position.x - transform.position.x, 0f, userHead.transform.position.z - transform.position.z).normalized;
            transform.LookAt(transform.position - CurrentDirection);

            // CurrentDirection = new Vector3(userHead.transform.position.x - transform.position.x, 0f, userHead.transform.position.z - transform.position.z).normalized;
            // transform.LookAt(transform.position + CurrentDirection);

        }
    }

    public Vector3 getUserDirection() 
    {
        return CurrentDirection;
    }
}
