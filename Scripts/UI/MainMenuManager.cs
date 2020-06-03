using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject GameTitle;
    public GameObject StartGameObj;
    public GameObject CreateTrackObj;
    public GameObject PatchNotes;
    public GameObject Options;
    public GameObject Controls;
    public GameObject Credit;
    public GameObject Exit;
    public GameObject[] SocialMedia; 

    public void SinglePlayer() => StartCoroutine("StartSinglePlayer");
    public void MultiPlayer() => SceneManager.LoadScene(1);
    public void TrackCreator() => StartCoroutine("StartTrackCreator");
    //public void Options() => SceneManager.LoadScene(3);
    //public void Credit() => SceneManager.LoadScene(4);
    public void Quit() => Application.Quit();
    public void ItchLink() => StartCoroutine("OpenItchLink");
    public void TwitterLink() => StartCoroutine("OpenTwitterLink");

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
        LeanTween.moveLocalY(GameTitle, 720, 0);
        LeanTween.scale(StartGameObj, new Vector3(0, 0, 0), 0);
        LeanTween.scale(CreateTrackObj, new Vector3(0, 0, 0), 0);
        LeanTween.scale(PatchNotes, new Vector3(0, 0, 0), 0);
        LeanTween.scale(Options, new Vector3(0, 0, 0), 0);
        LeanTween.scale(Controls, new Vector3(0, 0, 0), 0);
        LeanTween.scale(Credit, new Vector3(0, 0, 0), 0);
        LeanTween.scale(Exit, new Vector3(0, 0, 0), 0);
        foreach (GameObject g in SocialMedia)
            LeanTween.scale(g, new Vector3(0, 0, 0), 0);

        StartCoroutine(IntroAnimations());
    }

    IEnumerator IntroAnimations()
    {
        yield return new WaitForSeconds(.25f);
        LeanTween.moveLocalY(GameTitle, 540, .5f).setEaseOutBounce();
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
        foreach (GameObject g in SocialMedia)
            LeanTween.scale(g, new Vector3(1, 1, 1), .15f);
    }

}
