using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackUIManager : MonoBehaviour
{
    public NodeManager NM;

    public void SaveTrack()
    {
        Debug.Log("Saved Data");
        SaveData.SaveTrackData(NM);
    }

    public void LoadTrack()
    {
        Debug.Log("Loaded Data");
        TrackData d = LoadData.LoadTrack();

        NM.clearNM();

        Debug.Log(d.rotations.Length);

        for (int i = 0; i < d.rotations.Length; i ++)
        {
            Vector3 pos = new Vector3(d.positions[i * 3], d.positions[(i * 3) + 1], d.positions[(i * 3) + 2]);
            NM.AddNewNode(pos, false, d.rotations[i]);
        }

        NM.TG.LoopTrack = d.loop;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
