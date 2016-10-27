using UnityEngine;
using System.Collections;

public abstract class BasePlayer : GameManager {

    public float delay;

    public GameObject[] playerParty;

    public bool isGrounded;
    public GameObject mainPlayer;
    public GameObject partyMember;

    public Animator anim;

    public float playerSpeed;
    public float pSpeed
    {
        get { return playerSpeed; }
        set { playerSpeed = value; }
    }

    public float jumpSpeed = 10; 
    GameManager gm;

    private Rigidbody2D rb;
    protected Rigidbody2D rigidB
    {
        get { return rb; }
        set { rb = value; }
    }

    public override void Awake() {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").gameObject;
        //partyMember = GameObject.FindGameObjectWithTag("PartyMember").gameObject;


        GameManager gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        anim = this.gameObject.GetComponent<Animator>();
        setColor(gm.pColor);
    }

    public virtual void Update(){
        Physics2D.IgnoreLayerCollision (8, 9, rb.velocity.y > 0);
        Physics2D.IgnoreLayerCollision(8,8);
        baseMove();
    }

    protected void baseMove()
    {
        float x = Input.GetAxis("Horizontal") * pSpeed;
        float y = Input.GetAxis("Vertical") * pSpeed;

        rb.velocity = new Vector2(x, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    public void setColor(Color col){
        gameObject.GetComponent<Renderer>().material.color = col;
    }

    protected void Jump() {
        rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        anim.SetTrigger("RedWalk");
    }

}