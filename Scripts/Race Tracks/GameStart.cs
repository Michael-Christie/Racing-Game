using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GameStart : MonoBehaviour
{
    public NodeManager NM;
    public TrackGenerator TG;

    public GameObject Menu;
    public GameObject selectedObject;
    public GameObject GameOver;

    public GameObject player;

    [Header("Count Down")]
    public TextMeshProUGUI CountdownElement;
    public string[] text;

    [Header("Laps")]
    public TextMeshProUGUI currentLap;
    public TextMeshProUGUI totalLaps;
    public int playerLap = 0;
    public int overallLaps = 3;

    [Header("Timer")]
    bool ActiveTimer = false;
    public TextMeshProUGUI timer;
    public float currentTime = 0;
    public float fastestLapTime = Mathf.Infinity;
    public float overallTime = 0;

    [Space]
    List<BoxCollider> Tracker = new List<BoxCollider>();
    int currentTrackerID = 1;
    int maxID = 1;

    [Header("Game Over")]
    public TextMeshProUGUI fasterTime;
    public TextMeshProUGUI TotalCourseTime;

    [Header("Loading")]
    public Slider loadingSlider;
    public int maxValue;
    public int currentvalue = 0;
    public CanvasGroup loadingCanvas;

    private void Start()
    {
        GenerateTrack();
        UpdateLapUI();
        StartCoroutine(Envioment.instance.CreateLandscape(250, 250));
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

                GameObject box = new GameObject();
                box.transform.parent = transform;
                box.transform.position = pos;
                box.transform.rotation = Quaternion.Euler(0, d.rotations[i], 0);

                BoxCollider b = box.AddComponent<BoxCollider>();

                b.size = new Vector3(10, 10, 1);
                b.isTrigger = true;

                Tracker.Add(b);

                box.AddComponent<LapTriggers>().ID = i;
            }

            maxID = d.rotations.Length;

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

    public void ResetCar()
    {
        //fade out
        Destroy(FindObjectOfType<CarController>().transform.parent.gameObject);
        Instantiate(player, new Vector3(0, 2, 3), Quaternion.identity);
        //updates timer
        ActiveTimer = false;
        currentTime = 0;
        fastestLapTime = Mathf.Infinity;
        overallTime = 0;
        timer.text = ConvertTime(currentTime);
        GameOver.SetActive(false);
        //updates laps 
        playerLap = 0;
        UpdateLapUI();
        //fade in
        //countdown
        StartCoroutine(CountDown(5));
    }

    public void RaceOver()
    {
        GameOver.SetActive(true);
        fasterTime.text = ConvertTime(fastestLapTime);
        TotalCourseTime.text = ConvertTime(overallTime);
    }

    public IEnumerator CountDown(float totalTime = 5)
    {
        LockInput();
        LeanTween.scale(CountdownElement.gameObject, Vector3.zero, 0);
        LeanTween.scale(timer.gameObject, Vector3.zero, 0);

        yield return new WaitForSeconds(2);

        float sectionTime = totalTime / 3;
        for (int i = 0; i < text.Length; i++)
        {
            CountdownElement.text = text[i];
            if (i == text.Length - 1)
                UnlockInput();
            LeanTween.scale(CountdownElement.gameObject, Vector3.one, sectionTime * .5f).setEaseOutElastic();
            FindObjectOfType<StartingLights>().changeOneLight();
            yield return new WaitForSeconds(sectionTime * .6f);

            LeanTween.scale(CountdownElement.gameObject, Vector3.zero, sectionTime * .3f);
            yield return new WaitForSeconds(sectionTime * .4f);

        }

        yield return new WaitForSeconds(.5f);
        LeanTween.scale(timer.gameObject, Vector3.one, .5f).setEaseOutElastic();

    }

    public void LockInput()
    {
        ActiveTimer = false;
        CarController[] controlls = FindObjectsOfType<CarController>();

        foreach(CarController c in controlls)
        {
            c.Disable();
        }
    }

    public void UnlockInput()
    {
        ActiveTimer = true;
        CarController[] controlls = FindObjectsOfType<CarController>();

        foreach (CarController c in controlls)
        {
            c.Enable();
        }
    }

    void UpdateLapUI()
    {
        currentLap.text = (playerLap + 1).ToString();
        totalLaps.text = overallLaps.ToString();
    }

    void AddLap()
    {
        playerLap++;

        overallTime += currentTime;
        if (playerLap < overallLaps)
        {
            UpdateLapUI();
            ResetTimer();
        }
        else
        {
            ActiveTimer = false;
            RaceOver();
            Debug.Log("Game Over?");
            LockInput();
        }


    }

    public void Update()
    {
        if (ActiveTimer)
        {
            currentTime += Time.deltaTime;
            timer.text = ConvertTime(currentTime);
        }
    }

    string ConvertTime(float t)
    {
        int minuets;
        int seconds;
        int milaseconds;

        minuets = (int)t / 60;
        seconds = (int)t % 60;
        milaseconds = (int)((t - (int)t) * 1000);

        return minuets.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0') + ":" + milaseconds.ToString().PadLeft(3,'0');
    }

    void ResetTimer()
    {
        if (currentTime < fastestLapTime)
            fastestLapTime = currentTime;

        currentTime = 0;
    }

    public void boxHit(int ID)
    {
        Debug.Log(ID);
        Debug.Log(currentTrackerID);

        if(ID == 0 && currentTrackerID == 0)
        {
            AddLap();
        }

        if(ID == currentTrackerID)
        {
            currentTrackerID++;
        }
        else if(Mathf.Abs(ID - currentTrackerID) < 3)
        {
            currentTrackerID += Mathf.Abs(ID - currentTrackerID);
            if(currentTrackerID > maxID)
            {
                currentTrackerID = currentTrackerID % maxID;
                AddLap();
            }
        }

        if (currentTrackerID == maxID)
            currentTrackerID = 0;
    }

    public void UpdateLoadingValue(int v)
    {
        currentvalue += v;
        loadingSlider.value = currentvalue / (float)maxValue;

        if(currentvalue == maxValue)
        {
            LeanTween.alphaCanvas(loadingCanvas, 0, 1f);

            StartCoroutine(CountDown(5));
        }
    }
}
