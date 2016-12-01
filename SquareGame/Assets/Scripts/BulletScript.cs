using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            DestroyObject(this.gameObject);
        }
    }
}
