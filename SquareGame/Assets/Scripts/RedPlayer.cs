using UnityEngine;
using System.Collections;

public class RedPlayer : BasePlayer {

    public override void Start() {
        base.Start();
        setColor(gm.colorList[0]);
        playerSpeed = 10;
        isPlayer = true;
        maxHealth = 10;
    }

    public override void Update() {
        base.Update();
        Physics2D.IgnoreLayerCollision(8, 10, rb.velocity.y > 0);
    }
}
