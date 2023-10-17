using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

/// <summary>
/// This class controls what happens on the pause menu
/// </summary>
public class PauseMenu : MonoBehaviour {
    
    #region VARIABLES
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameUI;
    [SerializeField]
    private GameObject volumeText;
    [SerializeField]
    private GameObject backButton;
    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject optionsButton;
    [SerializeField]
    private GameObject menuButton;

    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private AudioMixer musicMixer;

    private bool isPaused = false;
    #endregion

    #region UPDATE IN RUNTIME
    /// <summary>
    /// This is called when the player presses the 'menu' button in the level,
    /// If the game is not already paused then it will set the time scale as 0 and will bring up the pause menu GUI and deactivate the game UI and set paused as true,
    /// If it is already paused then it will do the opposite and set the time scale as 1.
    /// </summary>
    public void PauseGame(){
        if (!isPaused){
            Time.timeScale = 0f;
            gameUI.SetActive(false);
            pauseMenu.SetActive(true);
            isPaused = true;
        }
        else if(isPaused){
            Time.timeScale = 1f;
            gameUI.SetActive(true);
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    /// <summary>
    /// This is called when the 'options' button is pressed, it sets the main pause menu buttons as inactive and the options menu UI elements as active
    /// </summary>
    public void Options(){
        resumeButton.SetActive(false);
        optionsButton.SetActive(false);
        menuButton.SetActive(false);
        
        backButton.SetActive(true);
        volumeSlider.gameObject.SetActive(true);
        volumeText.SetActive(true);
    }

    /// <summary>
    /// This is called when the 'back' button in the options menu is pressed, it sets the options UI elements as inactive and activates the main pause menu buttons
    /// </summary>
    public void Back(){
        resumeButton.SetActive(true);
        optionsButton.SetActive(true);
        menuButton.SetActive(true);
        
        backButton.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        volumeText.SetActive(false);
    }

    /// <summary>
    /// This is called when the 'main menu' button is pressed on the pause menu, it loads the main menu scene upon being called.
    /// The time scale is also set back to 1 so that time is not frozen if the scene is realoaded from the main menu
    /// </summary>
    public void Menu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
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
