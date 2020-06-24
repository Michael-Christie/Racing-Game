using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public AudioClip buttonPress;
    AudioSource AS;
    Button b;
    // Start is called before the first frame update
    void Start()
    {
        AS = gameObject.AddComponent<AudioSource>();
        b = GetComponent<Button>();
        b.onClick.AddListener(onPress);
    }

    private void Update()
    {
        AS.volume = Options.current.GetSound;
    }

    private void onPress()
    {
        AS.PlayOneShot(buttonPress);
    }

}
