using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputUISwitch : MonoBehaviour
{
    public GameObject[] JoypadUIElements;
    public GameObject[] KeyboardUIElements;


    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.GetPlayerByIndex(0).currentControlScheme == "JoyPad")
        {
            foreach (GameObject g in JoypadUIElements)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in KeyboardUIElements)
            {
                g.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject g in JoypadUIElements)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in KeyboardUIElements)
            {
                g.SetActive(true);
            }
        }
    }
}
