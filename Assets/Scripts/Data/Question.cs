using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    public string correctAnswer;
    public string[] incorrectAnswers;
    public string question;

    public Question(
        string correctAnswer,
        string[] incorrectAnswers,
        string question
     )
    {
        this.correctAnswer = correctAnswer;
        this.incorrectAnswers = incorrectAnswers;
        this.question = question;
    }
}
