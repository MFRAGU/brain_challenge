using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour 
{
   public Dropdown difficultyDropdown;
   public GameObject settingsWindow;
   public DifficultyLevel difficultyLevel;
   private readonly List<string> difficulties = new();

    public void Start()
    {
        initDifficulties();
        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(difficulties);

       initDifficulties();
        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(difficulties);

        if (!PlayerPrefs.HasKey("difficulty"))
        {
            int randomIndex = difficulties.IndexOf(DifficultyLevelExtension.ToString(DifficultyLevel.Random));
            difficultyDropdown.value = randomIndex;
            PlayerPrefs.SetInt("difficulty", randomIndex);
        }
        else
        {
            difficultyDropdown.value = PlayerPrefs.GetInt("difficulty");
        }

         difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);
       
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

    private void OnDifficultyChanged(int index)
   {
       PlayerPrefs.SetInt("difficulty", index);
   }

   
}
