using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Create : MonoBehaviour
{
    public TrackGenerator TG;

    // Update is called once per frame
    void Update()
    {
        //adds a new road segment
        if (Input.GetMouseButtonDown(0))
        {
            AddPoint();
        }

        //moves the player around

        //zooms in and out
    }

    void AddPoint()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 9));
        Debug.Log(newPos);
        TG.AddNewNode(newPos);
    }

    void Zoom()
    {

    }
}
