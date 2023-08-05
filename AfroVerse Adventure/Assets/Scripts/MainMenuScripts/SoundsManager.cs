using UnityEngine;

[RequireComponent(typeof(SoundButtonSpriteChanger))]
public class SoundsManager : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetString("SoundStatus") == "")
            PlayerPrefs.SetString("SoundStatus", "On");
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

    public void OnButtonClick()
    {
        if (PlayerPrefs.GetString("SoundStatus") == "On")
        {
            PlayerPrefs.SetString("SoundStatus", "Off");
            GetComponent<SoundButtonSpriteChanger>().setOffSpriteSoundButton();
            SetSoundsOff();
        }
        else if (PlayerPrefs.GetString("SoundStatus") == "Off")
        {
            SetSoundsOn();
            PlayerPrefs.SetString("SoundStatus", "On");
            GetComponent<SoundButtonSpriteChanger>().setOnSpriteSoundButton();
        }


    }
}
