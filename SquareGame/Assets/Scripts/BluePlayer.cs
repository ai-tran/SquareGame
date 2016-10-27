using UnityEngine;
using System.Collections;

public class BluePlayer : BasePlayer{

    void Start(){
        rigidB = this.gameObject.GetComponent<Rigidbody2D>();
        pSpeed = 0;
        delay = 2f;
    }

    void FixedUpdate() {
        if (this.transform.position.x - mainPlayer.transform.position.x > 2 || this.transform.position.x - mainPlayer.transform.position.x < -2) {
            this.transform.position += new Vector3((mainPlayer.transform.position - this.gameObject.transform.position).normalized.x * 5 * Time.deltaTime,0);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "JumpBox") {
            Jump();
        }
    }

}
