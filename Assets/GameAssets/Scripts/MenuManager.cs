using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro; 
public class MenuManager : MonoBehaviour
{

    [SerializeField]    public TMP_InputField fileName; 
    private string path;
    private string persistantPath; 
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar;
        persistantPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar;
    } 
    public void LoadCreateScene(){
        PlayerPrefs.SetString("learner" , "false"); 
        Application.LoadLevel("CreateScene");
        
    }

    public void LoadLearningScene(){
        Debug.Log(persistantPath + fileName.text + ".json");
        if(File.Exists(persistantPath + fileName.text + ".json")){
            PlayerPrefs.SetString("learner" , "true"); 
            PlayerPrefs.SetString("fileName", fileName.text);
            Application.LoadLevel("LearnerScene");

        } else{
            Debug.Log("file doesn't exist");
            // Give feedback to user. 
        }
    }

}
