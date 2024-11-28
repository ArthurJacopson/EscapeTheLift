using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class checkPlay : MonoBehaviour
{
    private InputDevice controllerDevice;

    public GameObject prefab;
    public List<GameObject> targets;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor rayInteractor;

    public int currentTargetIndex = 0;
    private bool isSequenceComplete = false;

    private AudioSource wrong;
    private AudioSource correct; // AudioSource for the correct sound
    public GameObject FinishLabel;

    public string nextSceneName; // Name of the next scene to load

    // Start is called before the first frame update
    void Start()
    {
        wrong = GetComponent<AudioSource>();
        controllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Ensure there is a second AudioSource for the correct sound
        correct = gameObject.AddComponent<AudioSource>();
        correct.clip = Resources.Load<AudioClip>("Correct"); // Replace "CorrectSound" with your sound file name
        correct.playOnAwake = false;
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        GameObject selectedObject = args.interactableObject.transform.gameObject;

        if (selectedObject == targets[currentTargetIndex])
        {
            currentTargetIndex++;

            if (currentTargetIndex >= targets.Count)
            {
                isSequenceComplete = true;
                OnSequenceComplete();
            }
        }
        else if (!targets.Contains(selectedObject))
        {
            OnIncorrectClick();
        }
    }

    void OnSequenceComplete()
    {
        Renderer renderer = prefab.GetComponent<Renderer>();
        renderer.material.color = Color.green;
        correct.Play();
        StartCoroutine(WaitForSoundAndSwitchScene());

    }

    void OnIncorrectClick()
    {
        currentTargetIndex = 0;
        wrong.Play();
    }

    IEnumerator WaitForSoundAndSwitchScene()
    {
        // Wait until the correct sound finishes playing
        yield return new WaitWhile(() => correct.isPlaying);

        // Switch to the next scene
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not specified.");
        }
    }
}
