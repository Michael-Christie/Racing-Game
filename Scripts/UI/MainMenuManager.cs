using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Title Cards")]
    public GameObject Hub;
    public GameObject PNotes;

    [Header("Main Menu")]
    public GameObject GameTitle;
    public GameObject StartGameObj;
    public GameObject CreateTrackObj;
    public GameObject PatchNotes;
    public GameObject Options;
    public GameObject Controls;
    public GameObject Credit;
    public GameObject Exit;
    public GameObject[] SocialMedia;

    [Header("Patch Notes")]
    public GameObject[] tiles;
    public GameObject PatchNotesTitle;

    public void SinglePlayer() => StartCoroutine("StartSinglePlayer");
    public void MultiPlayer() => SceneManager.LoadScene(1);
    public void TrackCreator() => StartCoroutine("StartTrackCreator");
    //public void Options() => SceneManager.LoadScene(3);
    //public void Credit() => SceneManager.LoadScene(4);
    public void GoToPatchNotes() => ShowPatchNotes();
    public void GoToHome() => ShowHomeScreen();
    public void Quit() => Application.Quit();
    public void ItchLink() => StartCoroutine("OpenItchLink");
    public void TwitterLink() => StartCoroutine("OpenTwitterLink");
    public void YouTubeLink() => StartCoroutine("OpenYouTubeLink");

    bool firstLoad = true;

    IEnumerator StartSinglePlayer()
    {
        LeanTween.scale(StartGameObj, new Vector3(.95f, .95f, .95f), .1f);
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(1);
    }
    IEnumerator StartTrackCreator()
    {
        LeanTween.scale(CreateTrackObj, new Vector3(.95f, .95f, .95f), .1f);
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(2);
    }
    IEnumerator OpenItchLink()
    {
        LeanTween.scale(SocialMedia[0], new Vector3(.95f, .95f, .95f), .1f);
        yield return new WaitForSeconds(.1f);
        Application.OpenURL("https://michaelchristie.itch.io/");
        LeanTween.scale(SocialMedia[0], new Vector3(1, 1, 1), .1f);
    }
    IEnumerator OpenTwitterLink()
    {
        LeanTween.scale(SocialMedia[1], new Vector3(.95f, .95f, .95f), .1f);
        yield return new WaitForSeconds(.1f);
        Application.OpenURL("https://twitter.com/MichaelChriste");
        LeanTween.scale(SocialMedia[1], new Vector3(1, 1, 1), .1f);
    }
    IEnumerator OpenYouTubeLink()
    {
        LeanTween.scale(SocialMedia[2], new Vector3(.95f, .95f, .95f), .1f);
        yield return new WaitForSeconds(.1f);
        Application.OpenURL("https://www.youtube.com/channel/UC_dZHq-CFXhZscvtVP2pZCA/featured?view_as=subscriber");
        LeanTween.scale(SocialMedia[2], new Vector3(1, 1, 1), .1f);
    }

    public void Awake()
    {
        ShowHomeScreen();
    }

    void ShowHomeScreen()
    {
        if (firstLoad)
        {
            Hub.SetActive(true);
            PNotes.SetActive(false);
        }

        LeanTween.scale(tiles[4], new Vector3(.95f, .95f, .95f), .1f);
        LeanTween.scale(GameTitle, new Vector3(0, 0, 0), 0);
        LeanTween.scale(StartGameObj, new Vector3(0, 0, 0), 0);
        LeanTween.scale(CreateTrackObj, new Vector3(0, 0, 0), 0);
        LeanTween.scale(PatchNotes, new Vector3(0, 0, 0), 0);
        LeanTween.scale(Options, new Vector3(0, 0, 0), 0);
        LeanTween.scale(Controls, new Vector3(0, 0, 0), 0);
        LeanTween.scale(Credit, new Vector3(0, 0, 0), 0);
        LeanTween.scale(Exit, new Vector3(0, 0, 0), 0);
        if(firstLoad)
            foreach (GameObject g in SocialMedia)
                LeanTween.scale(g, new Vector3(0, 0, 0), 0);

        StartCoroutine("IntroAnimations");
    }

    IEnumerator IntroAnimations()
    {
        yield return new WaitForSeconds(.2f);
        Hub.SetActive(true);
        PNotes.SetActive(false);
        LeanTween.scale(GameTitle, new Vector3(1, 1, 1), 1f).setEaseOutBounce();
        LeanTween.scale(StartGameObj, new Vector3(1, 1, 1), .15f);
        yield return new WaitForSeconds(.1f);
        LeanTween.scale(CreateTrackObj, new Vector3(1, 1, 1), .15f);
        yield return new WaitForSeconds(.1f);
        LeanTween.scale(PatchNotes, new Vector3(1, 1, 1), .15f);
        yield return new WaitForSeconds(.1f);
        LeanTween.scale(Options, new Vector3(1, 1, 1), .15f);
        yield return new WaitForSeconds(.1f);
        LeanTween.scale(Controls, new Vector3(1, 1, 1), .15f);
        yield return new WaitForSeconds(.1f);
        LeanTween.scale(Credit, new Vector3(1, 1, 1), .15f);
        yield return new WaitForSeconds(.1f);
        LeanTween.scale(Exit, new Vector3(1, 1, 1), .15f);
        yield return new WaitForSeconds(.1f);
        if (firstLoad)
        {
            foreach (GameObject g in SocialMedia)
                LeanTween.scale(g, new Vector3(1, 1, 1), .15f);
            firstLoad = false;
        }
    }

    void ShowPatchNotes()
    {
        LeanTween.scale(PatchNotes, new Vector3(.95f, .95f, .95f), .1f);
        LeanTween.scale(PatchNotesTitle, new Vector3(0, 0, 0), 0).setEaseOutBounce();
        foreach (GameObject g in tiles)
        {
            LeanTween.scale(g, new Vector3(0, 0, 0), 0);
        }

        StartCoroutine("PatchNotesAnimation");
    }

    IEnumerator PatchNotesAnimation()
    {
        yield return new WaitForSeconds(.2f);
        PNotes.SetActive(true);
        Hub.SetActive(false);
        LeanTween.scale(PatchNotesTitle, new Vector3(1, 1, 1), 1f).setEaseOutBounce();
        foreach(GameObject g in tiles)
        {
            LeanTween.scale(g, new Vector3(1, 1, 1), .15f);
            yield return new WaitForSeconds(.1f);
        }

    }

}
