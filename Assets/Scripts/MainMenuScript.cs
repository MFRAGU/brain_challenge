using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour 
{

   public void StartGame()
    {
        SceneLoader.LoadScene(SceneName.QuestionScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
