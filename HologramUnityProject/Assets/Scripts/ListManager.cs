using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListManager : MonoBehaviour
{
    static ListManager _instance = null;
    [SerializeField]
    GameObject menuItemListPrefab;

    private void Start()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
    }

    public static ListManager getInstance() 
    {
        return _instance;
    }

    public void InitializeList(string language) 
    {
        for (int i = 0; i < transform.GetChild(0).childCount - 1; i++)
        {
            GameObject newListItem = Instantiate(menuItemListPrefab);
            newListItem.transform.GetChild(0).GetComponent<MenuGestureButton>().setString("o" + i);
            newListItem.transform.GetChild(2).GetComponent<Text>().text = (i + 1) + ". " + transform.GetChild(0).GetChild(i + 1).GetComponent<TitleLocalizer>().getString(language);
            newListItem.transform.position = new Vector3(0, - (i * 0.5f), 1f);
            newListItem.transform.SetParent(transform.GetChild(1).GetChild(0));

        }
    }

}
