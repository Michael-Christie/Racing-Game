using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLights : MonoBehaviour
{
    public Light[] Lights;

    public Color Red;
    public Color Green;

    int currentCounter = 0;

    public void Awake()
    {
        foreach(Light l in Lights)
        {
            l.color = Red;
        }
        currentCounter = 0;
    }

    public void changeOneLight()
    {
        for (int i = 0; i < 4; i++)
        {
            if (currentCounter < i)
                Lights[i].color = Red;
            else
                Lights[i].color = Green;
        }
        currentCounter++;
    }

    public void ResetColors()
    {
        currentCounter = 0;
        for (int i = 0; i < 4; i++)
        {
            Lights[i].color = Red;
        }

    }

}
