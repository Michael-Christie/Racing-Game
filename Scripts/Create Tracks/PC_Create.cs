using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Create : MonoBehaviour
{
    public TrackGenerator TG;
    public LayerMask nodeLayer;

    public GameObject MovingObject = null;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddPoint();
        }
        //zooms in and out
        Zoom();

        //finds out if we're hovering over a node
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, nodeLayer))
        {
            Debug.Log(hit.collider.gameObject);
            NodePoint p = hit.collider.gameObject.GetComponent<NodePoint>();

            //if we select the node to move it
            if (Input.GetMouseButtonDown(0))
            {
                p.Select(true);
                MovingObject = p.gameObject;
            }

            //when we deselect a node
            if (Input.GetMouseButtonUp(0) && p.isSelected)
            {
                p.Select(false);
                MovingObject = null;
            }

            //rotating the nodes around
            if (Input.GetKeyDown(KeyCode.E))
            {
                p.GetComponent<NodePoint>().RotateRight();
                TG.UpdateNode(p);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                p.GetComponent<NodePoint>().RotateLeft();
                TG.UpdateNode(p);
            }
        }

        //moving a nodes position
        if (MovingObject)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.transform.position.y - 1));
            newPos = new Vector3(Mathf.RoundToInt(newPos.x), Mathf.RoundToInt(newPos.y), Mathf.RoundToInt(newPos.z));
            MovingObject.transform.position = newPos;
            TG.UpdateNode(MovingObject.GetComponent<NodePoint>());
        }

    }

    private void FixedUpdate()
    {
        //moves the player around
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.Translate(dir, Space.World);
    }

    void AddPoint()
    {
        //adds a new node point to the Track Generator
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.transform.position.y - 1));
        newPos = new Vector3(Mathf.RoundToInt(newPos.x), Mathf.RoundToInt(newPos.y), Mathf.RoundToInt(newPos.z));
        TG.AddNewNode(newPos);
    }


    void Zoom()
    {
        //changes the zoom level, needs a lerp to smooth it out!
        transform.position = new Vector3(transform.position.x, (int)ZoomLevel * 10f, transform.position.z);
    }
}
