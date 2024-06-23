using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;


public class ResultScript : MonoBehaviour
{
    public ResultScriptableObject scriptableObject;
    [SerializeField]//let to touch objects in order to show them in the editot
    public ResultHandler resultHandlers; //gonna stock all the texte of the ui
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

            if (reponse == qst.correctAnswer)
            {
                trueAnswer++;
                resultHandlers.textScoreRight.text =   trueAnswer.ToString() + " réponses correctées ";
                resultHandlers.textScoreRight.color = BCColor.DarkGreen;
            }
            else
            {
                falseAnswer++;
                resultHandlers.textScoreFalse.text =  falseAnswer.ToString() + " mauvaises réponses";
                resultHandlers.textScoreFalse.color = BCColor.DarkRed;
            }
            TextCongrat();

        }
    }

    private void TextCongrat()
    {
        if (trueAnswer >= falseAnswer)
        {
            resultHandlers.textCongratulation.text = "Félicitation";
        }
        else
        {
            resultHandlers.textCongratulation.text = "C'est pas toi c'est les question...";

        }


    }
    public void ResetScore()
    {
        trueAnswer = 0;
        falseAnswer = 0;
        resultHandlers.textScoreRight.text = "0";
        resultHandlers.textScoreFalse.text = "0";
    }
    public void ExitGame()
    {
       
        Debug.Log("button sorti appuye");
        print("button sorti appuye");
        Application.Quit();
    }

    public void Restart()
    {
        _result.Clear();
        ResetScore();
     
        
        Debug.Log("Button restart appuye");
        print("button sorti appuye");
        SceneLoader.LoadScene(SceneName.MainMenuScene);
    }
}


