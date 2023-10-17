using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObstacle : MonoBehaviour {

    /// <summary>
    /// The spinning object are constantly rotating as soon as the game starts
    /// </summary>
    void FixedUpdate() {
        gameObject.transform.Rotate(0, 3, 0, Space.Self);
    }
}
