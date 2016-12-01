using UnityEngine;
using System.Collections;

public abstract class BaseNPC : MonoBehaviour {

   GameObject Player;

    public GameObject speechBubble;
    public GameObject UIElement;
    public TextMesh npcSpeechtext;
    public TextMesh npcNameText;
    public GameObject npcImage;
    public GameObject jeffImage;

    

    public string npcName;

    public Animator anim;

    public string npcChatOne = "default text";

    int caseSpeech = 0;

    bool uiIsOn;
    public bool inRange;
    public bool hasTalkedTo;

    public Color npcColor;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (Input.GetKeyDown("q")) {
            if (inRange) {
                npcNameText.text = npcName;
                npcImage.GetComponent<SpriteRenderer>().color = npcColor;
                speechBubble.gameObject.SetActive(false);
                if (uiIsOn == false) {
                    turnOnUI();
                    uiIsOn = true;
                } else {
                    anim.SetTrigger("NpcImageExit");
                    npcSpeechtext.text = "";
                    uiIsOn = false;
                    UIElement.gameObject.SetActive(false);
                }
            }
        }
    }


    void turnOnUI() {
        UIElement.gameObject.SetActive(true);
        Talk();
    }

    void Talk() {
        switch (caseSpeech) {
            case 0:
                StartCoroutine(printText(npcChatOne));
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
