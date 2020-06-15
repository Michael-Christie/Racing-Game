using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public NodeManager NM;
    public TrackGenerator TG;

    public GameObject Menu;
    public GameObject selectedObject;

    [Header("Count Down")]
    public Text CountdownElement;
    public string[] text;

    private void Start()
    {
        GenerateTrack();
        LockInput();
        StartCoroutine(CountDown(5));
    }

    void GenerateTrack()
    {
        
        LevelData LD = FindObjectOfType<LevelData>();
        if (LD)
        {
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

    public IEnumerator CountDown(float totalTime)
    {
        LeanTween.scale(CountdownElement.gameObject, Vector3.zero, 0);

        yield return new WaitForSeconds(2);

        float sectionTime = totalTime / 3;
        for (int i = 0; i < text.Length; i++)
        {
            CountdownElement.text = text[i];
            if (i == text.Length - 1)
                UnlockInput();
            LeanTween.scale(CountdownElement.gameObject, Vector3.one, sectionTime * .5f).setEaseOutElastic();
            yield return new WaitForSeconds(sectionTime * .6f);

            LeanTween.scale(CountdownElement.gameObject, Vector3.zero, sectionTime * .3f);
            yield return new WaitForSeconds(sectionTime * .4f);

        }
    }

    public void LockInput()
    {
        CarController[] controlls = FindObjectsOfType<CarController>();

        foreach(CarController c in controlls)
        {
            c.Disable();
        }
    }

    public void UnlockInput()
    {
        CarController[] controlls = FindObjectsOfType<CarController>();

        foreach (CarController c in controlls)
        {
            c.Enable();
        }
    }


}
