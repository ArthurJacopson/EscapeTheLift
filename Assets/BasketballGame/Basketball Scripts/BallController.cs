using UnityEngine;

public class BallController : MonoBehaviour {
    public ScoreSystem scoreSystem; 
    private bool hasLanded = false; 

    void Start() {
    if (scoreSystem == null) {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        if (scoreSystem == null) {
            Debug.LogError("ScoreSystem not found in the scene!");
        }
    }
}


    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") && !hasLanded) {
            hasLanded = true; 
            if (scoreSystem != null) {
                scoreSystem.AddAttempt(); 
                Debug.Log("Ball touched ground! Attempt added.");
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("ScoreTrigger")) { 
            if (scoreSystem != null) {
                scoreSystem.AddScore(); 
                Debug.Log("Ball scored!");
            }
        }
    }

    public void ResetBallState() {
        hasLanded = false; 
        Debug.Log("Ball state reset.");
    }
}
