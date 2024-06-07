using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSO : ScriptableObject
{
    public string category { get; private set; }
    public string id { get; private set; }
    public string correctAnswer { get; private set; }
    public string[] incorrectAnswers { get; private set; }
    public string question { get; private set; }
    public string difficulty { get; private set; }

    public QuestionSO(
        string category,
        string id,
        string correctAnswer,
        string[] incorrectAnswers,
        string question,
        string difficulty
     )
    {
        this.category = category;
        this.id = id;
        this.correctAnswer = correctAnswer;
        this.incorrectAnswers = incorrectAnswers;
        this.question = question;
        this.difficulty = difficulty;
    }
}
