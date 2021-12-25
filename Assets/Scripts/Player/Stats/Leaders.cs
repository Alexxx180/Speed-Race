using System.Collections.Generic;
using static System.Convert;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Leaders : MonoBehaviour
{
    public List<Text> names;
    public Text playerName;
    public Text score;
    const string fileName = "/resources/Leaders.txt";
    private string fullName;

    private void Awake()
    {
        string directory = Application.dataPath;
        fullName = directory + fileName;
    }

    // Read line by line  
    private List<string> ReadFromTextFile()
    {
        List<string> lines = new List<string>();
        try
        {
            using (StreamReader reader = new StreamReader(fullName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    lines.Add(line);
            }
        }
        catch (IOException exp)
        {
            throw exp;
        }
        return lines;
    }

    public void SetRecords()
    {
        List<string> records = ReadFromTextFile();
        int count = Mathf.Min(names.Count, records.Count);
        for (byte i = 0; i < count; i++)
            names[i].text = records[i];
    }

    public void SetFileRecords()
    {
        WriteTextFile(playerName.text, ToInt32(ScoreTrim(score.text)));
    }

    private string ScoreTrim(string record)
    {
        return record.Substring(record.LastIndexOf(" ") + 1);
    }

    // Find out the weakest player and change it to current
    private List<string> ProcessBestPlayer(List<string> records, string name, int score)
    {
        bool success = false;
        for (byte i = 0; i < records.Count; i++)
        {
            string playerScore = ScoreTrim(records[i]);
            int compareScore = ToInt32(playerScore);

            if (!success && score > compareScore)
            {
                success = score < compareScore;
                records[i] = $"{name} {score}";
            }
        }
        return records;
    }

    // Rewrite all file with best players
    private void WriteTextFile(string name, int score)
    {
        List<string> records = ReadFromTextFile();
        List<string> changed = ProcessBestPlayer(records, name, score);
        try
        {
            File.WriteAllLines(fullName, changed);
        }
        catch (IOException exp)
        {
            throw exp;
        }
    }
}
