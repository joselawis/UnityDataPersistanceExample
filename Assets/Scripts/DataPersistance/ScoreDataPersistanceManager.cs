using Assets.Lawis.DataPersistance;
using System;
public class ScoreDataPersistanceManager : DataPersistanceManager<ScoreRecord, ScoreDataPersistanceManager>
{
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
    }

    public ScoreRecord GetCurrentRecord()
    {
        try
        {
            ScoreRecord scoreRecord = LoadDataFromJson();
            return scoreRecord;
        }
        catch (Exception) { return null; }
    }
}
