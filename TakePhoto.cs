﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakePhoto : MonoBehaviour
{
    public string fileName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            ScreenCapture.CaptureScreenshot(fileName + ".png");
        }
    }
}
