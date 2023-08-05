using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrierSceneLoader : MonoBehaviour
{
    public void LoadBarrierTaskScene()
    {
        SceneManager.LoadScene("EnergyBarrierTask");
    }
}
