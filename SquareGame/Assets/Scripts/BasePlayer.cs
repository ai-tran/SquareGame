using UnityEngine;
using System.Collections;
using DG.Tweening;

public abstract class BasePlayer : MonoBehaviour {

    //Player Checks
    public bool isPlayer;
    public bool isGrounded;
    public bool isInvincible;
    public bool canJump = true;
    public bool canMove = true;

    public Color temp;
    public GameObject mainPlayer;
    public GameObject partyMember;

    //Player Settings
    public float jumpSpeed = 10;
    public float maxHealth;
    public float health;
    public float playerSpeed;

    //Assign Objects
    public GameManager gm;
    public GameObject bullet;
    
    //Assign Components
    public Animator anim;
    public AudioSource audioSource;
    protected Rigidbody2D rb;

    //Camera Shake Settings
    public float duration = 1.0f;
    public float magnitude = 1.0f;

    //FX
    public ParticleSystem poison;

    //Audio
    public AudioClip hitSfx;
    public AudioClip jumpSfx;
    public AudioClip shootSfx;

    //what the fuck is this
    public int playerColorIndex;


    
    public virtual void Start() {
        isInvincible = false;
        health = maxHealth;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        partyMember = GameObject.FindGameObjectWithTag("PartyMember").gameObject;
    }

    public virtual void Awake() {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").gameObject;
        anim = this.gameObject.GetComponent<Animator>();

    }

    public virtual void Update() {

        if (isPlayer) {
            baseMove();
            PlayerSkill(playerColorIndex);
        } else {
            followPlayer();
        }

    }

    /// <summary>
    /// Basic player movement, reads input moves player
    /// </summary>
    protected void baseMove() {
        float x = Input.GetAxis("Horizontal") * playerSpeed;
        float y = Input.GetAxis("Vertical") * playerSpeed;

        rb.velocity = new Vector2(x, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) {
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
        if (this.transform.position.x - mainPlayer.transform.position.x > 20 || this.transform.position.x - mainPlayer.transform.position.x < -20) {
            this.transform.position = new Vector3(mainPlayer.transform.position.x, mainPlayer.transform.position.y + 2, mainPlayer.transform.position.z);
        }
    }

    /* Sets gameobject color*/
    /// <summary>
    /// Sets gameobject's colors to current color, used at start of game to set player color
    /// </summary>
    /// <param name="col">Gameobject's new color</param>
    public void setColor(Color col) {
        gameObject.GetComponent<Renderer>().material.color = col;
    }

    /* Jump Function */
    protected void Jump() {
        rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        anim.SetTrigger("baseJump");
        audioSource.PlayOneShot(jumpSfx);

    }

    public void nextPartyMember() {
        temp = partyMember.gameObject.GetComponent<Renderer>().material.color;
        partyMember.gameObject.GetComponent<Renderer>().material.color = mainPlayer.gameObject.GetComponent<Renderer>().material.color;
        mainPlayer.gameObject.GetComponent<Renderer>().material.color = temp;
        gm.playerColor = temp;
        playerColorIndex++;
        if (playerColorIndex >= 2) {
            playerColorIndex = 0;
        }
    }

    void PlayerSkill(int playerSkillIndex) {
        switch (playerColorIndex) {
            case 0: ShootSkill();
                break;
            case 1: Poison();
                break;
        }
    }


    void ShootSkill() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = new Vector2(this.transform.position.x, this.transform.position.y);
            Vector2 direction = mousePos - myPos;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(bullet, myPos, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * 30;
            audioSource.PlayOneShot(shootSfx);
        }
    }

    void Poison() {
        if (Input.GetMouseButtonDown(0)) {
            poison.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Enemy") {
            if (isInvincible == false) {
                Camera.main.DOShakePosition(0.5f, 2, 2, 90);
                anim.SetTrigger("Hit");
                health--;
                Debug.Log("Losing Health");
                audioSource.PlayOneShot(hitSfx);
                //this.gameObject.GetComponent<Renderer>().material.color = gm.playerColor * (health / maxHealth);
                isInvincible = true;
            }
        }
    }

}