using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickerUIManager : MonoBehaviour
{
    public GameObject Pre;
    public GameObject Custom;

    public void BuiltInMaps()
    {
        Custom.SetActive(false);
        Pre.SetActive(true);
    }

    public void CustomMaps()
    {
        Pre.SetActive(false);
        Custom.SetActive(true);
    }
}
