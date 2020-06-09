using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour
{
    public NodeManager NM;
    public TrackGenerator TG;

    public GameObject Menu;
    public GameObject selectedObject;

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

    public void ShowMenu()
    {
        Time.timeScale = 0;
        Menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(selectedObject);
    }

    public void HideMenu()
    {
        FindObjectOfType<CarController>().inMenu = false;
        Time.timeScale = 1;
        Menu.SetActive(false);

    }
}
