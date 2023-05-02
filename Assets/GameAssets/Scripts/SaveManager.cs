using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string path;
    private string persistantPath; 
    private List<LearningData> questions = new List<LearningData>();
    
    void Awake()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistantPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        Debug.Log("SaveManager created");
    }

    public void addQuestion(LearningData question){
        questions.Add(question);
        Debug.Log(questions.Count);

    }
    public void saveComplete(){
        string savePath = persistantPath; 
        GameObject model = GameObject.FindWithTag("Model");
        LoadData data = new LoadData(model.name, questions);
        string json = JsonUtility.ToJson(data);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        Application.LoadLevel("MenuScene");
    }
}
