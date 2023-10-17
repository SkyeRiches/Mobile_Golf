using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will set the value of the par in the player prefs for par as 10 if it hasnt already been altered.
/// </summary>
public class InitialScore : MonoBehaviour {
    
    private int coursePar = 10;

    /// <summary>
    /// If the par hasnt been altered, which will only happen on first boot up of the game, the par will be at 0
    /// Due to golf working on lowest score this will never get over written as you cant get a score lower than 0
    /// Therefore I have made it so that upon the first loading of the game the par will be set at 10,
    /// This will be overwritten if the player beats it, otherwise it will always be 10.
    /// 
    /// In theory this script should only work once, the first time the game is launched.
    /// </summary>
    void Start(){
        if(!PlayerPrefs.HasKey("Par")){
            PlayerPrefs.SetInt("Par", coursePar);
        }
    }
}
