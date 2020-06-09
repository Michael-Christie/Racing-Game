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
    public Vector2 movementConfineBox;

    public bool inMenu = false;

    private void Start()
    {
        //Cursor.visible = false;

        // optional place it in the center on start
        cursorPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        //Cursor.lockState = CursorLockMode.Locked;        

        Zoom();


    }

    private void OnGUI()
    {
        if (!inMenu)
        {
            Vector2 d = GetCursorPos();
            // these are not actual positions but the change between last frame and now
            //float h = 200 * d.x * Time.deltaTime;
            cursorPosition.x += d.x /*+ Screen.width / 2*/;
            cursorPosition.y += d.y /*+ Screen.height / 2*/;
            //float v = 200 * d.y * Time.deltaTime;

            if (cursorPosition.x > Screen.width - 10)
                cursorPosition.x = Screen.width - 10;
            if (cursorPosition.x < 0)
                cursorPosition.x = 0;

            if (cursorPosition.y > Screen.height)
                cursorPosition.y = Screen.height;
            if (cursorPosition.y < 10)
                cursorPosition.y = 10;


            // add the changes to the actual cursor position
            //if (cursorPosition.x + h < Screen.width - 10 && cursorPosition.x + h > 0)
            //    cursorPosition.x += h;
            //if (cursorPosition.y + v < Screen.height && cursorPosition.y + v > 10)
            //    cursorPosition.y += v;
        }

        GUI.DrawTexture(new Rect(cursorPosition.x, Screen.height - cursorPosition.y, 10, 10), cursorImage);
    }

   // bool addNode;

    public enum zoomLevel
    {
        x1 = 1,
        x2,
        x3,
        x4,
    }

    public zoomLevel ZoomLevel;

    public enum GridSize{
     Gridx1 = 1,
     Gridx2 = 2,
     Gridx4 = 4

    }

    public GridSize gridSize;

    private void OnEnable()
    {
        if(controls == null)
            controls = new Controlls();
        controls.TrackCreating.Enable();
    }

    private void OnDisable()
    {
        controls.TrackCreating.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (controls.TrackCreating.Start.triggered)
        {
            inMenu = !inMenu;
            if (inMenu)
                FindObjectOfType<TrackUIManager>().ShowMenu();
            else
                FindObjectOfType<TrackUIManager>().HideMenu();
        }

        if (!inMenu)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            //adds a new road segment
            if (controls.TrackCreating.PlaceNode.triggered && !MovingObject)
            {
                AddPoint();
                //addNode = false;
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
            ray.origin = new Vector3(RoundTo(ray.origin.x, (15f / 4) * (int)gridSize), RoundTo(ray.origin.y, 1), RoundTo(ray.origin.z, (15f / 4) * (int)gridSize));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, nodeLayer))
            {
                NodePoint p = hit.collider.gameObject.GetComponent<NodePoint>();

                if (!p.LockedNode)
                {

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

                }

                //rotating the nodes around
                if (controls.TrackCreating.RotateRight.triggered)
                {
                    NodeManager.instance.Rotate(p.GetComponent<NodePoint>(), true);
                }

                if (controls.TrackCreating.RotateLeft.triggered)
                {
                    NodeManager.instance.Rotate(p.GetComponent<NodePoint>(), false);
                }

                if (controls.TrackCreating.Delete.triggered)
                {
                    NodeManager.instance.RemoveNode(p.GetComponent<NodePoint>());
                }

            }

            //moving a nodes position
            if (MovingObject)
            {
                Vector3 newPos = Camera.main.ScreenToWorldPoint((Vector3)cursorPosition + new Vector3(0, 0, Camera.main.transform.position.y - 1));
                newPos = new Vector3(RoundTo(newPos.x, (15f / 4) * (int)gridSize), RoundTo(newPos.y, 1), RoundTo(newPos.z, (15f / 4) * (int)gridSize));
                //MovingObject.transform.position = newPos;
                NodeManager.instance.UpdateNode(MovingObject.GetComponent<NodePoint>(), newPos);
            }

            if (controls.TrackCreating.TempReorder.triggered)
            {
                if (MovingObject)
                    NodeManager.instance.ReOrder(MovingObject.GetComponent<NodePoint>(), (int)controls.TrackCreating.TempReorder.ReadValue<float>());
            }

            if (controls.TrackCreating.ToogleLoop.triggered)
            {
                TG.ToggleLoop();
            }
        }
        else
        {
            //we're in the menu
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    

    private void FixedUpdate()
    {
        if (!inMenu)
        {
            Vector2 pm = controls.TrackCreating.Move.ReadValue<Vector2>();
            //moves the player around
            Vector3 dir = new Vector3(pm.x, 0, pm.y).normalized;
            if ((dir + transform.position).x <= movementConfineBox.x && (dir + transform.position).x >= -movementConfineBox.x && (dir + transform.position).z <= movementConfineBox.y && (dir + transform.position).z >= -movementConfineBox.y)
                transform.Translate(dir, Space.World);
        }
    }

    Vector3 GetCursorPos() { return controls.TrackCreating.Cursor.ReadValue<Vector2>(); }

    public void AddPoint()
    {
        //adds a new node point to the Track Generator
        Vector3 newPos = Camera.main.ScreenToWorldPoint((Vector3)cursorPosition + new Vector3(0, 0, Camera.main.transform.position.y - 1));
        newPos = new Vector3(RoundTo(newPos.x, (15f / 4) * (int)gridSize), RoundTo(newPos.y, 1), RoundTo(newPos.z, (15f / 4) * (int)gridSize));
        NodeManager.instance.AddNewNode(newPos);
    }

    float RoundTo(float value, float roundValue = 10)
    {
        float v = value / roundValue;
        int i = Mathf.RoundToInt(v);
        return i * roundValue;
    }

    //changes the zoom level, needs a lerp to smooth it out!
    void Zoom() { Camera.main.orthographicSize = 10 + ((int)ZoomLevel * 10f); } 
}
