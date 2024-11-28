using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreSystem : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;

    private int attempts = 0;
    private int score = 0;
    private int maxAttempts = 5;
    private int requiredScore = 3;
    private int failedAttempts = 0;
    private AudioSource correct;
    private AudioSource wrong;
    public string nextSceneName;
    private bool gameEnded = false;
    private AudioSource wow;

    void Start() {
        wow = gameObject.AddComponent<AudioSource>();
        wrong = gameObject.AddComponent<AudioSource>();
        correct = gameObject.AddComponent<AudioSource>();
        correct.clip = Resources.Load<AudioClip>("Correct");
        wow.clip = Resources.Load<AudioClip>("wow");
        wrong.clip = Resources.Load<AudioClip>("Wrong_5");
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
        wow.Play();
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
        // Check if the score meets the requirement for a win
        if (score >= requiredScore) {
            EndGame("Congratulations! You passed the game.");
            nextSceneName = "elevator4";
            correct.Play();
            StartCoroutine(Waiter());

        }

        // Check for 3 failed attempts in a row
        if (failedAttempts >= 3) {
            EndGame("Game Over. You failed 3 times in a row.");
            nextSceneName = "elevator3";
            wrong.Play();
            StartCoroutine(Waiter());
        }

        // Check if the max attempts have been reached
        
    }
    private IEnumerator Waiter()
    {

    yield return new WaitWhile(() => correct.isPlaying);
    SceneManager.LoadScene(nextSceneName);
    }

    private void EndGame(string message) {
        gameEnded = true;
        if (resultText != null) {
            resultText.text = message;
        }
        Debug.Log(message);
    }
}
