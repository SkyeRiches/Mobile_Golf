using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class allows the player to control the left and right roatation using swiping with their finger
/// </summary>
public class TouchControls : MonoBehaviour {
    
    #region REFERENCES
    //https://docs.unity3d.com/Manual/MobileInput.html
    #endregion

    #region VARIABLES
    private float sensitivity = 3f;
    #endregion

    /// <summary>
    /// When the player moves their finger across the screen it will get the change in position, multiply it by a sensitivity factor and apply that over time.
    /// </summary>
    void Update() {
        // If at least 1 finger is touching the screen
        if (Input.touchCount > 0){
            // Only use the first finger to touch the screen
            Touch touch1 = Input.GetTouch(0);
            gameObject.transform.Rotate(0, touch1.deltaPosition.x * sensitivity * Time.deltaTime, 0, Space.Self);
        }
    }
}
