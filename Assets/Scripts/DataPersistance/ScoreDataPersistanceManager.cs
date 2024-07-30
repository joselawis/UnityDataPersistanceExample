using Assets.Lawis.DataPersistance;
using System;
public class ScoreDataPersistanceManager : DataPersistanceManager<ScoreRecord, ScoreDataPersistanceManager>
{
    private ScoreRecord currentRecord;

    protected override void Awake()
    {
        base.Awake();
        currentData = new ScoreRecord();
    }
    public void SetCurrentName(string name)
    {
        currentData.Name = name;
    }

    public void SetCurrentScore(int score)
    {
        currentData.Score = score;
    }

    public void SaveData()
    {
        DataToJson(currentData);
        currentRecord = new ScoreRecord(
            currentData.Name,
            currentData.Score
        );
        UnityEngine.Debug.Log("Data saved!");
    }

    public ScoreRecord GetCurrentRecord()
    {
        try
        {
            currentRecord ??= LoadDataFromJson();
            return currentRecord;
        }
        catch (Exception)
        {
            currentRecord = new ScoreRecord("", 0);
            return currentRecord;
        }
    }

    public string GetSessionName()
    {
        return currentData.Name;
    }
}
