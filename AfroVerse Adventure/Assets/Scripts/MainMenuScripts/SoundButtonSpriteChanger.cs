using UnityEngine;
using UnityEngine.UI;

public class SoundButtonSpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite _soundOnButton;
    [SerializeField] private Sprite _soundOffButton;

    [SerializeField] private Button _soundButton;

    private void OnEnable()
    {
        if (PlayerPrefs.GetString("SoundStatus") == "On")
            setOnSpriteSoundButton();
        else
            setOffSpriteSoundButton();
    }
    public void setOffSpriteSoundButton()
    {
        _soundButton.image.sprite = _soundOffButton;
    }

    public void setOnSpriteSoundButton()
    {
        _soundButton.image.sprite = _soundOnButton;
    }
}
