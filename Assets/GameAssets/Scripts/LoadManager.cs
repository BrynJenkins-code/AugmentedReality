using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class LoadManager : MonoBehaviour
{   
    public AnchorCreator m_anchorCreator;
    private List<LearningData> questions = new List<LearningData>();

    public GameObject quizPrefab; 
    private string path;
    private string persistantPath; 

    private LoadData data;
    void Awake()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistantPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar;
        loadScene();
    }

    void loadScene(){
        string fileName = PlayerPrefs.GetString("fileName");
        using StreamReader reader = new StreamReader(persistantPath+ fileName +".json");
        string json = reader.ReadToEnd();
        data = JsonUtility.FromJson<LoadData>(json);
        GameObject newModel = Resources.Load(data.name) as GameObject; 
        m_anchorCreator.changeModel(newModel);

    }
    public void loadQuestions(){
        GameObject model = GameObject.FindWithTag("Model");
        List<LearningData> learningData = data.GetLearning();
        PlayerPrefs.SetInt("totalMarks", learningData.Count );
        PlayerPrefs.SetInt("currentMarks", 0);
        foreach(LearningData question in learningData){
            Vector3 placePosition = question.relativePosition + model.transform.position; 
            GameObject quizElement = Instantiate(quizPrefab, placePosition, Quaternion.identity);
            quizElement.GetComponent<QuizData>().Question = question.Question; 
            quizElement.GetComponent<QuizData>().Answers = question.Answers; 
            quizElement.GetComponent<QuizData>().CorrectAnswer = question.CorrectAnswer; 
            quizElement.GetComponent<QuizManager>().CreateQuestion();
        }
    }
}
