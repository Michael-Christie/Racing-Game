using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataOntoStaticTrack : MonoBehaviour
{
    public StaticTracks t;
    public string FileName;

    public void Start()
    {
        if(t)
            t.trackInfo = LoadData.LoadTrack(FileName);

        Debug.Log("Loaded");
    }
}
