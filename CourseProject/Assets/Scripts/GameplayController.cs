using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {
    public float Score { get; set; }
    public bool IsGameOver { get; set; }

    [SerializeField] private float scoreMultiplier = 2f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameoverScoreText;
    [SerializeField] private GameObject gameoverPanel;

    // Update is called once per frame
    private void Update() {
        if(!IsGameOver) Score += scoreMultiplier * Time.deltaTime;
        if (Score > GameManager.Instance.GetHighscore()) {
            GameManager.Instance.SetHighscore((int)Score);
        }

        scoreText.SetText("Score:\n" + ((int)Score).ToString("0"));
    }

    public IEnumerator ShowGameOverPanel() {
        yield return new WaitForSeconds(1f);
        gameoverPanel.SetActive(true);
        gameoverScoreText.SetText("Score: " + ((int)Score).ToString("0"));
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit() {
        SceneManager.LoadScene("Main Menu");
    }
    
    
}