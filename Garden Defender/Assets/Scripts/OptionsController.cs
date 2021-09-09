using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    // TODO: Difficulty Slider

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        // TODO: Difficulty Slider
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found. Did you start from the splash screen?");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
        // TODO: Difficulty Slider
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        // TODO: Difficulty Slider
    }
}
