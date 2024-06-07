using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour 
{
   public Dropdown difficultyDropdown;
   public GameObject settingsWindow;
   private readonly List<string> difficulties = new();

    public void Start()
    {
        initDifficulties();
        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(difficulties);
        
    }

    public void StartGame()
    {
        SceneLoader.LoadScene(SceneName.QuestionScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }

    private void initDifficulties()
    {
        foreach (DifficultyLevel difficultyLevel in Enum.GetValues(typeof(DifficultyLevel)))
        {
            string d = DifficultyLevelExtension.ToString(difficultyLevel);
            difficulties.Add(d);
        }
    }
}
