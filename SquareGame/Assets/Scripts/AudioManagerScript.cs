using UnityEngine;
using System.Collections;

public class AudioManagerScript : MonoBehaviour {

    public AudioClip[] backgroundMusic;
    public AudioClip[] sfx;

    int level = 0;

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<AudioSource>().clip = backgroundMusic[level];
        this.gameObject.GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
