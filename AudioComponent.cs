using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioComponent : MonoBehaviour
{
    public bool isMusic;
    float MaxVolume = 1;
    public bool FadeIn;
    AudioSource AS;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    private void Start()
    {

        if (isMusic)
            MaxVolume = Options.current.GetMusic;
        else
            MaxVolume = Options.current.GetSound;

        AS.volume = (FadeIn) ? 0 : MaxVolume;
    }

    public void StartFade(float t)
    {
        LeanTween.value(gameObject, fadeIn, 0, MaxVolume, t);
    }

    private void fadeIn(float i_Value)
    {
        AS.volume = i_Value;
    }

    public void fadeOut(float t)
    {
        LeanTween.value(gameObject, fadeIn, MaxVolume, 0, t);
    }


}
