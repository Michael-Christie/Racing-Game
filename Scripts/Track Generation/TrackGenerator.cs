﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public TrackShape Shape;

    public List<NodePoint> Nodes = new List<NodePoint>();

    public bool LoopTrack = false;

    private void Start()
    {
        GenerateAllSegments();
    }

    //Generates all road Segements
    public void GenerateAllSegments()
    {
        for (int i = 0; i < Nodes.Count - (LoopTrack ? 0 : 1); i++)
            GenerateSegement(i);
    }

    //generates a segement from the index of the node, and the next node after it
    void GenerateSegement(int nodeIndex, int resolution = 16)
    {
        //sets up the track segment game object
        GameObject newTrack = new GameObject();
        newTrack.transform.parent = transform;

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

        Mesh m = new Mesh();
        m.SetVertices(vertices.ToArray());
        m.SetTriangles(triangles.ToArray(), 0);
        m.SetColors(color.ToArray());
        m.SetNormals(normal.ToArray());

        mFilter.mesh = m;
    }

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

    private void OnDrawGizmos()
    {
        foreach (TrackShape.point point in Shape.trackPoints)
        {
            Gizmos.DrawSphere(point.location, .1f);
        }
    }

}
