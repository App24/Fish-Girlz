using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed=80, maxSpeed=8;

    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll=GetComponent<BoxCollider2D>();
    }
    
    private void FixedUpdate() {
        PlayerAnim currentAnimation=PlayerAnims.WALK_FORWARD;
        if(Input.GetKey(KeyCode.A)){
            rb.AddForce(Vector2.left*speed);
            currentAnimation=PlayerAnims.MOVEMENT[2];
        }else if(Input.GetKey(KeyCode.D)){
            rb.AddForce(Vector2.right*speed);
            currentAnimation=PlayerAnims.MOVEMENT[3];
        }else{
            rb.velocity=new Vector2(0, rb.velocity.y);
        }
        if(Input.GetKey(KeyCode.W)){
            rb.AddForce(Vector2.up*speed);
            currentAnimation=PlayerAnims.MOVEMENT[0];
        }else if(Input.GetKey(KeyCode.S)){
            rb.AddForce(Vector2.down*speed);
            currentAnimation=PlayerAnims.MOVEMENT[1];
        }else{
            rb.velocity=new Vector2(rb.velocity.x, 0);
        }
        anim.Play(currentAnimation.name);
        coll.size=currentAnimation.BBSize;
        if(rb.velocity.sqrMagnitude>maxSpeed*maxSpeed){
            rb.velocity=new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed),Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));
        }
    }
}

static class PlayerAnims{
    public static PlayerAnim WALK_FORWARD=new PlayerAnim("walk_forward", new Vector2(.85f, .96f));
    public static PlayerAnim WALK_BACKWARD=new PlayerAnim("walk_backward", new Vector2(.85f, .96f));
    public static PlayerAnim WALK_LEFT=new PlayerAnim("walk_left", new Vector2(0.67f, .6f));
    public static PlayerAnim WALK_RIGHT=new PlayerAnim("walk_right", new Vector2(0.67f, .6f));
    public static PlayerAnim[] MOVEMENT={WALK_FORWARD, WALK_BACKWARD, WALK_LEFT, WALK_RIGHT};
}

struct PlayerAnim{
    public string name;
    public Vector2 BBSize;

    public PlayerAnim(string name, Vector2 BBSize){
        this.name=name;
        this.BBSize=BBSize;
    }
}