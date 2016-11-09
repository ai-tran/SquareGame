using UnityEngine;
using System.Collections;

public class Mike : MonoBehaviour {

    public GameObject Player;

    public GameObject speechBubble;
    public GameObject UIElement;
    public TextMesh npcSpeechtext;
    public TextMesh npcNameText;
    public GameObject npcImage;

    private string npcChatOne = "I hate babies";

    int caseSpeech = 0;

    bool uiIsOn;
    bool inRange;
    bool hasTalkedTo;

    Color npcColor = new Color32(94, 191, 103, 255);

    void Update() {
        if (Input.GetKeyDown("q")) {
            if (inRange) {
                npcNameText.text = "Mike";
                npcImage.GetComponent<SpriteRenderer>().color = npcColor;
                speechBubble.gameObject.SetActive(false);
                if (uiIsOn == false) {
                    turnOnUI();
                    uiIsOn = true;
                }else {
                    UIElement.gameObject.SetActive(false);
                    npcSpeechtext.text = "";
                    uiIsOn = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = false;
        }
    }

    void turnOnUI() {
        UIElement.gameObject.SetActive(true);
        Talk();
    }

    void Talk() {
        switch (caseSpeech) {
            case 0: StartCoroutine(printText(npcChatOne));
                break;
            case 1:
                npcSpeechtext.text = "farts";
                break;
        }
    }

    IEnumerator printText(string text) {
        npcSpeechtext.text = "";
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < text.Length;) {
            yield return new WaitForSeconds(0.03f);
            npcSpeechtext.text += text[i++];
        }
    }

}
