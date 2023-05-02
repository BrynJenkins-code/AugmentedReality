using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class LearnerUIManager : MonoBehaviour
{


    public TMP_Text score;  
    // Start is called before the first frame update


    public void updateScore(){

        score.text = PlayerPrefs.GetInt("currentMarks").ToString() + " / " + PlayerPrefs.GetInt("totalMarks").ToString() ;
    }
}
