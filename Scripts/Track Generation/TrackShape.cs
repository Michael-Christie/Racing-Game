using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TrackShape : ScriptableObject
{
    public List<point> trackPoints = new List<point>();
    public List<int> triangles = new List<int>();

    [System.Serializable]
    public struct point
    {
        public Vector3 location;
        public Vector3 normal;
        public Color color;
    }

}
