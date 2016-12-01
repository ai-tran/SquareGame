using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    bool inRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (inRange == true && Input.GetKey(KeyCode.W)) {
            SceneManager.LoadScene(2);
        }
	}

    void OnTriggerEnter2D() {
        inRange = true;
    }

    void OnTriggerExit2D() {
        inRange = false;
    }
}
