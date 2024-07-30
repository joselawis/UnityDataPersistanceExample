using Assets.Lawis.DataPersistance;

public class ScoreRecord : JsonConvertibleObject
{
    private string name = "";
    private int score = 0;

    public string Name { get => name; set => name = value; }
    public int Score { get => score; set => score = value; }

    public ScoreRecord(string name, int score)
    {
        this.Name = name;
        this.Score = score;
    }

    public ScoreRecord()
    {

    }

}
