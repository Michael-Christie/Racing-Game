using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Create : MonoBehaviour
{
    public TrackGenerator TG;

    public enum zoomLevel
    {
        x1,
        x2,
        x3,
        x4,
    }

    public zoomLevel ZoomLevel;

    // Update is called once per frame
    void Update()
    {
        //adds a new road segment
        if (Input.GetMouseButtonDown(0))
        {
            AddPoint();
        }
        //zooms in and out
        Zoom();
    }

    private void FixedUpdate()
    {
        //moves the player around
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.Translate(dir, Space.World);
    }

    void AddPoint()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.transform.position.y - 1));
        Debug.Log(newPos);
        TG.AddNewNode(newPos);
    }

    void Zoom()
    {
        transform.position = new Vector3(transform.position.x, (int)ZoomLevel * 10f, transform.position.z);
    }
}
