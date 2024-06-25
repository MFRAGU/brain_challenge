using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LoadingScript : MonoBehaviour, ICallback<QuestionResult> 
{   
    public Slider slider; 
    public float speed = 0.2f;
    public GameObject errorPanel;
    [SerializeField] private QuestionScriptableObject _questionScriptableObject;
    private Difficulty _currentDifficulty;
    private readonly QuestionSocketUseCase _questionSocketUseCase = new();

    public void OnSuccess(QuestionResult data)
    {
        Debug.Log("On sucess called");
        _questionScriptableObject.questions = data.data;
        Invoke(nameof(RedirectToQuestion), 4f);
    }

    public void OnError(string message)
    {
        Debug.Log("On error called");
        errorPanel.SetActive(true);
        Invoke(nameof(RedirectToMainMenu), 4f);
    }

    private void RedirectToMainMenu()
    {
        SceneLoader.LoadScene(SceneName.MainMenuScene); 
    }

    private void RedirectToQuestion()
    {
        SceneLoader.LoadScene(SceneName.QuestionScene);
    }

    private async Task SendDifficultyQuestionResult()
    {
         int difficultyIndex = PlayerPrefs.GetInt("difficulty");
         _currentDifficulty = (Difficulty)difficultyIndex;

         switch (_currentDifficulty){
            case Difficulty.RANDOM:
                _questionSocketUseCase.SendRandomQuestionRequest(this);
            break;
            default: 
                _questionSocketUseCase.SendDifficultyQuestionRequest(_currentDifficulty, this);
            break;
        }
    }

    void Start()
    {
       SendDifficultyQuestionResult();
    }

    void Update()
    {
        // Change la valeur du slider en fonction de la vitesse
        slider.value += speed * Time.deltaTime;

        // Vérifie si le slider a atteint sa valeur maximale et le réinitialise
        if (slider.value >= slider.maxValue)
        {
            slider.value = slider.minValue;
        }
    }
}
