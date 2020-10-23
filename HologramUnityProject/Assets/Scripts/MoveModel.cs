using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Used for testing, move the hologram up / down
public class MoveModel : MonoBehaviour
{
    [SerializeField]
    float speed = 25f, size = 0.01f;

    public Text text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.up * speed);

        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.up * speed);

        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            transform.localScale = transform.localScale + new Vector3(size, size, size);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = transform.localScale - new Vector3(size, size, size);

        }

        text.text = "1. position: " + transform.position.y + "\n2. scale: " + transform.localScale.x;

    }
}
