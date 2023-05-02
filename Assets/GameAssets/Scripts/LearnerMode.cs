using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class LearnerMode : MonoBehaviour
{
    private Camera arCamera; 
    //[SerializeField]
    //private GameObject learningPrefab; 
    [SerializeField]
    ARRaycastManager m_RaycastManager; 

    private LoadManager loadManager; 

    public bool creating = true; // Shouldn't initialise as true
    
    private GameObject hitObject; 
    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // If there is no tap, then simply do nothing until the next call to Update().
        if (Input.touchCount == 0)
            return;
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;


        Ray ray = arCamera.ScreenPointToRay(touch.position);
        RaycastHit modelHit; 
        
        if (Physics.Raycast(ray, out modelHit))
        {
            Debug.DrawLine (ray.origin, modelHit.point);
            //Debug.Log("Raycast hit");

            if(modelHit.collider.gameObject.tag == "Question"){
                GameObject quizObject = modelHit.collider.gameObject.transform.parent.gameObject;
                GameObject canvas = quizObject.transform.Find("Canvas").gameObject;
                canvas.GetComponent<Canvas>().enabled = true;
                //modelHit.collider.gameObject.transform.parent.gameObject.GetComponent<Canvas>().enabled = true; 
                Debug.Log("hitting question");

            } 
        }
    }

    void interactLearning(RaycastHit modelHit){
        Debug.Log("Interacting");
    }
}