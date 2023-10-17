using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is the class that controls the movement of the ball object (including the ball, camera and force origin)
/// </summary>
public class BallControls : MonoBehaviour {

    #region VARIABLES
    [SerializeField]
    private float hitForce = 1f; // The force of which the ball will be hit, it is changed in ForceAdjust()
    [SerializeField]
    private Slider forceSlider;
    [SerializeField]
    private Transform hitPoint;
    
    public bool isMoving = false;

    private Vector3 previousVector;
    private Vector3 currentVector;
    public Vector3 lastSafeVector; // Last safe vector is the position at which the ball will return to if it falls off the map (its like a checkpoint for the ball)
    #endregion

    #region INITIALISE
    /// <summary>
    /// Sets the last safe vector to be starting position
    /// </summary>
    void Start(){
        lastSafeVector = gameObject.transform.localPosition;
    }
    #endregion

    #region UPDATED IN RUNTIME
    /// <summary>
    /// The DeltaVector3 function will be called at specific intervals (~50 times persecond, according to: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html)
    /// I put it in fixed update as i had an error where it was called too fast in update so when you hit the ball it would register as having stopped before it actually had,
    /// as update allowed it to be called before the ball had started actually moving.
    /// </summary>
    void FixedUpdate(){
        DeltaVector3();
    }

    /// <summary>
    /// This function is called when the 'Hit' button on the GUI is pressed.
    /// If the ball isnt already moving then a force will be applied to the ball to propel it forwards and it will be set as then moving.
    /// The increase score function in the parscore script attatched to the same gameobject as this script will also be called.
    /// </summary>
    public void HitBall(){
        if (!isMoving){
            // Adds the force to the ball. It is set as an impulse force so that it is just an initial force rather than continuous.
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * hitForce, hitPoint.position, ForceMode.Impulse);
            isMoving = true;
            this.GetComponent<ParScore>().IncreaseScore();
        }
        else{
            // Do nothing
        }
    }

    /// <summary>
    /// Checks what the change between current and previous vector is
    /// If it is zero then the ball will no longer be set as moving and the last safe vector will be updated to be current vector
    /// Otherwise the previous vector will be updated and the ball is still set as moving.
    /// </summary>
    private void DeltaVector3(){
        currentVector = gameObject.transform.localPosition; // CurrentVector is current position of ball

        // If the change in vector is equal to (0,0,0)
        if (currentVector - previousVector == Vector3.zero){
            isMoving = false;
            lastSafeVector = currentVector;
        }
        else{
            previousVector = currentVector;
            isMoving = true;
        }
    }

    /// <summary>
    /// This is called when the value of the slider on the game UI is changed, it sets the slider's value as the hitForce variable
    /// </summary>
    public void ForceAdjust(){
        hitForce = forceSlider.value;
    }
    #endregion
}
