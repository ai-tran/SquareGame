using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class platformStateSystem : MonoBehaviour {

    public GameObject[] platformState;
    public Vector3[] finalPos;

	// Use this for initialization
	void Start () {
        //for(int i = 0; i< platformState.Length; i++){ 
        //    finalPos[i] = platformState[i].transform.position;
        //}
        //foreach (GameObject go in platformState)
        //{
        //    go.transform.position = Vector3.zero;
        //}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.gameObject.tag == "Player")
        //{
        //    for (int i = 0; i < 16; i++)
        //    {
        //        platformState[i].transform.DOMove(finalPos[i], 2, false);
        //    }
        //}
    }
}
