using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceController : GeneralController
{
    static VoiceController _instance = null;

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> keywords = new Dictionary<string, System.Action>();

    public static VoiceController get_Instance()
    {
        return _instance;
    }

    private void Start()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);

        SetupRecognizedWords();

        Deactivate();
    }

    #region: Setup
    void SetupRecognizedWords()
    {
        if (Application.systemLanguage == SystemLanguage.Italian)
        {
            keywords.Add("Assistente", Activate);
            keywords.Add("Spegni", Deactivate);
            keywords.Add("Guarda qui", Rotate);

            keywords.Add("Comincia la presentazione", StartPresentation);

            keywords.Add("Modello successivo", NextModel);
            keywords.Add("Prossimo modello", NextModel);
            keywords.Add("Modello precedente", PreviousModel);

            keywords.Add("Dettaglio successivo", NextDetail);
            keywords.Add("Prossimo dettaglio", NextDetail);
            keywords.Add("Dettaglio precedente", PreviousDetail);

            keywords.Add("Riproduci la descrizione", PlayAudioDescription);
            keywords.Add("Interrompi la descrizione", StopAudioDescription);

            keywords.Add("Apri il menù", OpenMenu);
            keywords.Add("Mostra il menù", OpenMenu);
            keywords.Add("Chiudi il menù", CloseMenu);
        }
        else if (Application.systemLanguage == SystemLanguage.English) 
        {
            keywords.Add("Assistant", Activate);
            keywords.Add("Turn off", Deactivate);
            keywords.Add("Face here", Rotate);

            keywords.Add("Start presentation", StartPresentation);
            keywords.Add("Next model", NextModel);
            keywords.Add("Previous model", PreviousModel);
            keywords.Add("Next detail", NextDetail);
            keywords.Add("Previous detaill", PreviousDetail);

            keywords.Add("Play Description", PlayAudioDescription);
            keywords.Add("Stop Description", StopAudioDescription);

            keywords.Add("Open menu", OpenMenu);
            keywords.Add("Show menu", OpenMenu);
            keywords.Add("Close menu", CloseMenu);
        }

        AddListItems();

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
    }

    private void AddListItems() 
    {
        for (int i = 0; i < transform.GetChild(0).childCount - 1; i++) 
        {
            int current = i;
            if (Application.systemLanguage == SystemLanguage.Italian)
            {
                Debug.Log("Added" + transform.GetChild(0).GetChild(i + 1).gameObject.name + ", with ID " + (current + 1));
                keywords.Add(transform.GetChild(0).GetChild(i + 1).gameObject.name, () => { SetItem(current + 1); });
            }
            else if (Application.systemLanguage == SystemLanguage.English)
            {
                keywords.Add(transform.GetChild(0).GetChild(i + 1).gameObject.name, () => { SetItem(current + 1); });
            }
        }
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    public void StartListening()
    {
        keywordRecognizer.Start();
        listening = true;
    }

    public void StopListening()
    {
        keywordRecognizer.Stop();
        listening = false;
    }
    #endregion
}
