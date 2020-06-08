using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public NodeManager NM;
    public TrackGenerator TG;

    private void Start()
    {
        LevelData LD = FindObjectOfType<LevelData>();
        TrackData d = LD.d;

        DestroyImmediate(LD.gameObject);

        NM.clearNM();
        TG.LoopTrack = d.loop;

        for (int i = 0; i < d.rotations.Length; i++)
        {
            Vector3 pos = new Vector3(d.positions[i * 3], d.positions[(i * 3) + 1], d.positions[(i * 3) + 2]);
            NM.AddNewNode(pos, false, d.rotations[i], false);
        }

        TG.GenerateAllSegments();

       

    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
