using UnityEngine;
using System.Collections;

public class RedPlayer : BasePlayer {

    void Start() {
        rigidB = this.gameObject.GetComponent<Rigidbody2D>();
        pSpeed = 10;
    }
}
