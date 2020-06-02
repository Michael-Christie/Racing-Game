using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public NodeManager NM;
    public TrackGenerator TG;

    private void Start()
    {
        TrackData d = LoadData.LoadTrack();

        NM.clearNM();
        NM.TG.LoopTrack = d.loop;

        for (int i = 0; i < d.rotations.Length; i++)
        {
            Vector3 pos = new Vector3(d.positions[i * 3], d.positions[(i * 3) + 1], d.positions[(i * 3) + 2]);
            NM.AddNewNode(pos, false, d.rotations[i]);
        }

       

    }
}
