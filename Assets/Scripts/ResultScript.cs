using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;


public class ResultScript : MonoBehaviour

{
    public TextMeshProUGUI textScoreRight;
    public TextMeshProUGUI textScoreFalse;
    public TextMeshProUGUI textCongratulation;

    public ResultScriptableObject scriptableObject;
    [SerializeField]//let to touch objects in order to show them in the editot
    public List<ResultHandler> resultHandlers; //gonna stock all the texte of the ui
    public GameObject coloredObject;
    private Dictionary<Question, string> _result;
    public Button butonRestart;
    public Button butonQuit;

    private int trueAnswer = 0;
    private int falseAnswer = 0;

    public void Start()
    {
       
        _result = scriptableObject.GetResults();
        DisplayResult();
      

    }

    private void DisplayResult()
    {
        //count all the qst and answer

        foreach (var r in _result)
        { //contains key (type qst)and value (strinng= answer)

            Question qst;

            qst = r.Key;

            string reponse = r.Value;
            int i = 0;
            ResultHandler handler = resultHandlers[i];
            if (handler != null)
            {

                if (reponse == qst.correctAnswer)
                {
                    trueAnswer++;
                    textScoreRight.text = trueAnswer.ToString() + " réponses correctées ";
                    textScoreRight.color = BCColor.DarkGreen;

                    handler.correct_answer.text = qst.question;
                    handler.correct_answer.text = "Réponse entrée: " + qst.correctAnswer;
                }
                else
                {
                    falseAnswer++;
                    textScoreFalse.text = falseAnswer.ToString() + " mauvaises réponses";
                    textScoreFalse.color = BCColor.DarkRed;
                    handler.correct_answer.text = "Réponse entrée: " + reponse;
                    handler.correct_answer.text = "Réponse attendu: " + qst.correctAnswer;
                }
            }
            TextCongrat();

        }
    }

    private void TextCongrat()
    {
        if (trueAnswer >= falseAnswer)
        {
            textCongratulation.text = "Félicitation";
        }
        else
        {
            textCongratulation.text = "C'est pas toi c'est les question...";

        }


    }
    public void ResetScore()
    {
        trueAnswer = 0;
        falseAnswer = 0;
        textScoreRight.text = "0";
        textScoreFalse.text = "0";
    }
    public void ExitGame()
    {
        //renvoye vers menu
       
        Debug.Log("button sorti appuye");
        print("button sorti appuye");

        _result.Clear();
        ResetScore();
        SceneLoader.LoadScene(SceneName.MainMenuScene);

    }

    public void Restart()
        //renvoye vers la page des questions
    {
        _result.Clear();
        ResetScore();
     
        
        Debug.Log("Button restart appuye");
        print("button sorti appuye");
        SceneLoader.LoadScene(SceneName.QuestionScene);
    }
}


