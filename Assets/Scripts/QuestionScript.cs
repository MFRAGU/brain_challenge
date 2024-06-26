using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class QuestionScript : MonoBehaviour
{
    public TextMeshProUGUI textNumberQuestion;
    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI textTimer;
    public TMP_Text difficultyText;
    public Button[] buttons = new Button[4];
    public GameObject settingsWindow;
    public Button buttonAsterisk;
    [SerializeField] private ResultScriptableObject resultScriptableObject;
    [SerializeField] private QuestionScriptableObject questionScriptableObject;
    private List<Question> _questionList;
    private Question _currentQuestion;
    private int _questionNumber = 1;
    private Difficulty currentDifficulty;
    private readonly AsteriskRequestUseCase _asteriskRequestUseCase = new();

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
            SetButtonText(buttons[i], propositions[i]);
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
        foreach(Button b in buttons)
        {
            b.enabled = false;
        }
    }

    private void EnableButtons()
    {
        foreach (Button b in buttons)
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

    public void ClickButtonAsterisk(Button b)
    {
        b.enabled = false;
        b.transform.GetChild(0).GetComponent<Image>().color = BCColor.DarkGrey;
        b.GetComponentInChildren<Text>().text = "";
        CallAsterisk();
    }

    private async Task CallAsterisk()
    {
        await Task.Run(() => _asteriskRequestUseCase.SendCallRequest());
    }
}
