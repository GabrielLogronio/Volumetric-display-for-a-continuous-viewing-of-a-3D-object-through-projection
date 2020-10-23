using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GalleryManager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayGalleryButton, CreateGalleryButton;

    public void PlayGalleryPressed() 
    {
        SceneManager.LoadScene(1);

    }

    public void CreateGalleryPressed() 
    {
        SceneManager.LoadScene(2);

    }

}
