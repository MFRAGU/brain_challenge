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
    public List<ResultHandler> resultHandlers; //gonna stock all the texte of the ui
    public GameObject coloredObject;
    private Dictionary<Question, string> _result;

    public void Start()
    {
        coloredObject.GetComponent<Image>().color = BCColor.Yellow;
        _result = scriptableObject.GetResults();
        DisplayResult();

    }

    private void DisplayResult()
    {
        //count all the qst and answer
        int i = 0;
        foreach (var r in _result)
        { //contains key (type qst)and value (strinng= answer)
            ResultHandler handler = resultHandlers[i];
            if (handler != null)
            {
                Question qst = r.Key;
                string reponse = r.Value;
                handler.textQuestion.text = qst.question;
                handler.textCorectAnswer.text = qst.correctAnswer;
                if (reponse != qst.correctAnswer)
                {
                    handler.textAnswer.text = reponse;
                }
                else
                {
                    handler.textAnswer.enabled = false;
                }
            }
        }
    }
}
