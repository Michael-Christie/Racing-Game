using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public static NodeManager instance;
    public TrackGenerator TG;
    const float minDist = 14f;

    private void Awake()
    {
        //sets up singleton
        if (instance == null)
            instance = this;
        if (instance != this)
            Destroy(this);

        TG = FindObjectOfType<TrackGenerator>();
    }

    public List<NodePoint> Nodes = new List<NodePoint>();

    public void ReOrder(NodePoint N, int Dir)
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
            if (Nodes[i] == N)
            {
                if ((i + Dir) >= 0 && (i + Dir) < Nodes.Count)
                {
                    Debug.Log(Dir + " " + i);
                    NodePoint temp = Nodes[i];
                    Nodes.RemoveAt(i);
                    Nodes.Insert((i + Dir), temp);

                    TG.DeleteAllSegments();
                    TG.GenerateAllSegments();

                    return;
                }
            }
        }
    }

    //updates a mesh based upon a node
    public void UpdateNode(NodePoint NP, Vector3 pos)
    {
        //makes sure nodes are far enough away from each other
        foreach (NodePoint n in Nodes)
        {
            if (NP == n)
                continue;

            if ((pos - n.Posistion).magnitude < minDist)
            {
                Debug.Log("Too Close");
                return;
            }
        }

        //makes sure a node is in front of the current node
        int index = Nodes.IndexOf(NP);

        ///THIS NEEDS TO CHANGE TO INCLUDE WRAPPING FOR LOOPED TRACKS
        if (index != 0)
        {
            Vector3 direction = (pos - Nodes[index - 1].Posistion).normalized;
            //find the forward vector of the last node
            Vector3 forward = Nodes[index - 1].transform.forward;
            //if the direction > forward vector?
            float angle = Vector3.Dot(direction, forward);
            Debug.Log(angle);
            if (angle < -.01f)
                return;

        }

        //need to add code to limit the angle it can be turned.

        NP.SetPosition(pos);

        for (int i = 0; i < Nodes.Count; i++)
        {
            if (Nodes[i] == NP)
            {
                if ((i != Nodes.Count - 1) || (TG.LoopTrack && i == Nodes.Count - 1))
                {
                    TG.DeleteSegment(i);
                    TG.GenerateSegement(i);
                }

                if (i != 0)
                {
                    TG.DeleteSegment(i - 1);
                    TG.GenerateSegement(i - 1);
                }

                if (TG.LoopTrack && i == 0)
                {
                    TG.DeleteSegment(TG.trackSegements.Count - 1);
                    TG.GenerateSegement(Nodes.Count - 1);
                }

            }
        }
    }

    //adds a new node at location 
    public void AddNewNode(Vector3 pos, bool calculateRotation = true, float rotation = 0)
    {
        //for each nodes, make sure its x amount away from it?
        foreach (NodePoint n in Nodes)
        {
            if ((pos - n.Posistion).magnitude < minDist)
                return;
        }
        //check the node direction
        //work out the direction of the new node from the old one
        if (Nodes.Count > 0)
        {
            Vector3 direction = (pos - Nodes[Nodes.Count - 1].Posistion).normalized;
            //find the forward vector of the last node
            Vector3 forward = Nodes[Nodes.Count - 1].transform.forward;
            //if the direction > forward vector?
            float angle = Vector3.Dot(direction, forward);
            Debug.Log(angle);
            if (angle < -.01f)
                return;

        }



        GameObject g = Instantiate(TG.Node);
        g.transform.position = pos;

        //calculates the direction of the point from the forward position of the last node to the new node
        if (Nodes.Count > 0)
        {
            if (calculateRotation)
            {
                //pos back = last index.forward + pos * .5f
                Vector3 backpos = (Nodes[Nodes.Count - 1].Forward + pos) * .5f;
                g.transform.LookAt(pos * 2 - backpos, Vector3.up);
                float y = g.transform.rotation.eulerAngles.y;

                //clamps the angle to the nearest 15 degrees
                y /= 15;
                int iy = Mathf.RoundToInt(y);
                iy *= 15;
                //applies the rotation
                g.transform.rotation = Quaternion.Euler(new Vector3(0, iy, 0));
            }
            else
            {
                g.transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
            }

        }

        g.transform.parent = TG.points.transform;

        Nodes.Add(g.GetComponent<NodePoint>());

        ///**THIS SHOULD BE UPDATING ONLY THE NEW MESHES NOT ALL OF THEM
        TG.DeleteAllSegments();
        TG.GenerateAllSegments();
    }

    public void RemoveNode(int nodeIndex)
    {
        GameObject n = Nodes[nodeIndex].gameObject;
        Nodes.RemoveAt(nodeIndex);
        Destroy(n);
        ///**THIS SHOULD BE UPDATING ONLY THE NEW MESHES NOT ALL OF THEM
        TG.DeleteAllSegments();
        TG.GenerateAllSegments();
    }

    public void RemoveNode(NodePoint node)
    {
        Debug.Log("Destroying Node");

        for (int i = 0; i < Nodes.Count; i++)
        {
            if(Nodes[i] == node)
            {
                Nodes.RemoveAt(i);
                Destroy(node.gameObject);
                ///**THIS SHOULD BE UPDATING ONLY THE NEW MESHES NOT ALL OF THEM
                TG.DeleteAllSegments();
                TG.GenerateAllSegments();
                return;
            }
        }

        Debug.Log("Couldn't find node");
    }

    public void Rotate(NodePoint node, bool rotateRight)
    {
        //add some kinda restaint in here for the angle it can rotate to

        if (rotateRight)
            node.RotateRight();
        else
            node.RotateLeft();

        UpdateNode(node, node.Posistion);
    }

    public void clearNM()
    {
        for (int i = Nodes.Count - 1; i >= 0; i--)
        {
            RemoveNode(i);
        }
    }

}
