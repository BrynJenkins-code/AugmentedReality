using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(SaveManager))]
public class LearningManager : MonoBehaviour
{

    private List<string> answers = new List<string>(); 

    //private List<LearningData> questions = new List<LearningData>();
    private int CorrectAnswer; 
    private string path;
    private string persistantPath; 

    [SerializeField]    public TMP_InputField Question; 
    [SerializeField]    public TMP_InputField answerText; 
    [SerializeField]    public Toggle correct;
    GameObject saveManagerObject;
    SaveManager saveManager;

    void Awake()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistantPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        saveManagerObject = GameObject.Find("SaveManager");
        saveManager = saveManagerObject.GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string getQuestion(){
        return Question.text; 
    }

    /*
        Here answers are added in raw text, if a question is marked to be 'correct' it's index in the list will also be stored. 
    */
    public void addAnswer(){
        if(correct.isOn == true){
            string test = answerText.text; 
            answers.Add(test);
            CorrectAnswer = answers.Count - 1; 
        } else{
            answers.Add(answerText.text);
        }
    }
    /*
        Here, the relative position of the question to the model is stored by subtracting the 3D vector of the model from that of the question
        A LearningData object is created and added to a list inside the SaveManager such that it is not lost when the final save is complete. 
    */
    public void saveQuestion(){

        GameObject model = GameObject.FindWithTag("Model");
        Vector3 distance = this.gameObject.transform.position - model.transform.position;
        LearningData saveObject = new LearningData(Question.text, answers, CorrectAnswer, distance);
        saveManager.addQuestion(saveObject);
        this.gameObject.SetActive(false);
    }

    public void Close(){
        this.gameObject.SetActive(false);
    }


}
