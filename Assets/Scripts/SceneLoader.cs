
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static void LoadScene(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
