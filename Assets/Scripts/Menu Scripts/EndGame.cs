using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class controls the endgame scene that is shown when the player finishes the game
/// </summary>
public class EndGame : MonoBehaviour {
    
    /// <summary>
    /// This function is called when the 'menu' button is pressed, it loads the main menu scene
    /// </summary>
    public void MenuButton(){
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// This function is called when the 'quit' button is pressed, it will close the game down if it is in runtime 
    /// (does not work in editor but has been tested in a build on mobile device)
    /// </summary>
    public void QuitButton(){
        Application.Quit();
    }
}
