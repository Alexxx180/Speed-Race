using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaders : MonoBehaviour
{
    public Text playerNames;
    public Text playerScores;

    public Text playerName;
    public Text playerScore;

    public Text money;
    public Text shield;
    public Text speedUp;
    public Text doubler;

    const string fileName = @"D:\Aleksandr\Windows-7\misc\Games\Develop\Speed-Race\Assets\Resources\Records.txt";
    private List<string> ReadFromTextFile()
    {
        List<string> lines = new List<string>();
        try
        {
            // Create a StreamReader  
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                // Read line by line  
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > 0)
                        lines.Add(line);
                }
            }
        }
        catch (IOException exp)
        {
            throw exp;
        }
        return lines;
    }

    private string SetRecord(List<string> records)
    {
        string fullRecord = "";
        int count = records.Count;
        for (byte i = 0; i < count; i++)
        {
            fullRecord += $"{records[i]}\n";
        }
        return fullRecord;
    }

    public void SetRecords()
    {
        List<string> records = ReadFromTextFile();
        List<List<string>> records2 = SplitRecords(records);
        playerNames.text = SetRecord(records2[0]);
        playerScores.text = SetRecord(records2[1]);
    }

    public void SetFileRecords()
    {
        WriteTextFile(playerName.text, Ints(playerScore.text));
    }

    private int Ints(object ob)
    {
        return Convert.ToInt32(ob);
    }

    private string ScoreTrim2(string record)
    {
        if (record.LastIndexOf(".") + 1 >= record.Length)
            return "0";
        return record.Substring(record.LastIndexOf(".") + 1);
    }

    private string ScoreRecover(string record)
    {
        record = "." + record;
        while (record.Length < 11)
            record = ". " + record;
        return record;
    }

    private List<string> JoinRecords(List<string> names, List<string> scores)
    {
        List<string> records = new List<string>();
        int count = Mathf.Min(names.Count, scores.Count);
        for (int i = 0; i < count; i++)
        {
            records.Add(names[i]);
            records.Add(scores[i]);
        }
        return records;
    }

    private List<List<string>> SplitRecords(List<string> records)
    {
        List<List<string>> records2 = new List<List<string>>();
        records2.Add(new List<string>());
        records2.Add(new List<string>());
        int count = records.Count;
        for (int i = 0; i < count; i+=2)
        {
            records2[0].Add(records[i]);
        }
        for (int i = 1; i < count; i += 2)
        {
            records2[1].Add(records[i]);
        }
        return records2;
    }

    private void WriteTextFile(string name, int score)
    {
        List<string> records = ReadFromTextFile();
        List<List<string>> records2 = SplitRecords(records);
        try
        {
            bool success = false;
            int count = Math.Min(records2[0].Count, records2[1].Count);
            for (byte i = 0; i < count; i++)
            {
                string playerScore = ScoreTrim2(records2[1][i]);
                int compareScore = Ints(playerScore);

                if (!success && score > compareScore)
                {
                    success = true;
                    records2[0][i] = name.Length <= 0 ? "???" : name;
                    records2[1][i] = ScoreRecover(score.ToString());
                }
            }
            File.WriteAllLines(fileName, JoinRecords(records2[0], records2[1]));
        }
        catch (IOException exp)
        {
            throw exp;
        }
        playerScore.text = "0";
        CurrentStats.Coins = 0;
        money.text = CurrentStats.Coins.ToString();
        CurrentStats.SpeedUp = 0;
        CurrentStats.Shields = 0;
        CurrentStats.Doubler = 0;
        shield.text = "0";
        speedUp.text = "0";
        doubler.text = "0";
    }
}
