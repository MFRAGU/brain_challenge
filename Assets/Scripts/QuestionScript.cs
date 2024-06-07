using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    public List<QuestionSO> questionList
    { get; private set; }
    public Text textNumberQuestion;
    public Text textQuestion;
    public Button[] buttonsResponse;
    private int _questionNumber = 1;

    void Start()
    {
        InitQuestions();
    }

    public void UpdateQuestion(Button b)
    {

    }
    private bool VerifyResponse(string response)
    {
        if (response == questionList[_questionNumber - 1].correctAnswer) 
            return true;
        else 
            return false;
    }

    private void InitQuestions()
    {
        questionList = new List<QuestionSO>
        {
            new QuestionSO(
            "géographie",
            "62602dc7014f58b5fc1a3fc4",
            "St Pétersbourg",
            new string[] { "Paris", "Athènes", "Rome" },
            "Quelle de ces villes se trouve en Russie ?",
            "facile"
        ),
            new QuestionSO(
            "science",
            "6244372e746187c5e7be9339",
            "Bicarbonate de soude",
            new string[] { "Eau de Javel", "Sel de table", "Dolomite" },
            "Quel est le nom courant du bicarbonate de sodium ?",
            "difficile"
        ),
            new QuestionSO(
            "histoire",
            "622a1c367cc59eab6f9503d2",
            "Dane Geld",
            new string[] { "Obligation de guerre", "Sax Bandeg", "Levy de guerre" },
            "Quelle taxe du 9ème siècle était prélevée pour lutter contre les Vikings ?",
            "difficile"
        )
        };
    }
}
