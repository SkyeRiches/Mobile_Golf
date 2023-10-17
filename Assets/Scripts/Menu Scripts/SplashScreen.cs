using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class controls the splash screen that appears upon booting the game up
/// </summary>
public class SplashScreen : MonoBehaviour {
    
    /// <summary>
    /// The splash timer co-routine is called upon the scene loading
    /// </summary>
    void Start() {
        StartCoroutine(SplashTimer());
    }

    /// <summary>
    /// This co-routine will wait 2 seconds before loading the next scene (main menu scene)
    /// </summary>
    private IEnumerator SplashTimer(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
