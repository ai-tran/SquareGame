using UnityEngine;
using System.Collections;

public abstract class BasePlayer : MonoBehaviour {

    public bool isPlayer;

    public bool isGrounded;
    public Color temp;
    public GameObject mainPlayer;
    public GameObject partyMember;
    public Color[] playerInstances;

    public int playerColorIndex;

    public Animator anim;

    public float playerSpeed;

    public float jumpSpeed = 10; 
    public GameManager gm;

    protected Rigidbody2D rb;

    public virtual void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        partyMember = GameObject.FindGameObjectWithTag("PartyMember").gameObject;
    }

    public virtual void Awake() {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").gameObject;
        anim = this.gameObject.GetComponent<Animator>();

    }

    public virtual void Update(){

        if (isPlayer) {
            baseMove();
        } else {
            followPlayer();
        }
    }

    /// <summary>
    /// Basic player movement, reads input moves player
    /// </summary>
    protected void baseMove()
    {
        float x = Input.GetAxis("Horizontal") * playerSpeed;
        float y = Input.GetAxis("Vertical") * playerSpeed;

        rb.velocity = new Vector2(x, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
            nextPartyMember();
        }
    }

    /// <summary>
    /// This gameobject follow "Main Player"
    /// </summary>
    public void followPlayer() {
        if (this.transform.position.x - mainPlayer.transform.position.x > 2 || this.transform.position.x - mainPlayer.transform.position.x < -2) {
            this.transform.position += new Vector3((mainPlayer.transform.position - this.gameObject.transform.position).normalized.x * 5 * Time.deltaTime, 0);
        }
    }

    /* Sets gameobject color*/
    /// <summary>
    /// Sets gameobject's colors to current color, used at start of game to set player color
    /// </summary>
    /// <param name="col">Gameobject's new color</param>
    public void setColor(Color col){
        gameObject.GetComponent<Renderer>().material.color = col;
    }

    /* Jump Function */
    protected void Jump() {
        rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        anim.SetTrigger("baseJump");
    }

    public void nextPartyMember() {
        temp = partyMember.gameObject.GetComponent<Renderer>().material.color;
        partyMember.gameObject.GetComponent<Renderer>().material.color = mainPlayer.gameObject.GetComponent<Renderer>().material.color;
        mainPlayer.gameObject.GetComponent<Renderer>().material.color = temp;
        gm.playerColor = temp;
    }



}