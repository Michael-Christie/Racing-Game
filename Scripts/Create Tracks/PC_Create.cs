using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Create : MonoBehaviour
{
    public TrackGenerator TG;
    public LayerMask nodeLayer;

    public GameObject MovingObject = null;

    private Controlls controls = null;

    bool addNode;

    public enum zoomLevel
    {
        x1,
        x2,
        x3,
        x4,
    }

    public zoomLevel ZoomLevel;

    private void OnEnable()
    {
        controls = new Controlls();
        controls.TrackCreating.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //adds a new road segment
        if (controls.TrackCreating.PlaceNode.triggered)
        { 
            AddPoint();
            addNode = false;
        }

        //zooms in and out
        Zoom();

        //finds out if we're hovering over a node
        Ray ray = Camera.main.ScreenPointToRay(GetCursorPos());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, nodeLayer))
        {
            Debug.Log(hit.collider.gameObject);
            NodePoint p = hit.collider.gameObject.GetComponent<NodePoint>();

            //if we select the node to move it
            if (controls.TrackCreating.Drag.triggered && !p.isSelected)
            {
                Debug.Log("hm");
                p.Select(true);
                MovingObject = p.gameObject;
            }
            //when we deselect a node
            else if (controls.TrackCreating.Drag.triggered && p.isSelected)
            {
                p.Select(false);
                MovingObject = null;
            }

            //rotating the nodes around
            if (controls.TrackCreating.RotateRight.triggered)
            {
                p.GetComponent<NodePoint>().RotateRight();
                TG.UpdateNode(p);
            }

            if (controls.TrackCreating.RotateLeft.triggered)
            {
                p.GetComponent<NodePoint>().RotateLeft();
                TG.UpdateNode(p);
            }
        }

        //moving a nodes position
        if (MovingObject)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(GetCursorPos() + new Vector3(0, 0, Camera.main.transform.position.y - 1));
            newPos = new Vector3(Mathf.RoundToInt(newPos.x), Mathf.RoundToInt(newPos.y), Mathf.RoundToInt(newPos.z));
            MovingObject.transform.position = newPos;
            TG.UpdateNode(MovingObject.GetComponent<NodePoint>());
        }

    }

    private void FixedUpdate()
    {
        Vector2 pm = controls.TrackCreating.Move.ReadValue<Vector2>();
        //moves the player around
        Vector3 dir = new Vector3(pm.x,0, pm.y).normalized;
        transform.Translate(dir, Space.World);
    }

    Vector3 GetCursorPos()
    {
        Vector3 d = controls.TrackCreating.Cursor.ReadValue<Vector2>();

        return d;
    }

    public void AddPoint()
    {
        //adds a new node point to the Track Generator
        Vector3 newPos = Camera.main.ScreenToWorldPoint(GetCursorPos() + new Vector3(0, 0, Camera.main.transform.position.y - 1));
        newPos = new Vector3(Mathf.RoundToInt(newPos.x), Mathf.RoundToInt(newPos.y), Mathf.RoundToInt(newPos.z));
        TG.AddNewNode(newPos);
    }


    void Zoom()
    {
        //changes the zoom level, needs a lerp to smooth it out!
        transform.position = new Vector3(transform.position.x, (int)ZoomLevel * 10f, transform.position.z);
    }
}
