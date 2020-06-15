using System.Collections;
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
        Debug.Log("hERE");
        MainMenuManager MMM = FindObjectOfType<MainMenuManager>();
        if (MMM)
            MMM.CustomTiles = new List<GameObject>();
        else
            FindObjectOfType<TrackUIManager>().customTiles = new List<GameObject>();

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

            //this is super messy
            if (MMM)
                MMM.CustomTiles.Add(g);
            else
                FindObjectOfType<TrackUIManager>().customTiles.Add(g);


        }
        float h = (fileInfo.Length / 3) <= 2 ? 3 * 250 : ((fileInfo.Length / 3) + (fileInfo.Length % 3 == 0 ? 0 : 1)) * 250;
        rt.sizeDelta = new Vector2(1500, h);

        if (!MMM)
        {
            StartCoroutine(FindObjectOfType<TrackUIManager>().animateCustomTracks());
        }
    }

}
