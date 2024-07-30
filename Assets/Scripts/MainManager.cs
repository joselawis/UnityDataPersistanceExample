using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;
    public Text NewRecordText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;
    private bool m_NewRecord = false;


    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        ScoreRecord currentRecord = ScoreDataPersistanceManager.Instance.GetCurrentRecord();
        SetBestScoreText(currentRecord.Name.Length > 0 ? currentRecord.Name : "None", currentRecord.Score);
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";

        if (m_Points > ScoreDataPersistanceManager.Instance.GetCurrentRecord().Score)
        {
            Debug.Log($"New record: {ScoreDataPersistanceManager.Instance.GetSessionName()} - {m_Points}");
            SetBestScoreText(ScoreDataPersistanceManager.Instance.GetSessionName(), m_Points);
            SaveNewRecord();
            m_NewRecord = true;
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        m_GameOver = true;
        GameOverText.SetActive(true);
        if (m_NewRecord)
        {
            NewRecordText.text = $"NEW RECORD!! {ScoreDataPersistanceManager.Instance.GetSessionName()} - {m_Points} points";
            NewRecordText.gameObject.SetActive(true);
        }
    }

    private void SaveNewRecord()
    {
        ScoreDataPersistanceManager.Instance.SetCurrentScore(m_Points);
        ScoreDataPersistanceManager.Instance.SaveData();
    }

    private void SetBestScoreText(string name, int score)
    {
        BestScoreText.text = $"Best Score : {name} : {score}";
    }
}
