using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSave : MonoBehaviour {

    /// <summary>
    /// This is the value of the volume for the music, it is modified via the volume slider that triggers a function in the menu scripts
    /// It has been made a static float so that it can be accessed between scenes
    /// </summary>
    /// <value> The value of the game volume </value>
    public static float GameVolume{
        get;
        set;
    }
}
