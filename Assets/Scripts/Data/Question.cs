using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    public string correctAnswer { get; private set; }
    public string[] incorrectAnswers { get; private set; }
    public string question { get; private set; }

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
