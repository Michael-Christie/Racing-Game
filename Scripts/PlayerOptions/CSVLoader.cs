using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVLoader
{
    private TextAsset csvFile;
    private char lineSeperator = '\n';
    private char surround = '"';
    private string[] fieldSeperator = {","};

    public void LoadCSV()
    {
        csvFile = Resources.Load<TextAsset>("localisation");
    }

    public Dictionary<string, string> GetDictionaryValues(string ID)
    {
        Dictionary<string, string> dictionairy = new Dictionary<string, string>();
        Debug.Log(csvFile.text);
        string[] lines = csvFile.text.Split(lineSeperator);

        int index = -1;

        string[] headers = lines[0].Split(fieldSeperator, StringSplitOptions.None);

        for (int i = 0; i < headers.Length; i++)
        {
            if (headers[i].Contains(ID))
            {
                index = i;
                break;
            }
        }

        Debug.Log(index);

        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] fields = CSVParser.Split(line);

            for (int f = 0; f < fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', surround);
                fields[f] = fields[f].TrimEnd(surround);
            }

            if(fields.Length > index)
            {
                var key = fields[0];

                if (dictionairy.ContainsKey(key))
                {
                    continue;
                }
                var value = fields[index];
                //Debug.Log(value);
                dictionairy.Add(key, value);
            }
        }

        return dictionairy;
    }
}
