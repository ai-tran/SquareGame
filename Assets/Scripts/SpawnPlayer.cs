using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour
{
    Transform posOffset;


    void Awake() {
        Instantiate(GameManager.instance.playerClass[GameManager.instance.classIndex].gameObject);
        //Instantiate(GameManager.instance.playerClass[1].gameObject, posOffset);
    }

}
