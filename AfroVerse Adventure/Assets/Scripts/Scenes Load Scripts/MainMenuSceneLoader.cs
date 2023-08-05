using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoader : MonoBehaviour
{
   public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
