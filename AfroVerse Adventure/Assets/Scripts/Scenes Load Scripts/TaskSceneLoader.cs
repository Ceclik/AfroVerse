using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskSceneLoader : MonoBehaviour
{
    public void LoadBlackHoleTaskScene()
    {
        SceneManager.LoadScene("Blackhole Task");
    }
}
