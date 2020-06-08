using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class LoadData
{
    public static TrackData LoadTrack(string FileName = "maps")
    {
        string path;

        if (Application.isEditor)
            path = Application.dataPath + "/../Build/Maps/" + FileName;
        else
            path = Application.dataPath + "/../Maps/" + FileName;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TrackData data = formatter.Deserialize(stream) as TrackData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
