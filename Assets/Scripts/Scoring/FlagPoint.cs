using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is what ends the game when the ball hits the flag
/// </summary>
public class FlagPoint : MonoBehaviour {

    /// <summary>
    /// If the Ball enters the trigger collider ont the flag, the boolean that checks if the game is over in the ParScore script is set as true
    /// and the next scene is loaded (the endgame scene)
    /// </summary>
    /// <param name="collider"> This is the collider that collides with the collider of the flag </param>
    private void OnTriggerEnter(Collider collider){
        if (collider.tag == "Ball"){
            collider.GetComponent<ParScore>().isLevelOver = true;
            SceneManager.LoadScene(3);
        }
    }
}
