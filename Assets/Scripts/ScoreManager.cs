using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreRightText; // Reference to UI text for correct answers
    public Text scoreFalseText; // Reference to UI text for incorrect answers

    private int correctAnswers; // Stores the total number of correct answers
    private int incorrectAnswers; // Stores the total number of incorrect answers

    // Start is called before the first frame update
    void Start()
    {
        // Consider resetting the score on game start here
        // ResetScore();
    }

    public void UpdateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            correctAnswers++;
            scoreRightText.text = correctAnswers.ToString(); // Update UI text
        }
        else
        {
            incorrectAnswers++;
            scoreFalseText.text = incorrectAnswers.ToString(); // Update UI text
        }
    }

    public int GetTotalScore()
    {
        // You can return a percentage or adjust based on question count here
        return correctAnswers;
    }

    public void ResetScore()
    {
        correctAnswers = 0;
        incorrectAnswers = 0;
        scoreRightText.text = "0"; // Reset UI text
        scoreFalseText.text = "0";
    }
}
