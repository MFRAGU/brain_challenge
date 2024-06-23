using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour, Callback<QuestionResult> 
{   public Slider slider; 
    public float speed = 0.2f;

    

    public QuestionScriptableObject questionScriptable;

     public void OnSuccess(QuestionResult questionResult){
        questionScriptable.questions = questionResult.data;
        SceneLoader.LoadScene(SceneName.QuestionScene);
    }

    public void OnError(string message){
        SceneLoader.LoadScene(SceneName.MainMenuScene);
    }

    void Start()
    {
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
