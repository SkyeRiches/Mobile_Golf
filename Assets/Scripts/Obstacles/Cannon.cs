using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    #region VARIABLES
    [SerializeField]
    private GameObject explodeOrigin;
    private GameObject Ball;
    #endregion
    
    #region UPDATE IN RUNTIME
    /// <summary>
    /// When the Ball enters the collider it will start the fire cannon co-routine
    /// </summary>
    /// <param name="other"> The object collider that enters the trigger </param>
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Ball"){
            Ball = other.gameObject;
            StartCoroutine(FireCannon());
        }
    }

    /// <summary>
    /// This co-routine will wait 5 seconds (to allow the ball to fall to the back of the cannon) before applying an explosion force to the ball.
    /// </summary>
    private IEnumerator FireCannon(){
        yield return new WaitForSeconds(5);
        // Adds explosion force that is an impulse so it is only applied upon initial explosion.
        Ball.GetComponent<Rigidbody>().AddExplosionForce(200f, explodeOrigin.transform.position, 5f, 0f, ForceMode.Impulse);
    }
    #endregion
}
