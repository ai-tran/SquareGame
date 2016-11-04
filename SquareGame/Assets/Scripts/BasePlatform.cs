using UnityEngine;
using System.Collections;

public class BasePlatform : MonoBehaviour {

    public GameManager gm;

    public GameObject bulletSpawn;

    Color matCol;

    void Awake() {
        matCol = this.gameObject.GetComponent<Renderer>().material.color;
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            if (this.gameObject.GetComponent<Renderer>().material.color == matCol) {
                StartCoroutine("LerpColorOn", matCol);
            } else {
                StartCoroutine("LerpColorOn", this.gameObject.GetComponent<Renderer>().material.color);
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") { 
            StartCoroutine("LerpColorOff", matCol);
        }
    }

    public IEnumerator LerpColorOn(Color fart) {
        float ElapsedTime = 0.0f;
        float TotalTime = 0.2f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(fart, gm.playerColor, (ElapsedTime / TotalTime));
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

    void Shoot() {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
    }

}
