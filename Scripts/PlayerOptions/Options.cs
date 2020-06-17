using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    //singleton
    public static Options current;

    private void Awake()
    {
        if (current == null)
            current = this;
        else
            DestroyImmediate(gameObject);

    }

    private void Start()
    {
        Init();

        DontDestroyOnLoad(gameObject);
    }

    //variables
    float MusicVolume = 1;
    float SoundVolume = 1;
    float Sensitivity = 2.5f;

    public float GetSensitity => Sensitivity; 
    public float GetMusic => MusicVolume; 
    public float GetSound => SoundVolume; 

    public enum Language
    {
        English,
        French,
        Developer
    }
    public Language language = Language.English;
    public Dictionary<string, string> localisedEN;
    public Dictionary<string, string> localisedFR;
    public Dictionary<string, string> localisedDev;
    public static bool isInit;

    public void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedFR = csvLoader.GetDictionaryValues("fr");
        localisedDev = csvLoader.GetDictionaryValues("dev");

        isInit = true;
    }


    public void SetLanguage(int v)
    {
        language = (Language)v;
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
            case Language.Developer:
                localisedDev.TryGetValue(Key, out value);
                break;
        }
        return value;
    }

    public void changeMusicVolume(float v)
    {
        MusicVolume = v;
    }

    public void changeSFXVolume(float v)
    {
        SoundVolume = v;
    }

    public void changeSensitivity(float v)
    {
        Sensitivity = v * .5f;
    }

    
}
