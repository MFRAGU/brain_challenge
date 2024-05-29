using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSO : ScriptableObject
{
    public string Category { get; private set; }
    public string Id { get; private set; }
    public string CorrectAnswer { get; private set; }
    public string[] IncorrectAnswers { get; private set; }
    public string Question { get; private set; }
    public string Difficulty { get; private set; }

    public QuestionSO(
        string category,
        string id,
        string correctAnswer,
        string[] incorrectAnswers,
        string question,
        string difficulty
     )
    {
        Category = category;
        Id = id;
        CorrectAnswer = correctAnswer;
        IncorrectAnswers = incorrectAnswers;
        Question = question;
        Difficulty = difficulty;
    }
}
