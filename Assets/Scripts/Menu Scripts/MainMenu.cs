using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/// <summary>
/// This class controls what happens on the main menu
/// </summary>
public class MainMenu : MonoBehaviour {
    
    #region VARIABLES
    [SerializeField]
    private GameObject volumeText;
    [SerializeField]
    private GameObject backButton;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject optionsButton;
    [SerializeField]
    private GameObject quitButton;

    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private AudioMixer musicMixer;
    #endregion

    #region UPDATE IN RUNTIME
    /// <summary>
    /// This is called when the 'play' button is pressed on the main menu, it loads the scene of the level.
    /// </summary>
    public void Play(){
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// This is called when the 'options' button is pressed, it sets the main menu buttons as inactive and the options menu UI elements as active
    /// </summary>
    public void Options(){
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        quitButton.SetActive(false);
        
        backButton.SetActive(true);
        volumeSlider.gameObject.SetActive(true);
        volumeText.SetActive(true);
    }

    /// <summary>
    /// This is called when the 'back' button in the options menu is pressed, it sets the options UI elements as inactive and activates the main menu buttons
    /// </summary>
    public void Back(){
        playButton.SetActive(true);
        optionsButton.SetActive(true);
        quitButton.SetActive(true);
        
        backButton.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        volumeText.SetActive(false);
    }

    /// <summary>
    /// This is called when the 'quit' button is pressed, it will close down the application
    /// </summary>
    public void CloseGame(){
        Application.Quit();
    }

    /// <summary>
    /// This is called when the value of the volume slider is changed.
    /// It sets the value of the volume of the music mixer to be equal to that of the value passed into the function from the volume slider.
    /// It then saves this value to the static float of game volume in the volume save script.
    /// </summary>
    /// <param name="volume"> A float is passed in from the volume slider </param>
    public void Volume(float volume){
        musicMixer.SetFloat("Volume", volume);
        VolumeSave.GameVolume = volume;
    }
    #endregion
}
