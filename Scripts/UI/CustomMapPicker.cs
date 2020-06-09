﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomMapPicker : MonoBehaviour
{
    public GameObject CustomCard;
    public RectTransform rt;

    private void OnEnable()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        FindAllFiles();
    }

    void FindAllFiles()
    {
        MainMenuManager MMM = FindObjectOfType<MainMenuManager>();
        if (MMM)
        {
            MMM.CustomTiles = new List<GameObject>();
            string path;
            if (Application.isEditor)
                path = Application.dataPath + "/../Build/Maps/";
            else
                path = Application.dataPath + "/../Maps/";

            var info = new DirectoryInfo(path);
            var fileInfo = info.GetFiles("*.td");

            foreach (FileInfo f in fileInfo)
            {
                GameObject g = Instantiate(CustomCard, this.transform);

                Debug.Log(f.Name);
                TrackData d = LoadData.LoadTrack(f.Name);

                TrackSelectorCard c = g.GetComponent<TrackSelectorCard>();
                c.d = d;

                MMM.CustomTiles.Add(g);
            }
            float h = (fileInfo.Length / 3) <= 3 ? 3 * 250 : (fileInfo.Length / 3) * 250;
            rt.sizeDelta = new Vector2(1500, h);


        }

    }
}
