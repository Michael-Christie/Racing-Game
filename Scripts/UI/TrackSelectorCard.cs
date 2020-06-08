using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelectorCard : MonoBehaviour
{
    [Header("Automatic Cards")]
    public Image image;
    public Text trackTitle;
    public Text creator;
    public TrackData d;

    [Header("Manual Cards")]
    public bool CreateManually = false;

    void UpdateGUI()
    {
        
        if (d.trackName == "" || CreateManually)
            return;
        trackTitle.text = d.trackName;
        creator.text = d.creator;
    }

    private void Update()
    {
        UpdateGUI();
    }
}
