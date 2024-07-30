using Assets.Lawis.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitUIManager : UIManager<InitUIManager>
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField playerNameInput;

    private void Start()
    {
        GetBestScore();
    }

    public void GetBestScore()
    {
        var currentRecord = ScoreDataPersistanceManager.Instance.GetCurrentRecord();
        if (currentRecord.Score > 0)
        {
            bestScoreText.text = $"Best score: {currentRecord.Name} - {currentRecord.Score}";
        }
        else { bestScoreText.text = $"There is no score records"; }
    }
    public void StartGame()
    {
        SaveName();
        SceneManager.LoadScene(1);
    }

    private void SaveName()
    {
        ScoreDataPersistanceManager.Instance.SetCurrentName(playerNameInput.text);
    }
}
