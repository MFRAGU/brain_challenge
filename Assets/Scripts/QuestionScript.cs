using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Linq;
using System;


public class QuestionScript : MonoBehaviour
{
    
    public TMP_Text difficultyText;
    private DifficultyLevel currentDifficulty;
    public GameObject settingsWindow;
    // Start is called before the first frame update
    void Start()
    {
        
       if (PlayerPrefs.HasKey("difficulty"))
        {
            int difficultyIndex = PlayerPrefs.GetInt("difficulty");
            currentDifficulty = (DifficultyLevel)difficultyIndex;
        }
        difficultyText.text = "Mode de jeu: " + DifficultyLevelExtension.ToString(currentDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
