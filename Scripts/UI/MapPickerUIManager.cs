using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickerUIManager : MonoBehaviour
{
    public GameObject Pre;
    public GameObject Custom;
    ///public GameObject tempText;

    public void BuiltInMaps()
    {
        if (Pre.activeInHierarchy)
            return;
        Custom.SetActive(false);
        Pre.SetActive(true);
        //tempText.SetActive(true);

        FindObjectOfType<MainMenuManager>().BLevels();
    }

    public void CustomMaps()
    {
        if (Custom.activeInHierarchy)
            return;
        Pre.SetActive(false);
        //tempText.SetActive(false);
        Custom.SetActive(true);

        FindObjectOfType<MainMenuManager>().CLevels();
    }
}
