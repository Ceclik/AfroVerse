using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneLoader : MonoBehaviour
{
   public void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose screen");
    }
}
