using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
     public IXRInteractor rayInteractor; 

    public int currentTargetIndex = 0; 
    private bool isSequenceComplete = false; 

    private AudioSource wrong;
    

    // Start is called before the first frame update
    void Start()
    {
        wrong = GetComponent<AudioSource>();
        controllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    



    

     public void  OnSelectEntered(SelectEnterEventArgs args)
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
        
         Renderer renderer=prefab.GetComponent<Renderer>();
            renderer.material.color=Color.green;
    }

    void OnIncorrectClick()
    {
        
        currentTargetIndex = 0; 
        wrong.Play();
    }
}
