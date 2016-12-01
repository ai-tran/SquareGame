using UnityEngine;
using System.Collections;

public class Mike : BaseNPC {

    void Awake() {
        npcColor = new Color32(94, 191, 103, 255);
        npcChatOne = "I hate babies";
        npcName = "Mike";
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = true;
            anim.SetBool("MikeinRange", inRange);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = false;
            anim.SetBool("MikeinRange", inRange);
        }
    }


}
