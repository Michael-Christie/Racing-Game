using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrackUIManager : MonoBehaviour
{
    public NodeManager NM;
    public InputField TrackName;
    public InputField CreatorName;

    [Header("Menus")]
    public GameObject Menu;
    public GameObject CloseMenu;
    public GameObject SaveLevel;

    public void ShowMenu()
    {
        Menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(CloseMenu);
    }

    public void HideMenu()
    {
        Menu.SetActive(false);
        FindObjectOfType<PC_Create>().inMenu = false;
    }

    public void ShowSave()
    {
        Menu.SetActive(false);
        SaveLevel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(TrackName.gameObject);
    }

    public void SaveTrack()
    {
        string filename = TrackName.text;
        string creatorName = CreatorName.text;

        if (filename.Contains(" "))
        {
            Debug.Log("White Spaces Not Allowed");
            return;
        }
        Debug.Log("Saved Data");
        SaveData.SaveTrackData(NM, filename, creatorName);

        Menu.SetActive(true);
        SaveLevel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(CloseMenu);
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
