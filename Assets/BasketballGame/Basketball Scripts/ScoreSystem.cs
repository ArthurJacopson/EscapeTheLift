using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour {
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI resultText; 

    private int attempts = 0; 
    private int score = 0;
    private int maxAttempts = 5; 
    private int requiredScore = 3; 
    private int failedAttempts = 0; 

    private bool gameEnded = false; 
    void Start() {
        UpdateScoreText(); 
        if (resultText != null) {
            resultText.text = ""; 
        }
    }

    
    public void AddAttempt() {
        if (gameEnded) return; 

        attempts++;
        failedAttempts++; 
        UpdateScoreText();
        CheckGameStatus();
    }

    public void AddScore() {
        if (gameEnded) return; 

        score++;
        failedAttempts = 0; 
        UpdateScoreText();
        CheckGameStatus();
    }

    private void UpdateScoreText() {
        if (scoreText != null) {
            scoreText.text = $"Score: {score} / Attempts: {attempts} / {maxAttempts}";
        }
    }

    private void CheckGameStatus() {
        if (score >= requiredScore) {
            EndGame("Congratulations! You passed the game.");
            return;
        }

        
        if (failedAttempts >= 3) {
            EndGame("Game Over. You failed 3 times in a row.");
            return;
        }

        if (attempts >= maxAttempts) {
            if (score >= requiredScore) {
                EndGame("Congratulations! You passed the game.");
            } else {
                EndGame("Game Over. Try Again!");
            }
        }
    }

    private void EndGame(string message) {
        gameEnded = true; 
        if (resultText != null) {
            resultText.text = message; 
        }
        Debug.Log(message); 
    }
}
