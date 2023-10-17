using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class tracks the player's score and saves it to a player pref if they beat their best score
/// </summary>
public class ParScore : MonoBehaviour {

    #region VARIABLES
    [SerializeField]
    private Text parText;

    private int currentScore = 0;
    private int bestPar;

    [HideInInspector]
    public bool isLevelOver = false;
    #endregion

    #region INITIALISE
    ///<summary>
    /// Upon the level being loaded, the best par score will be retrived from the player pref and assigned to a variable so that it is easy to use in code.
    /// It will then display the best and current par score in a text ui element in the scene.
    ///</summary>
    void Start(){
        bestPar = PlayerPrefs.GetInt("Par");
        // Displays the par of the course and current score on 2 different lines in a text UI object.
        parText.text = "Par: " + bestPar.ToString() + "\n Score: " + currentScore;
    }
    #endregion

    #region UPDATED IN RUNTIME
    ///<summary>
    /// This function is called when the ball is 'hit' in the ball controls script, it will increase the current score the player has,
    /// and will then update the UI text element in the scene to display the best and current scores.
    ///</summary>
    public void IncreaseScore(){
        currentScore++;
        parText.text = "Par: " + bestPar.ToString() + "\n Score: " + currentScore;
    }

    /// <summary>
    /// When the player hits the flag the game is then over and the player's score will be compared to the best score.
    /// Due to the rules of golf; the lower the score, the better they did. I have made it so that (at the end of the game) if they scored lower than their best,
    /// the best score in the playerpref will be updated.
    /// I have used a player pref so that the score can be saved between scenes and upon loading and quitting the game.
    /// </summary>
    private void Update(){
        if (isLevelOver){
            if (currentScore < bestPar){
                PlayerPrefs.SetInt("Par", currentScore);
            }
        }
    }
    #endregion
}
