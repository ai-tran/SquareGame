using UnityEngine;
using System.Collections;

public class RedPlayer : BasePlayer {

    void Start() {
        rigidB = this.gameObject.GetComponent<Rigidbody2D>();
        pSpeed = 10;
        delay = 0;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "PartyMember") {
            inRange = true;
            print("range");
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "PartyMember") {
            inRange = false;
        }
    }
}
