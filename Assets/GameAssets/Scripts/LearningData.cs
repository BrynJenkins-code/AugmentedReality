using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class LearningData
{
    public string Question; 
    public List<string> Answers; 
    public int CorrectAnswer; 
    public Vector3 relativePosition; 
    
    public LearningData(string question, List<string> answers, int correctAnswer, Vector3 position){
        Question = question;
        Answers = answers;
        CorrectAnswer = correctAnswer;
        relativePosition = position;
    }

}
