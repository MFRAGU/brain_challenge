using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class MainMenuScript : MonoBehaviour 
{
    [SerializeField]
    private Dropdown difficultyDropdown;
    
    [SerializeField]
    private TableObject tableObject; 

   public void StartGame()
    {
        SceneLoader.LoadScene(SceneName.QuestionScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        // Initialiser le dropdown avec les valeurs de l'enum
        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(System.Enum.GetNames(typeof(DifficultyLevel)).ToList());
        difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);

        // Sélectionner la valeur par défaut
        difficultyDropdown.value = (int)DifficultyLevel.Default;
    }

    private void OnDifficultyChanged(int index)
    {
        DifficultyLevel selectedDifficulty = (DifficultyLevel)index;
        tableObject.DifficultyLevel = selectedDifficulty;
    }
}
