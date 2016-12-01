using UnityEngine;
using System.Collections;

public class FirstCompanion : BasePlayer{


    public override void Start(){
        base.Start();
        setColor(gm.colorList[1]);
        playerSpeed = 0;
        isPlayer = false;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "JumpBox") {
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        canJump = true;
     }
    

    public override void Update() {
        base.Update();
        Physics2D.IgnoreLayerCollision(9, 10, this.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0);
    }

    IEnumerator jumpRestTime() {
        yield return new WaitForSeconds(3.0f);
    }

}
