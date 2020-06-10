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
    public GameObject LevelSelector;

    public List<GameObject> customTiles;

    public void ShowMenu()
    {
        Menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(CloseMenu);
    }

    public void HideMenu()
    {
        Menu.SetActive(false);
        SaveLevel.SetActive(false);
        LevelSelector.SetActive(false);
        FindObjectOfType<PC_Create>().inMenu = false;
    }

    public void ShowSave()
    {
        Menu.SetActive(false);
        SaveLevel.SetActive(true);
        LevelSelector.SetActive(false);
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

    public void ShowCustomTracks()
    {
        Menu.SetActive(false);
        SaveLevel.SetActive(false);
        LevelSelector.SetActive(true);
    }

    public IEnumerator animateCustomTracks()
    {
        foreach (GameObject g in customTiles)
            LeanTween.scale(g, Vector3.zero, 0);
        EventSystem.current.SetSelectedGameObject(customTiles[0]);
        yield return new WaitForSeconds(.2f);
        foreach (GameObject g in customTiles)
        {
            LeanTween.scale(g, Vector3.one, .2f);
            yield return new WaitForSeconds(.1f);
        }
    }

    public void LoadTrack(TrackData D)
    {
        NM.LoadTrackData(D);
        HideMenu();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
