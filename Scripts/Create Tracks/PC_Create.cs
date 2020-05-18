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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, nodeLayer))
        {
            Debug.Log(hit.collider.gameObject);
            NodePoint p = hit.collider.gameObject.GetComponent<NodePoint>();
            if (Input.GetMouseButtonDown(0))
            {
                p.Select(true);
                MovingObject = p.gameObject;
            }

            if (Input.GetMouseButtonUp(0) && p.isSelected)
            {
                p.Select(false);
                MovingObject = null;
            }
        }

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
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.transform.position.y - 1));
        newPos = new Vector3(Mathf.RoundToInt(newPos.x), Mathf.RoundToInt(newPos.y), Mathf.RoundToInt(newPos.z));
        TG.AddNewNode(newPos);
    }

    void MovePoint()
    {

    }

    void Zoom()
    {
        transform.position = new Vector3(transform.position.x, (int)ZoomLevel * 10f, transform.position.z);
    }
}
