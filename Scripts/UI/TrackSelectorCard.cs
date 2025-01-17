﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrackSelectorCard : MonoBehaviour
{
    [Header("Automatic Cards")]
    public Image image;
    public TextMeshProUGUI trackTitle;
    public TextMeshProUGUI creator;
    public TrackData d;

    [Header("Manual Cards")]
    public bool CreateManually = false;
    public StaticTracks TD;

    private void Start()
    {
        if (CreateManually && TD)
            d = TD.trackInfo;
    }

    void UpdateGUI()
    {
        if (d.trackName == "")
            return;

        trackTitle.text = d.trackName;
        creator.text = d.creator;
    }

    private void Update()
    {
        UpdateGUI();
    }

    public void LoadLevel()
    {
        MainMenuManager m = FindObjectOfType<MainMenuManager>();
        if (m)
            m.LoadLevel(d);
        else
        {
            FindObjectOfType<TrackUIManager>().LoadTrack(d);
        }
    }
}
