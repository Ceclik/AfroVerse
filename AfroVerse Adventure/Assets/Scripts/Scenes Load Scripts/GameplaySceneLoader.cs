using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySceneLoader : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(1);
    }
}
