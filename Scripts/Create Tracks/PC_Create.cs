using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PC_Create : MonoBehaviour
{
    public TrackGenerator TG;
    public LayerMask nodeLayer;

    public GameObject MovingObject = null;

    private Controlls controls = null;

    private Vector2 cursorPosition;
    public Texture cursorImage;

    private void Start()
    {
        Cursor.visible = false;

        // optional place it in the center on start
        cursorPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnGUI()
    {
        Vector2 d = GetCursorPos();
        // these are not actual positions but the change between last frame and now
        float h = 200 * d.x * Time.deltaTime;
        float v = 200 * d.y * Time.deltaTime;

        // add the changes to the actual cursor position
        if(cursorPosition.x + h < Screen.width - 10 && cursorPosition.x + h > 0)
            cursorPosition.x += h;
        if (cursorPosition.y + v < Screen.height && cursorPosition.y + v > 10)
            cursorPosition.y += v;

        GUI.DrawTexture(new Rect(cursorPosition.x, Screen.height - cursorPosition.y, 10, 10), cursorImage);
    }

    bool addNode;

    public enum zoomLevel
    {
        x1 = 1,
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
        if (controls.TrackCreating.PlaceNode.triggered && !MovingObject)
        { 
            AddPoint();
            addNode = false;
        }

        //zooms in and out
        if (controls.TrackCreating.Zoom.triggered)
        {
            int value = (int)controls.TrackCreating.Zoom.ReadValue<float>();
            if ((int)ZoomLevel + value <= 4 && (int)ZoomLevel + value >= 1)
            {
                ZoomLevel = ZoomLevel + value;
                Zoom();
            }
        }


        //finds out if we're hovering over a node
        Ray ray = Camera.main.ScreenPointToRay(cursorPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, nodeLayer))
        {
            NodePoint p = hit.collider.gameObject.GetComponent<NodePoint>();

            //if we select the node to move it
            if (controls.TrackCreating.Drag.triggered && !p.isSelected)
            {
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
            Vector3 newPos = Camera.main.ScreenToWorldPoint((Vector3)cursorPosition + new Vector3(0, 0, Camera.main.transform.position.y - 1));
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

    Vector3 GetCursorPos() { return controls.TrackCreating.Cursor.ReadValue<Vector2>(); }

    public void AddPoint()
    {
        //adds a new node point to the Track Generator
        Vector3 newPos = Camera.main.ScreenToWorldPoint((Vector3)cursorPosition + new Vector3(0, 0, Camera.main.transform.position.y - 1));
        newPos = new Vector3(Mathf.RoundToInt(newPos.x), Mathf.RoundToInt(newPos.y), Mathf.RoundToInt(newPos.z));
        TG.AddNewNode(newPos);
    }

    //changes the zoom level, needs a lerp to smooth it out!
    void Zoom() { Camera.main.orthographicSize = (int)ZoomLevel * 10f; } 
}
