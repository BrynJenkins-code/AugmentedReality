using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas changeModelCanvas;

    public AnchorCreator anchorCreator;

    public InteractionManager interactionManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu(){
        Application.LoadLevel("MenuScene");
    }

    public void MoveModel(){
        anchorCreator.RemoveAllAnchors();
        Destroy(GameObject.FindWithTag("Model"));
        interactionManager.moveMode();
    }

    public void ChangeModel(){
        changeModelCanvas.GetComponent<Canvas>().enabled = true;
    }

}
