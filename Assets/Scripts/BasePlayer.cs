using UnityEngine;
using System.Collections;

public abstract class BasePlayer : GameManager {

    public GameObject[] playerParty;

    public bool isGrounded;

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
        GameManager gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        anim = this.gameObject.GetComponent<Animator>();
        setColor(gm.pColor);
    }

    public virtual void Update(){
        baseMove();
    }

    protected void baseMove()
    {
        float x = Input.GetAxis("Horizontal") * pSpeed;
        float y = Input.GetAxis("Vertical") * pSpeed;

        rb.velocity = new Vector2(x, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            anim.SetTrigger("RedWalk");
        }

    }

    public void setColor(Color col)
    {
        gameObject.GetComponent<Renderer>().material.color = col;
    }

    void hurt() {
    }

}