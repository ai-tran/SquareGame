using UnityEngine;
using System.Collections;

public class BasePlatform : GameManager {

    public Color test;
    public GameManager gm;

    public override void Awake() {
        GameManager gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        test = gm.pColor;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            if (this.gameObject.GetComponent<Renderer>().material.color == Color.white) {
                StartCoroutine("LerpColorOn", Color.white);
            } else {
                StartCoroutine("LerpColorOn", this.gameObject.GetComponent<Renderer>().material.color);
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {

            StartCoroutine("LerpColorOff", Color.white);

        }
    }

    public IEnumerator LerpColorOn(Color fart) {
        float ElapsedTime = 0.0f;
        float TotalTime = 0.2f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(fart, test, (ElapsedTime / TotalTime));
            yield return null;
        }
    }

    public IEnumerator LerpColorOff(Color farts) {
        float ElapsedTime = 0.0f;
        float TotalTime = 0.5f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, farts, (ElapsedTime / TotalTime));
            yield return null;
        }
    }

}
