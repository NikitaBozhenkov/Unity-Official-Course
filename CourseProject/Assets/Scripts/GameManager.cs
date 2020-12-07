using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager Instance = null;

    private const string HighscoreKey = "Highscore";
    private Button _startButton;

    void Start() {
        MakeSingleton();
        if (!PlayerPrefs.HasKey(HighscoreKey)) {
            SetHighscore(0);
        }
    }

    public int GetHighscore() {
        return PlayerPrefs.GetInt(HighscoreKey);
    }

    public void SetHighscore(int score) {
        PlayerPrefs.SetInt(HighscoreKey, score);
    }
    private void MakeSingleton() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != null) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

}