using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTunnel : MonoBehaviour {

    [SerializeField]
    private Transform windOrigin;

    /// <summary>
    /// If the ball enters the trigger collider of the wind tunnel, it will have a force applied to it that originates from the wind origin.
    /// The force is an impulse so it is only applied upon initial entry
    /// </summary>
    /// <param name="other"> The collider of the obeject to enter the trigger </param>
    private void OnTriggerStay(Collider other){
        if (other.tag == "Ball"){
            other.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(windOrigin.transform.forward * 1f, windOrigin.position, ForceMode.Impulse);
        }
    }
}
