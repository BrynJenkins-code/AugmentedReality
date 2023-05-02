using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class LoadData
{
    
    public string name; 
    public List<LearningData> questions = new List<LearningData>();
        
    public LoadData(string nameData, List<LearningData> questionsData){
        name = nameData; 
        questions = questionsData; 
    }

    public List<LearningData> GetLearning(){
        return questions; 
    }
}
