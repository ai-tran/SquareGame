using UnityEngine;
using System.Collections;

public class Frank : BaseNPC {

    void Awake() {
        npcColor = new Color32(255, 86, 153, 255);
        npcChatOne = "Hey stranger! Party at my house. Be there or\nbe sphere! Hahah...... Also don't invite Jeff....\nsomething about him doesn't seem\nALL RIGHT.";
        npcName = "Frank";
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = true;
            anim.SetBool("FrankinRange", inRange);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = false;
            anim.SetBool("FrankinRange", inRange);
        }
    }


}


