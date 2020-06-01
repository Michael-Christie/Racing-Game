using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void SinglePlayer() => SceneManager.LoadScene(1);
    public void MultiPlayer() => SceneManager.LoadScene(1);
    public void TrackCreator() => SceneManager.LoadScene(2);
    //public void Options() => SceneManager.LoadScene(3);
    //public void Credit() => SceneManager.LoadScene(4);
    public void Quit() => Application.Quit();
}
