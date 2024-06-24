using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LoadingScript : MonoBehaviour, Callback<QuestionResult> 
{   public Slider slider; 
    public float speed = 0.2f;
    private DifficultyLevel currentDifficulty;
    private QuestionSocketUseCase socketUseCase = new QuestionSocketUseCase();
    public GameObject errorPanel;
    public QuestionScriptableObject questionScriptable;

     public void OnSuccess(QuestionResult questionResult){
        questionScriptable.questions = questionResult.data;
        SceneLoader.LoadScene(SceneName.QuestionScene);
    }

    public void OnError(string message){
        errorPanel.SetActive(true);
        
         Invoke("RedirectToMainMenu", 4f);
    }

    private void RedirectToMainMenu()
    {
        SceneLoader.LoadScene(SceneName.MainMenuScene); 
    }

    private async Task SendDifficultyQuestionResult(){
         int difficultyIndex = PlayerPrefs.GetInt("difficulty");
         currentDifficulty = (DifficultyLevel)difficultyIndex;
         switch (currentDifficulty){
            case DifficultyLevel.Random:
                socketUseCase.SendRandomQuestionRequest();
            break;
            default: 
                socketUseCase.SendDifficultyQuestionRequest(currentDifficulty);
            break;
        }
    }

    void Start()
    {
       SendDifficultyQuestionResult();

        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    void Update()
    {
        if (slider != null)
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
    
}
