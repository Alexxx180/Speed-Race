using System.IO;
using static System.Convert;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CurrentStats;

public class Leaders : MonoBehaviour
{
    public Text playerNames;
    public Text playerScores;

    public Text playerName;
    public Text playerScore;

    public Text money;
    public List<Text> bonuses;

    private const string _fileName = "/Resources/Records.txt";
    private string _fullName;

    private void Awake()
    {
        string directory = Application.dataPath;
        _fullName = directory + _fileName;
    }

    // Read text file line by line  
    private List<string> ReadFromTextFile()
    {
        List<string> lines = new List<string>();
        try
        {
            using (StreamReader reader = new StreamReader(_fullName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    if (line.Length > 0)
                        lines.Add(line);
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
        for (byte i = 0; i < records.Count; i++)
            fullRecord += $"{records[i]}\n";
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
        WriteTextFile(playerName.text, ToInt32(playerScore.text));
    }

    // Recover score spaces
    private string ScoreTrim2(string record)
    {
        if (record.LastIndexOf(".") + 1 >= record.Length)
            return "0";
        return record.Substring(record.LastIndexOf(".") + 1);
    }

    // Recover score spaces
    private string ScoreRecover(string record)
    {
        record = "." + record;
        while (record.Length < 11)
            record = ". " + record;
        return record;
    }

    // Join records from two lists into one records list
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

    // Split records to two lists
    private List<List<string>> SplitRecords(List<string> records)
    {
        List<List<string>> records2 = new List<List<string>>();
        records2.Add(new List<string>());
        records2.Add(new List<string>());
        int count = records.Count;
        for (int i = 0; i < count; i += 2)
            records2[0].Add(records[i]);
        for (int i = 1; i < count; i += 2)
            records2[1].Add(records[i]);
        return records2;
    }

    // Write record into text file
    private void WriteTextFile(string name, int score)
    {
        List<string> records = ReadFromTextFile();
        List<List<string>> records2 = SplitRecords(records);
        try
        {
            bool success = false;
            int count = Mathf.Min(records2[0].Count, records2[1].Count);
            for (byte i = 0; i < count; i++)
            {
                string playerScore = ScoreTrim2(records2[1][i]);
                int compareScore = ToInt32(playerScore);

                if (!success && score > compareScore)
                {
                    success = true;
                    records2[0][i] = name.Length <= 0 ? "???" : name;
                    records2[1][i] = ScoreRecover(score.ToString());
                }
            }
            File.WriteAllLines(_fullName, JoinRecords(records2[0], records2[1]));
        }
        catch (IOException exp)
        {
            throw exp;
        }
        
        Score = 0;
        Coins = 0;
        money.text = Coins.ToString();
        playerScore.text = Score.ToString();

        for(byte i = 0; i < bonuses.Count; i++)
        {
            string bonusName = BonusNames[i];
            Inventory[bonusName] = 0;
            bonuses[i].text = Inventory[bonusName].ToString();
        }
    }
}
