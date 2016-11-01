using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour
{
    void Awake() {
        Instantiate(GameManager.instance.playerClass[0].gameObject);
        Instantiate(GameManager.instance.playerClass[1].gameObject);
    }

}
