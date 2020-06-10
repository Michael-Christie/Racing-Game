using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    //singleton
    public static Options current;

    private void Awake()
    {
        if (current == null)
            current = this;
        else
            Destroy(this);
    }

    //variables
    float MusicVolume;
    float SoundVolume;
    float Sensitivity;

    public enum Language
    {
        English,
        French
    }
    public Language language = Language.English;
    public Dictionary<string, string> localisedEN;
    public Dictionary<string, string> localisedFR;
    public static bool isInit;

    public void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedFR = csvLoader.GetDictionaryValues("fr");

        isInit = true;
    }


    public void SetLanguage()
    {

    }

    public string ReturnWord(string Key)
    {
        if (!isInit)
            Init();

        string value = Key;

        switch (language)
        {
            case Language.English:
                localisedEN.TryGetValue(Key, out value);
                break;
            case Language.French:
                localisedFR.TryGetValue(Key, out value);
                break;
        }
        return value;
    }
}
