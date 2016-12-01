using UnityEngine;
using System.Collections;

public class Jeff : BaseNPC {

    void Awake() {
        npcColor = new Color32(233, 172, 55, 255);
        npcChatOne = "Hey fellow square friend! Did you hear that\nFrank is throwing a party? He hasn't invited\nme yet, but I'm sure he's just been too busy.";
        npcName = "Jeff";
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = true;
            anim.SetBool("JeffinRange", inRange);
            npcImage.SetActive(false);
            jeffImage.gameObject.transform.localScale = new Vector3(0.9639118f, 0.9639118f, 0.9639118f);
            jeffImage.gameObject.GetComponent<SpriteRenderer>().color = npcColor;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = false;
            anim.SetBool("JeffinRange", inRange);
            jeffImage.gameObject.transform.localScale = new Vector3(0, 0, 0);
            npcImage.SetActive(true);
        }
    }


}
