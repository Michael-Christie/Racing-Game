using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickerUIManager : MonoBehaviour
{
    public GameObject Pre;
    public GameObject Custom;

    public void BuiltInMaps()
    {
        if (Pre.activeInHierarchy)
            return;
        Custom.SetActive(false);
        Pre.SetActive(true);

        FindObjectOfType<MainMenuManager>().BLevels();
    }

    public void CustomMaps()
    {
        if (Custom.activeInHierarchy)
            return;
        Pre.SetActive(false);
        Custom.SetActive(true);

        FindObjectOfType<MainMenuManager>().CLevels();
    }
}
