using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    // Start is called before the first frame update
    Canvas canvas;
    QuizData quizData; 
    LearnerUIManager learnerUI; 
    public Canvas answerCanvas; 

    public GameObject buttonPrefab; 
    
    [SerializeField]    public TMP_Text Question; 

    void Awake()
    {
        canvas = GetComponent<Canvas>();
        //canvas.enabled = false;
        //answerCanvas = canvas.GetComponent<AnswersCanvas>();
        quizData = GetComponent<QuizData>(); 
        learnerUI = GameObject.Find("LearnerUIManager").GetComponent<LearnerUIManager>();
        Debug.Log(learnerUI.name);

    }
    public void CreateQuestion(){
        Question.text = quizData.Question; 
        int counter = 0; 
        
        foreach (string answer in quizData.Answers){
            if(counter == quizData.CorrectAnswer){
                GameObject button = Instantiate(buttonPrefab) as GameObject; 
                button.transform.SetParent(answerCanvas.transform, false);
                button.GetComponent<Button>().onClick.AddListener(delegate{ Correct(); });
                button.GetComponentInChildren<TMP_Text>().text = answer; 
                Debug.Log(button.transform.parent.name);
            }else{
                GameObject button = Instantiate(buttonPrefab) as GameObject; 
                button.transform.SetParent(answerCanvas.transform, false);
                button.GetComponent<Button>().onClick.AddListener(delegate{ Incorrect(); });
                button.GetComponentInChildren<TMP_Text>().text = answer; 
                Debug.Log(button.transform.parent.name);

            }
        }
    }
    public void Correct(){
        Debug.Log("correct!");
        PlayerPrefs.SetInt("currentMarks", PlayerPrefs.GetInt("currentMarks") + 1);
        Debug.Log("set new score");
        learnerUI.updateScore();
        Debug.Log("updated score");
        this.gameObject.SetActive(false);
    }

    public void Incorrect(){
        Debug.Log("incorrect");
        this.gameObject.SetActive(false);
    }

    public void Close(){
        this.gameObject.SetActive(false);
    }
}
