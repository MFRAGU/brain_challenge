using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI TexteRightText; 
    public TextMeshProUGUI TexteFalseText; 

    private int correctAnswers; 
    private int incorrectAnswers;

    // Start is called before the first frame update
    void Start()
    {
    
        // Consider resetting the score on game start here
         ResetScore();
        UpdateScore(TexteRightText);

    }

    public void UpdateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            correctAnswers++;
            TexteRightText.text = correctAnswers.ToString()+ " Réponses Correctes"; 
        }
        else
        {
            incorrectAnswers++;
            TexteFalseText.text = incorrectAnswers.ToString()+ "Réponses Incorrectes"; 
        }
    }
    
  

    public void ResetScore()
    {
        correctAnswers = 0;
        incorrectAnswers = 0;
        TexteRightText.text = "0"; 
        TexteFalseText.text = "0";
    }
}
