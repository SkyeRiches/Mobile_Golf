using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls what happens when the ball goes out of boundaries
/// </summary>
public class OutOfBounds : MonoBehaviour {

    /// <summary>
    /// If the ball enters the trigger collider underneath the map (only possible if the ball falls off the map),
    /// the ball will be returned to the position of the last safe vector that was stored in the ball controls script.
    /// This allows the player to not be stuck outside the map.
    /// </summary>
    /// <param name="other"> This is the collider that collides with the collider of the box beneath the map </param>
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Ball"){
            other.gameObject.transform.position = other.gameObject.GetComponent<BallControls>().lastSafeVector;
        }
    }
}
