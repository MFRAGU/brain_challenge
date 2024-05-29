using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionDTO
{
    public string category { get; private set; }
    public string id { get; private set; }
    public string correctAnswer { get; private set; }
    public string incorrectAnswers { get; private set; }
    public string question { get; private set; }
    public string difficulty { get; private set; }

    public QuestionSO toQuestion()
    {
        return new QuestionSO(
            category, 
            id, 
            correctAnswer, 
            Utils.stringToArray('/', incorrectAnswers),
            question,
            difficulty
        );
    }
}
