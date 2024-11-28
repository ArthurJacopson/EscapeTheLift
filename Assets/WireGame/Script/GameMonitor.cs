using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GridSlot[] gridSlots;
    public GameObject objectToDestroy;
    private AudioSource endGame;
    public float resetTime = 1f;
    public GameObject effectObject;
    public bool done;
    void Start()
    {
        done = false;
        effectObject.SetActive(false);
        endGame = gameObject.AddComponent<AudioSource>();
        endGame.clip = Resources.Load<AudioClip>("gameEnd");
    }
    void Update()
    {
       if(done == false){

        if (CheckWinCondition())
        {
            Debug.Log("You win!");
            effectObject.SetActive(true);
            DestroyReferencedObject();
            endGame.Play();
            StartCoroutine(wait());
            done = true;
        }
        }
    }

    private bool CheckWinCondition()
    {
        foreach (GridSlot slot in gridSlots)
        {
            Debug.Log($"Checking slot: {slot.name}, IsOccupied: {slot.IsOccupied()}");

            if (!slot.IsOccupied())
            {
                Debug.Log("Not all slots are filled.");
                return false; // Break out as soon as we find an empty slot
            }
        }

        Debug.Log("You win!");
        return true;
    }



    public void DestroyReferencedObject()
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }
        private IEnumerator wait()
        {
            yield return new WaitWhile(() => endGame.isPlaying);

        }


}