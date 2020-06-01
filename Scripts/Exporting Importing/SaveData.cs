using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void SaveTrackData(NodeManager nm)
    {
        if (nm.Nodes.Count == 0)
            return;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = "../Maps.td";
        FileStream stream = new FileStream(path, FileMode.Create);

        TrackData data = new TrackData(nm.Nodes, nm.TG.LoopTrack);

        formatter.Serialize(stream, data);
        stream.Close();
    }

}
