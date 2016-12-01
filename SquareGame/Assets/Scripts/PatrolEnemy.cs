using UnityEngine;
using System.Collections;

public class PatrolEnemy : MonoBehaviour {

    public ParticleSystem hitFx;
    public Vector3[] patrolPath;
    private int currentPoint;
    public float moveSpeed;
    private short patrolEnemyHp = 10;

    public bool passiveEnemy;

    Material thisMat;

    public bool inRange;

    public GameObject player;

    // Use this for initialization
    void Awake() {
        transform.position = patrolPath[0];
        currentPoint = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (inRange && !passiveEnemy) Attack(); else FollowPath();
        if(patrolEnemyHp == 0) {
            DestroyObject(this.gameObject);
        }

    }

    void FollowPath() {
        if (transform.position == patrolPath[currentPoint]) {
            currentPoint++;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
        }

        if (currentPoint >= patrolPath.Length) {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1);

            currentPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPath[currentPoint], moveSpeed * Time.deltaTime);
    }

    void Attack() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        //this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        for (int i = 0; i < patrolPath.Length; i++) {
            Gizmos.DrawWireSphere(patrolPath[i], 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = true;
            Attack();
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        inRange = false;
        //this.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    void Poisioned() {

    }

    void OnCollisionEnter2D(Collision2D col) { 
        if (col.gameObject.tag == "Bullet") {
            //StartCoroutine("Hit");
            hitFx.Play();
            patrolEnemyHp--;
        }
    }

    IEnumerator Hit() {
            this.gameObject.GetComponent<Renderer>().material.color = player.gameObject.GetComponent<Renderer>().material.color;
            yield return new WaitForSeconds(0.1f);
            this.gameObject.GetComponent<Renderer>().material.color = Color.black;
            yield return null;
        }
    }


