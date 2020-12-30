using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {
    public float Score { get; set; }
    public bool IsGameOver { get; set; }

    [SerializeField] private float scoreMultiplier = 2f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private TextMeshProUGUI gameoverScoreText;
    [SerializeField] private GameObject gameoverPanel;

    private void Update() {
        if (!IsGameOver) Score += scoreMultiplier * Time.deltaTime;
        if (Score > GameManager.Instance.GetHighscore()) {
            GameManager.Instance.SetHighscore((int) Score);
        }

        GameManager.Instance.GetHighscore();
        scoreText.SetText("Score:\n" + ((int) Score).ToString("0"));
    }

    public IEnumerator ShowGameOverPanel() {
        yield return new WaitForSeconds(1f);
        gameoverPanel.SetActive(true);
        gameoverScoreText.SetText("Score: " + ((int) Score).ToString("0"));
        highscoreText.SetText("Highscore: " + (GameManager.Instance.GetHighscore()));
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit() {
        SceneManager.LoadScene("Main Menu");
    }
}