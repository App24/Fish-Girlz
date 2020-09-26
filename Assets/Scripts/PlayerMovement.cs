using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed=80, maxSpeed=8;

    Rigidbody2D rb;
    Animator anim;

    bool transforming;

    enum TransformationState {Human, Mermaid};

    TransformationState transformationState=TransformationState.Human;

    List<Collision2D> waters=new List<Collision2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Water"){
            if(waters.Count<1)
                StartCoroutine(TransformIntoMermaid());
            waters.Add(other);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag=="Water"){
            waters.Remove(other);
            //Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>(), false);
        }
    }

    IEnumerator TransformIntoHuman(){
        if(!transforming){
            if(transformationState==TransformationState.Mermaid){
                yield return new WaitForSeconds(1f);
                if(waters.Count>0){
                     yield break;
                }
                transforming=true;
                float previousSpeed=speed;
                //speed=speed/4f;
                anim.Play(PlayerAnims.TRANSFORM_HUMAN.name);
                yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                //speed=previousSpeed;
                transforming=false;
                transformationState=TransformationState.Human;
            }

        }
    }

    IEnumerator TransformIntoMermaid(){
        if(!transforming){
            if(transformationState==TransformationState.Human){
                transforming=true;
                float previousSpeed=speed;
                //speed=speed/4f;
                anim.Play(PlayerAnims.TRANSFORM_MERMAID.name);
                yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                //speed=previousSpeed;
                transforming=false;
                transformationState=TransformationState.Mermaid;
            }
        }
    }

    private void Update() {
        if(waters.Count<1){
            StartCoroutine(TransformIntoHuman());
        }
    }
    
    private void FixedUpdate() {
        if(!transforming){
            PlayerAnim currentAnimation=transformationState==TransformationState.Human? PlayerAnims.WALK_FORWARD:PlayerAnims.SWIM_FORWARD;
            if(Input.GetKey(KeyCode.A)){
                rb.AddForce(Vector2.left*speed);
                currentAnimation=transformationState==TransformationState.Human? PlayerAnims.MOVEMENT[2]:PlayerAnims.SWIM[2];
            }else if(Input.GetKey(KeyCode.D)){
                rb.AddForce(Vector2.right*speed);
                currentAnimation=transformationState==TransformationState.Human? PlayerAnims.MOVEMENT[3]:PlayerAnims.SWIM[3];
            }else{
                rb.velocity=new Vector2(0, rb.velocity.y);
            }
            if(Input.GetKey(KeyCode.W)){
                rb.AddForce(Vector2.up*speed);
                currentAnimation=transformationState==TransformationState.Human? PlayerAnims.MOVEMENT[0]:PlayerAnims.SWIM[0];
            }else if(Input.GetKey(KeyCode.S)){
                rb.AddForce(Vector2.down*speed);
                currentAnimation=transformationState==TransformationState.Human? PlayerAnims.MOVEMENT[1]:PlayerAnims.SWIM[1];
            }else{
                rb.velocity=new Vector2(rb.velocity.x, 0);
            }
            anim.Play(currentAnimation.name);
            if(rb.velocity.sqrMagnitude>maxSpeed*maxSpeed){
                rb.velocity=new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed),Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));
            }
        }
    }
}

static class PlayerAnims{
    public static PlayerAnim WALK_FORWARD=new PlayerAnim("walk_forward");
    public static PlayerAnim WALK_BACKWARD=new PlayerAnim("walk_backward");
    public static PlayerAnim WALK_LEFT=new PlayerAnim("walk_left");
    public static PlayerAnim WALK_RIGHT=new PlayerAnim("walk_right");
    public static PlayerAnim[] MOVEMENT={WALK_FORWARD, WALK_BACKWARD, WALK_LEFT, WALK_RIGHT};
    public static PlayerAnim SWIM_FORWARD=new PlayerAnim("swim_forward");
    public static PlayerAnim SWIM_BACKWARD=new PlayerAnim("swim_backward");
    public static PlayerAnim SWIM_LEFT=new PlayerAnim("swim_left");
    public static PlayerAnim SWIM_RIGHT=new PlayerAnim("swim_right");
    public static PlayerAnim[] SWIM={SWIM_FORWARD, SWIM_BACKWARD, SWIM_LEFT, SWIM_RIGHT};
    public static PlayerAnim TRANSFORM_HUMAN=new PlayerAnim("transformation_human");
    public static PlayerAnim TRANSFORM_MERMAID=new PlayerAnim("transformation_mermaid");
}

struct PlayerAnim{
    public string name;

    public PlayerAnim(string name){
        this.name=name;
    }
}