using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the movement of door obstacles
/// </summary>
public class DoorObstacle : MonoBehaviour {

    #region VARIABLES
    [SerializeField]
    private float doorCloseY;
    [SerializeField]
    private float doorOpenY;
    private bool isDoorClosed = true;
    #endregion

    /// <summary>
    /// When the door is closed it will move up until it has reached a predefined height where it will then be set as being open (!closed)
    /// When the door is set as not closed, it will then move back down again until it reaches a predefined height where it will be set as closed
    /// </summary>
    void Update() {
        if (gameObject.transform.position.y <= doorOpenY && isDoorClosed) {
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
            // Transform will often go a few decimal places over when it stops meaning it will no longer equal exactly what it needs to,
            // So i used the Mathf.approximately fucntion to account for that
            if (Mathf.Approximately(doorOpenY, gameObject.transform.position.y)){
                isDoorClosed = false;
            }
        }
        else if (gameObject.transform.position.y >= doorCloseY && !isDoorClosed){
            gameObject.transform.position -= new Vector3(0, 0.1f, 0);
            if (Mathf.Approximately(doorCloseY, gameObject.transform.position.y)){
                isDoorClosed = true;
            }
        }
    }


}
