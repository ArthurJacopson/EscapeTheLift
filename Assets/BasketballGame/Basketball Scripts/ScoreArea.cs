using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour {

    public GameObject effectObject; 
    public float resetTime = 1f;    

    void Start () {
        effectObject.SetActive(false); 
    }

    void OnTriggerEnter (Collider otherCollider) {
        if (otherCollider.GetComponent<Ball>() != null) {
            effectObject.SetActive(true);

            StartCoroutine(ResetEffect());
        }
    }

    private IEnumerator ResetEffect() {
        yield return new WaitForSeconds(resetTime);
        effectObject.SetActive(false);
    }
}
