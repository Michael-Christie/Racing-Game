using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void SaveTrackData(NodeManager nm, string FileName, string Creator = "me")
    {
        if (nm.Nodes.Count == 0)
            return;

        BinaryFormatter formatter = new BinaryFormatter();
        string path;
        if (Application.isEditor)
            path = Application.dataPath + "/../Build/Maps/" + FileName + ".td";
        else
            path = Application.dataPath + "/../Maps/" + FileName + ".td";

        FileStream stream = new FileStream(path, FileMode.Create);

        TrackData data = new TrackData(nm.Nodes, FileName, Creator, nm.TG.LoopTrack);

        formatter.Serialize(stream, data);
        stream.Close();
    }

}
