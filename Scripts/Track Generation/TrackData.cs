using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackData 
{
    public string trackName = "UnNamed";
    public string creator = "Me";
    public float[] positions;
    public float[] rotations;
    public bool loop = false;

    public TrackData(List<NodePoint> nodes, string tName, string Creator, bool shouldLoop = false)
    {
        if (nodes.Count == 0)
            return;

        positions = new float[nodes.Count * 3];
        rotations = new float[nodes.Count];

        for (int i = 0; i < nodes.Count ; i++)
        {
            positions[(i * 3)] = nodes[i].Posistion.x;
            positions[(i * 3) + 1] = nodes[i].Posistion.y;
            positions[(i * 3) + 2] = nodes[i].Posistion.z;

            rotations[i] = nodes[i].Rotation.y;
        }

        loop = shouldLoop;
        trackName = tName;
        creator = Creator;
    }
}
