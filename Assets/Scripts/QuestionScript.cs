using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Rendering;
using OpenAI;




public class QuestionScript : MonoBehaviour
{
    private OpenAIApi openai ;
    public TextMeshProUGUI textNumberQuestion;
    public TextMeshProUGUI textQuestion;
    public TMP_Text textChaptGPT;
    public TMP_Text difficultyText;
    public Button[] Buttons = new Button[4];
    public GameObject settingsWindow;
    [SerializeField] private ResultScriptableObject resultScriptableObject;
[SerializeField] private QuestionScriptableObject questionScriptableObject;
  private List<Question> _questionList;
    private Question _currentQuestion;
    private Button btn;
    public GameObject panelGPT;
    private int _questionNumber = 1;
    private DifficultyLevel currentDifficulty;
    private string prompt = "Act as a random friend that has called during the game How to became a milionnaire and reply to the questions. Don't break character. Don't ever mention that you are an AI model.Say the answer in France";

    void Start()
    {
           openai = new OpenAIApi("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", "org-nhFO1n2H7QJK15XDzkNhwMj8");
      
        if (PlayerPrefs.HasKey("difficulty"))
        {
            int difficultyIndex = PlayerPrefs.GetInt("difficulty");
            currentDifficulty = (DifficultyLevel) difficultyIndex;
        }
        difficultyText.text = "Mode de jeu: " + DifficultyLevelExtension.ToString(currentDifficulty);
        resultScriptableObject.ClearResults();
        InitQuestions();
        InitUI();
       // timer.SetActive();
        InvokeRepeating("UpdateTimer", 1.0f, 1.0f);
    } 

    /*private void Update()
    {
        if(timer.currentTime == 0)
        {
            UpdateQuestion();
        }
    }
    */

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
        yield return new WaitForSeconds(1.2f);
        if (ResponseIsCorrect(response))
        {
            imageButton.color = BCColor.DarkGreen;
            outlineButton.effectColor = BCColor.DarkGreen;
            textChaptGPT.ClearMesh();
            panelGPT.SetActive(false);

        }
        else
        {
            imageButton.color = BCColor.DarkRed;
            outlineButton.effectColor = BCColor.DarkRed;
            textChaptGPT.ClearMesh();
            panelGPT.SetActive(false);
        }
        yield return new WaitForSeconds(1.2f);
        ResetButtonColor(buttonClicked);
        UpdateQuestion();
    }

    private void UpdateQuestion()
    {
       // ResetTimer();
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
        _questionList = questionScriptableObject.questions;
    }


    private void InitUI()
    {
        _currentQuestion = _questionList[_questionNumber - 1];
        textQuestion.text = _currentQuestion.question;
        textNumberQuestion.text = _questionNumber.ToString();
     //   textTimer.text = timer.currentTime.ToString();
        UpdateButtonText();
    }

    private void ResetButtonColor(Button button)
    {
        button.GetComponent<Image>().color = BCColor.DarkPurple;
        button.GetComponent<Outline>().effectColor = BCColor.LightPurple;
    }

    private void UpdateButtonText()
    {
        string[] s = _currentQuestion.incorrectAnswers;
        List<string> propositions = s.ToList();
        propositions.Add(_currentQuestion.correctAnswer);
        Utils.Shuffle(propositions);
        for (int i = 0; i < propositions.Count; i++)
        {
            SetButtonText(Buttons[i], propositions[i]);
        }
    }

    private void SetButtonText(Button b, string text)
    {
        b.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    private string GetButtonText(Button b)
    {
        return b.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
    }

    private void DisableButtons()
    {
        foreach (Button b in Buttons)
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

    public void QuitGame()
    {
        SceneLoader.LoadScene(SceneName.MainMenuScene);
    }

    public void OpenSettings()
    {
        settingsWindow.SetActive(true);
    }
    public void ChatGPT(Button clicked)
    {
        clicked.interactable = false;
        panelGPT.SetActive(true);


        SendRequest();
        
        
        

    }
    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }

   
    //envoyer chque question 
    private async void SendRequest()
    {
        Debug.Log("Button clique");

        _currentQuestion = _questionList[_questionNumber - 1];
        List<ChatMessage> Messages = new List<ChatMessage>();
        ChatMessage newMessage = new ChatMessage();

        newMessage.Role = "user";
        newMessage.Content =  _currentQuestion.question +"Les reponses possible" +_currentQuestion.correctAnswer +_currentQuestion.incorrectAnswers;//on recupere ce que il y a dans le textQuestion
       // Debug.Log("1 le premier message "+newMessage);
        Messages.Add(newMessage);
       // Debug.Log("2 tout la liste des messages : "+Messages);

        CreateChatCompletionRequest req = new CreateChatCompletionRequest();

        req.Messages = Messages;
        req.Model = "gpt-3.5-turbo";
        var res = await openai.CreateChatCompletion(req);
        Debug.Log(res);
        if (res.Choices != null && res.Choices.Count > 0)

        {

            var reponse = res.Choices[0].Message;
           // reponse.Content = reponse.Content.Trim();

            Messages.Add(reponse);
           textChaptGPT.text= reponse.Content;//affichage de reponse 
            Debug.Log("3"+reponse.Content);
         



        }
        else
        {
            Debug.LogWarning("No text was generated from this prompt.");
        }
        


    }

}

