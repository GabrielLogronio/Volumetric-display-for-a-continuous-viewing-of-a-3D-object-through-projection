using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LocalisationStrings : MonoBehaviour
{
    [Serializable]
    public struct localisedDescription
    {
        public string language;
        public string description;
    }
    [SerializeField]
    localisedDescription[] descriptions = new localisedDescription[2];

    public string getString(string selectedLanguage) 
    {
        foreach (localisedDescription desc in descriptions) 
        {
            if (desc.language == selectedLanguage) return desc.description;
        }
        return "Err";
    }

}
