using UnityEngine;
using System.Collections;

public class BluePlayer : BasePlayer
{
    void Start(){
        rigidB = this.gameObject.GetComponent<Rigidbody2D>();
        pSpeed = 10;
    }

}
