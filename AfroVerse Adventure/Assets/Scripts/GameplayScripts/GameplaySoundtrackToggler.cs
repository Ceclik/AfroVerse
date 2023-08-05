using UnityEngine;

public class GameplaySoundtrackToggler : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetString("SoundStatus") == "On")
            SetSoundsOn();
        else if (PlayerPrefs.GetString("SoundStatus") == "Off")
            SetSoundsOff();
    }

    private void SetSoundsOn()
    {
        AudioListener.volume = 0.2f;
    }
    private void SetSoundsOff()
    {
        AudioListener.volume = 0f;
    }
}
