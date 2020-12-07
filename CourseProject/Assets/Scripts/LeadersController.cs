using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeadersController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI score;
    
    void Start() {
        score.SetText(GameManager.Instance.GetHighscore().ToString());
    }

    public void Resume() {
        SceneManager.LoadScene("Main Menu");
    } 

    // Update is called once per frame
    void Update() {
    }
}