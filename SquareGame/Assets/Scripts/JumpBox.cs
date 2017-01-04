using UnityEngine;
using System.Collections;

public class JumpBox : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "PartyMember") {
            //col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0f), ForceMode2D.Impulse);
            //col.gameObject.GetComponent<Animator>().SetTrigger("baseJump");
            Destroy(this.gameObject);
        }
    }
}
