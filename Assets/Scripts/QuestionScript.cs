using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Drawing;

public class QuestionScript : MonoBehaviour
{
    public TextMeshProUGUI textNumberQuestion;
    public TextMeshProUGUI textQuestion;
    public Button[] Buttons = new Button[4];
    [SerializeField] private ResultScriptableObject resultScriptableObject;
    private List<Question> _questionList;
    private Question _currentQuestion;
    private int _questionNumber = 1;
    public ScoreManager scoreManager;

    void Start()
    {
        resultScriptableObject.ClearResults();
        InitQuestions();
        InitUI();
    }
   

    public void ValidResponse(Button buttonClicked)
    {
        DisableButtons();
        string response = GetButtonText(buttonClicked);
     
        Image imageButton = buttonClicked.GetComponent<Image>();
        imageButton.color = BCColor.LightPurple;
        resultScriptableObject.AddResult(_currentQuestion, response);
        StartCoroutine(UpdateUI(buttonClicked, response));
    }
   

    private IEnumerator UpdateUI(Button buttonClicked, string response)
    {
        Image imageButton = buttonClicked.GetComponent<Image>();
        Outline outlineButton = buttonClicked.GetComponent<Outline>();
        yield return new WaitForSeconds(1);
        if (ResponseIsCorrect(response))
        {
            imageButton.color = BCColor.DarkGreen;
            outlineButton.effectColor = BCColor.DarkGreen;
           
        }
        else
        {
            imageButton.color = BCColor.DarkRed;
            outlineButton.effectColor = BCColor.DarkRed;
            yield return new WaitForSeconds(1);
            foreach ( Button butonRight in Buttons) {
                string answer = _currentQuestion.correctAnswer;
                if ( answer == GetButtonText(butonRight)){
                    butonRight.GetComponent<Image>().color = BCColor.DarkGreen;
                    butonRight.GetComponent<Outline>().effectColor = BCColor.DarkGreen;
                }
               
            }

        }
        yield return new WaitForSeconds(1);
        ResetButtonColor();
        UpdateQuestion();
    }

    private void UpdateQuestion()
    {
        _questionNumber++;
        if (_questionNumber <= _questionList.Count)
        {
            _currentQuestion = _questionList[_questionNumber - 1];
            textNumberQuestion.text = _questionNumber.ToString() + ".";
            textQuestion.text = _currentQuestion.question;
            UpdateButtonText();
            EnableButtons();
        }
        else
        {
            SceneLoader.LoadScene(SceneName.ResultScene);
        }
    }

    private bool ResponseIsCorrect(string response)
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

    private void ResetButtonColor()
    {
        foreach (Button button in Buttons) {
            button.GetComponent<Image>().color = BCColor.DarkPurple;
            button.GetComponent<Outline>().effectColor = BCColor.LightPurple;
        }
    }

    private void UpdateButtonText()
    {
        string[] s = _currentQuestion.incorrectAnswers;
        List<string> propositions = s.ToList();
        propositions.Add(_currentQuestion.correctAnswer);
        Utils.Shuffle(propositions);
        for(int i = 0; i < propositions.Count; i++) {
            SetButtonText(Buttons[i], propositions[i]);
        }
    }

    private void SetButtonText(Button b,  string text)
    {
        b.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    private string GetButtonText(Button b)
    {
        return b.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
    }
    
    private void DisableButtons()
    {
        foreach(Button b in Buttons)
        {
            b.enabled = false;
        }
    }

    private void EnableButtons()
    {
        foreach (Button b in Buttons)
        {
            b.enabled = true;
        }
    }
}
