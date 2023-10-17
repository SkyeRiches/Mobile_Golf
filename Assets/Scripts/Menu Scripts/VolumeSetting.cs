using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the initial position of the volume slider
/// </summary>
public class VolumeSetting : MonoBehaviour {
    
    /// <summary>
    /// Upon the volume slider being set as active, the value stored in the game volume static int in volume save will be applied to the slider, 
    /// this means the volume between scenes is saved and the position of the slider is saved between scenes.
    /// </summary>
    private void Awake(){
        gameObject.GetComponent<Slider>().value = VolumeSave.GameVolume;
    }
}
