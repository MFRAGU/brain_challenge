using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class QuestionScript : MonoBehaviour
{
    public TextMeshProUGUI textNumberQuestion;
    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI textTimer;
    public TMP_Text difficultyText;
    public Button[] Buttons = new Button[4];
    public GameObject settingsWindow;
    [SerializeField] private ResultScriptableObject resultScriptableObject;
    [SerializeField] private QuestionScriptableObject questionScriptableObject;
    private List<Question> _questionList;
    private Question _currentQuestion;
    private int _questionNumber = 1;
    private Difficulty currentDifficulty;
    public Timer timer = new(20);

    void Start()
    {
        if (PlayerPrefs.HasKey("difficulty"))
        {
            int difficultyIndex = PlayerPrefs.GetInt("difficulty");
            currentDifficulty = (Difficulty) difficultyIndex;
        }
        difficultyText.text = "Mode de jeu: " + DifficultyLevelExtension.ToString(currentDifficulty);
        resultScriptableObject.ClearResults();
        InitQuestions();
        InitUI();
        timer.SetActive();
        InvokeRepeating("UpdateTimer", 1.0f, 1.0f);
    } 

    private void Update()
    {
        if(timer.currentTime == 0)
        {
            UpdateQuestion();
        }
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
        yield return new WaitForSeconds(1.2f);
        if (ResponseIsCorrect(response))
        {
            imageButton.color = BCColor.DarkGreen;
            outlineButton.effectColor = BCColor.DarkGreen;
        }
        else
        {
            imageButton.color = BCColor.DarkRed;
            outlineButton.effectColor = BCColor.DarkRed;
        }
        yield return new WaitForSeconds(1.2f);
        ResetButtonColor(buttonClicked);
        UpdateQuestion();
    }

    private void UpdateQuestion()
    {
        ResetTimer();
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
        textTimer.text = timer.currentTime.ToString();
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

    public void QuitGame()
    {
        SceneLoader.LoadScene(SceneName.MainMenuScene);
    }

     public void OpenSettings()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }

    private void UpdateTimer()
    {
        timer.Decrement();
        textTimer.text = timer.currentTime.ToString();
    }

    private void ResetTimer()
    {
        timer.Reset();
        textTimer.text = timer.currentTime.ToString();
    }
}
