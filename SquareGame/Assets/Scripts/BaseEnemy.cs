using UnityEngine;
using System.Collections;

public class BaseEnemy : GameManager {

    public GameObject player;

	// Use this for initialization
	public override void Awake () {
        this.gameObject.GetComponent<Material>().color = Color.black;
        player = GameObject.FindGameObjectWithTag("Player");
        this.gameObject.tag = "Enemy";
	}


    void OnCollision2DEnter(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            targetPos(player.transform.position);
        }
    }

    Vector2 targetPos(Vector3 playerPos) {
        return this.gameObject.transform.position += player.transform.position;
    }
}
