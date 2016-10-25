using UnityEngine;
using System.Collections;

public class BluePlayer : BasePlayer
{
    void Start(){
        rigidB = this.gameObject.GetComponent<Rigidbody2D>();
        pSpeed = 10;
        delay = 0.5f;
    }

    public override void Update() {
        base.Update();
        if(inRange == false) {
            print("out of range");
        }
    }

}
