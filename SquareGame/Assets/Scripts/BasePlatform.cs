using UnityEngine;
using System.Collections;

public class BasePlatform : MonoBehaviour {

    public GameManager gm;

    Color platformColor;

    void Awake() {
        platformColor = this.gameObject.GetComponent<Renderer>().material.color;
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            if (this.gameObject.GetComponent<Renderer>().material.color == platformColor) {
                StartCoroutine("LerpColorOn", gm.playerColor);
            } else {
                StartCoroutine("LerpColorOn", this.gameObject.GetComponent<Renderer>().material.color);
            }
        }
        if (coll.gameObject.tag == "Enemy") {
            if (this.gameObject.GetComponent<Renderer>().material.color == platformColor) {
                StartCoroutine("LerpColorOn", Color.black);
            } else {
                StartCoroutine("LerpColorOn", this.gameObject.GetComponent<Renderer>().material.color);
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") { 
            StartCoroutine("LerpColorOff", gm.playerColor);
        }
        if (coll.gameObject.tag == "Enemy") {
            StartCoroutine("LerpColorOff", Color.black);
        }
    }

    public IEnumerator LerpColorOn(Color col) {
        float ElapsedTime = 0.0f;
        float TotalTime = 0.2f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(platformColor, col, (ElapsedTime / TotalTime));
            yield return null;
        }
    }

    public IEnumerator LerpColorOff() {
        float ElapsedTime = 0.0f;
        float TotalTime = 0.5f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, platformColor, (ElapsedTime / TotalTime));
            yield return null;
        }
    }

}
