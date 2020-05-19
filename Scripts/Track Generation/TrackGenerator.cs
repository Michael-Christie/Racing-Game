using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public TrackShape Shape;
    public GameObject Node;

    public List<NodePoint> Nodes = new List<NodePoint>();

    public bool LoopTrack = false;

    GameObject tracks;
    GameObject points;

    public Material TrackMaterial;

    public List<GameObject> trackSegements = new List<GameObject>();

    private void Start()
    {
        //sets up the track and point empty game object for readability
        tracks = new GameObject();
        tracks.transform.parent = transform;
        tracks.name = "Tracks";
        points = new GameObject();
        points.transform.parent = transform;
        points.name = "Points";
        GenerateAllSegments();
    }

    //Generates all road Segements
    public void GenerateAllSegments()
    {
        //makes sure they'res more then two tack sections
        if (Nodes.Count < 2)
            return;

        for (int i = 0; i < Nodes.Count - (LoopTrack ? 0 : 1); i++)
            GenerateSegement(i);
    }

    //generates a segement from the index of the node, and the next node after it
    void GenerateSegement(int nodeIndex, int resolution = 16)
    {
        //sets up the track segment game object
        GameObject newTrack = new GameObject();
        newTrack.transform.parent = tracks.transform;

        MeshFilter mFilter = newTrack.AddComponent<MeshFilter>();
        MeshRenderer mRenderer = newTrack.AddComponent<MeshRenderer>();

        //the mesh data
        List<Vector3> vertices = new List<Vector3>();
        List<Vector3> normal = new List<Vector3>();
        List<Color> color = new List<Color>();
        List<int> triangles = new List<int>();

        //for the resolution of the road
        for (int i = 0; i <= resolution; i++)
        {
            int shapeLength = Shape.trackPoints.Count;
            //get the bezier curve point and rotation
            float t = (float)i / resolution;
            OrientedBezier ob;

            ob = GetOrientedBezierData(Nodes[nodeIndex], Nodes[(nodeIndex + 1) % Nodes.Count], t);

            //add the verticies of the track at the bezier point
            for (int j = 0; j < shapeLength; j++)
            {
                vertices.Add(ob.position + ob.rotation * Shape.trackPoints[j].location);
                color.Add(Shape.trackPoints[j].color);
            }
            //set up the triangles
            if (i != resolution)
            {
                for (int j = 0; j < Shape.triangles.Count; j += 2)
                {
                    triangles.Add(Shape.triangles[j + 1] + (shapeLength * i));
                    triangles.Add(Shape.triangles[j] + (shapeLength * i));
                    triangles.Add(Shape.triangles[j] + (shapeLength * (i + 1)));

                    triangles.Add(Shape.triangles[j] + (shapeLength * (i + 1)));
                    triangles.Add(Shape.triangles[j + 1] + (shapeLength * (i + 1)));
                    triangles.Add(Shape.triangles[j + 1] + (shapeLength * i));
                }
            }
        }

        //applies it to the mesh filter
        Mesh m = new Mesh();
        m.SetVertices(vertices.ToArray());
        m.SetTriangles(triangles.ToArray(), 0);
        m.SetColors(color.ToArray());
        m.SetNormals(normal.ToArray());

        mFilter.mesh = m;

        //assigns the track material **TEMPORARY MATERIAL I NEED A NEW ONE WITH SPECTUAL LIGHTS
        mRenderer.material = TrackMaterial;

        //adds it to the list of track sections for later use
        trackSegements.Insert(nodeIndex, newTrack);
    }

    //returns the point location and orientation of the point
    OrientedBezier GetOrientedBezierData(NodePoint a, NodePoint b, float t)
    {
        OrientedBezier OB = new OrientedBezier();

        Vector3 p1 = Vector3.Lerp(a.Posistion, a.Forward, t);
        Vector3 p2 = Vector3.Lerp(a.Forward, b.Back, t);
        Vector3 p3 = Vector3.Lerp(b.Back, b.Posistion, t);

        Vector3 p4 = Vector3.Lerp(p1, p2, t);
        Vector3 p5 = Vector3.Lerp(p2, p3, t);

        OB.position = Vector3.Lerp(p4, p5, t);
        OB.rotation = Quaternion.LookRotation((p5 - p4).normalized, Vector3.up);

        return OB;
    }

    struct OrientedBezier
    {
        public Quaternion rotation;
        public Vector3 position;
    }

    //adds a new node at location 
    public void AddNewNode(Vector3 pos)
    {
        GameObject g = Instantiate(Node);
        g.transform.position = pos;
        
        //calculates the direction of the point from the forward position of the last node to the new node
        if (Nodes.Count > 0)
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
            g.transform.rotation = Quaternion.Euler(new Vector3(0,iy,0));
        }

        g.transform.parent = points.transform;

        Nodes.Add(g.GetComponent<NodePoint>());
        
        ///**THIS SHOULD BE UPDATING ONLY THE NEW MESHES NOT ALL OF THEM
        DeleteAllSegments();
        GenerateAllSegments();
    }

    public void RemoveNode(int nodeIndex)
    {

    }

    //updates a mesh based upon a node
    public void UpdateNode(NodePoint NP)
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
            if(Nodes[i] == NP)
            {
                if ((i != Nodes.Count - 1) || (LoopTrack && i == Nodes.Count - 1))
                {
                    DeleteSegment(i);
                    GenerateSegement(i);
                }

                if (i != 0)
                {
                    DeleteSegment(i - 1);
                    GenerateSegement(i - 1);
                }

                if (LoopTrack && i == 0)
                {
                    DeleteSegment(trackSegements.Count - 1);
                    GenerateSegement(Nodes.Count - 1);
                }

            }
        }
    }

    public void DeleteAllSegments()
    {
        for (int i = tracks.transform.childCount - 1; i >= 0; i--)
            DestroyImmediate(tracks.transform.GetChild(i).gameObject);
        trackSegements.Clear();
    }

    public void DeleteSegment(int i)
    {
        GameObject g = trackSegements[i];
        trackSegements.RemoveAt(i);
        DestroyImmediate(g);
    }
}
