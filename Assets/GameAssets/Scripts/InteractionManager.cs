using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InteractionManager : MonoBehaviour
{

    private GameObject currentModel;  
    private Behaviour anchorBhvr;
    private Behaviour interactionBhvr;
    private LoadManager loadManager; 
    private Behaviour learnerBhvr;

    // Start is called before the first frame update
    void Start()
    {
        anchorBhvr = (Behaviour)GetComponent("AnchorCreator");
        interactionBhvr = (Behaviour)GetComponent("InteractionMode");
        learnerBhvr = (Behaviour)GetComponent("LearnerMode");
        interactionBhvr.enabled = false; 
        learnerBhvr.enabled = false; 
    }


    // Changes the current input mode to movement, such that the user can place or move their model. 
    public void moveMode()
    {
        anchorBhvr.enabled = true;
        interactionBhvr.enabled = false; 
    }
    // Changes the mode to interaction, such that inputs instead register against placed models. 
    public void interactMode()
    {   
        anchorBhvr.enabled = false;
        if (PlayerPrefs.GetString("learner") == "true"){
            Debug.Log("Learner is true");

            learnerBhvr.enabled = true;
            loadManager = GameObject.Find("LoadManager").GetComponent<LoadManager>();
            loadManager.loadQuestions();
        } else {
            interactionBhvr.enabled = true; 
        }
        
    }
}
