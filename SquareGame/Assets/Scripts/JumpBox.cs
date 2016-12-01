using UnityEngine;
using System.Collections;

public class JumpBox : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "partyMember") {
            //col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0f), ForceMode2D.Impulse);
            //anim.SetTrigger("baseJump");
            //Destroy(this.gameObject);
        }
    }
}
