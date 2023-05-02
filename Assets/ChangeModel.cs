using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using TMPro; 
using UnityEngine.UI;
public class ChangeModel : MonoBehaviour
{
    public GameObject modelCanvas; 


    public AnchorCreator anchorCreator; 
    public GameObject buttonPrefab; 
    // Start is called before the first frame update
    void Awake()
    {

        LoadModels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadModels(){

        TextAsset resourceFiles = Resources.Load("resourceFiles") as TextAsset;
        string[] fileNames = resourceFiles.ToString().Split(",");

        foreach(string fileName in fileNames){
            GameObject button = Instantiate(buttonPrefab) as GameObject; 
            button.transform.SetParent(modelCanvas.transform, false);
            string newModel = fileName; 
            button.GetComponent<Button>().onClick.AddListener(delegate{ NewModel(newModel); });
            button.GetComponentInChildren<TMP_Text>().text = newModel; 
        }
    }

    public void NewModel(string fileName){

        GameObject newModel = Resources.Load(fileName) as GameObject; 
        anchorCreator.changeModel(newModel);
        Debug.Log(fileName);
        this.gameObject.GetComponentInChildren<Canvas>().enabled = false;

    }


}
