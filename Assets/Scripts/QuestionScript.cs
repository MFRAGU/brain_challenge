using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using System.Linq;

public class QuestionScript : MonoBehaviour
{
    private List<Question> _questionList;
    [SerializeField] private ResultsScriptableObject resultsScriptableObject;
    public TextMeshProUGUI textNumberQuestion;
    public TextMeshProUGUI textQuestion;
    public Button[] Buttons = new Button[4];
    private Question _currentQuestion;
    private int _questionNumber = 1;

    private static readonly float r = 17f / 255f;
    private static readonly float g = 18f / 255f;
    private static readonly float b = 46f / 255f;
    private readonly Color defaultColor = new(r, g, b);
    private readonly Color errorColor = new(0.545f, 0f, 0f);
    private readonly Color correctColor = new(0f, 0.392f, 0f);

    void Start()
    {
        resultsScriptableObject.ClearResults();
        InitQuestions();
        InitUI();
    }

    public void ValidResponse(Button b)
    {
        string response = b.transform.GetChild(1).GetComponent<Text>().text;
        Debug.Log("response : " + response);
        Image imageButton = b.GetComponent<Image>();
        resultsScriptableObject.AddResult(_currentQuestion, response);
        if (VerifyResponse(response))
        {
            imageButton.color = errorColor;
        }
        else
        {
            imageButton.color = correctColor;
        }
        Invoke("ResetButtonColor", 1.5f);
        Invoke("UpdateQuestion", 2f);
        Invoke("UpdateButtonText", 2f);
    }

    private void UpdateQuestion()
    {
        _questionNumber++;
        if (_questionNumber <= _questionList.Count)
        {
            _currentQuestion = _questionList[_questionNumber - 1];
            textNumberQuestion.text = _questionNumber.ToString();
            textQuestion.text = _currentQuestion.question;
        }
        else
        {
            SceneLoader.LoadScene(SceneName.ResultScene);
        }
    }
    private bool VerifyResponse(string response)
    {
        if (response == _questionList[_questionNumber - 1].correctAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void InitQuestions()
    {
        _questionList = new List<Question>
        {
            new(
                "St Pétersbourg",
                new string[] { "Paris", "Athènes", "Rome" },
                "Quelle de ces villes se trouve en Russie ?"
            ),
            new(
                "Bicarbonate de soude",
                new string[] { "Eau de Javel", "Sel de table", "Dolomite" },
                "Quel est le nom courant du bicarbonate de sodium ?"
            ),
            new(
                "Dane Geld",
                new string[] { "Obligation de guerre", "Sax Bandeg", "Levy de guerre" },
                "Quelle taxe du 9ème siècle était prélevée pour lutter contre les Vikings ?"
            ),
            new(
              "Harry Potter",
              new string[] { "Le Seigneur des Anneaux", "Une Chanson de Glace et de Feu", "Twilight" },
              "Dans quelle série de livres apparaît 'Albus Dumbledore' ?"
            ),
            new(
              "La vie",
              new string[] { "Carillonnage", "Maladies rhumatismales", "Syphilis" },
              "De quoi la biologie est-elle l'étude ?"
            )
        };
    }

    private void InitUI()
    {
        _currentQuestion = _questionList[_questionNumber - 1];
        textQuestion.text = _currentQuestion.question;
        textNumberQuestion.text = _questionNumber.ToString();
        UpdateButtonText();
    }

    private void ResetButtonColor(Button button)
    {
        button.GetComponent<Image>().color = defaultColor;
    }

    private void UpdateButtonText()
    {
        string[] s = _currentQuestion.incorrectAnswers;
        List<string> propositions = s.ToList();
        propositions.Add(_currentQuestion.correctAnswer);
        Utils.Shuffle(propositions);
        for(int i = 0; i < s.Length; i++) {
            Buttons[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = propositions[i];
        }
    }
}
