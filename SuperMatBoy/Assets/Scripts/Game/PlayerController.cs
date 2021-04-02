using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Renderer rend;
    private Rigidbody2D rigid;
    private Animator anim;
    public Transform startingPosition;
    public float maxSpeed = 10;
    public float acceleration = 35;
    public float jumpSpeed = 8;
    public float jumpDuration;
    public bool wallHitDJOverride = true;
    int jump = 2;
    bool wallJump = false;
    float jmpDuration;
    bool timeOut = false;
    float horizontal;
    float timer = 0f;

    bool jumpKewDown = false;
    bool canVariableJump = false;
    bool onTheGround = false;
    public bool moving;
    GameManager gm;

    public GameObject blood;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // transform.position = startingPosition.position + new Vector3(-3, 2, 0);
        transform.position = new Vector3(-36, 22, 0);
        moving = true;
        gm = GameManager.GetInstance();
    }


    void Update()
    {
        if(moving){
            if(timeOut){
                horizontal = 0f;
                timer += Time.deltaTime;
                if(timer > 0.5f){
                    timeOut = false;
                }
            }

            if(!timeOut){
                horizontal = Input.GetAxis("Horizontal");
            }

            Vector3 charScale = transform.localScale;

            anim.SetFloat("VelX", Mathf.Abs(horizontal));

            if (horizontal < 0)
            {
                charScale.x = -0.268504f;
                if (rigid.velocity.x > -this.maxSpeed)
                {
                    rigid.AddForce(new Vector2(-this.acceleration, 0f));

                }
                else
                {
                    rigid.velocity = new Vector2(-this.maxSpeed, rigid.velocity.y);
                }
            }
            if (horizontal > 0)
            {
                charScale.x = 0.268504f;
                if (rigid.velocity.x < this.maxSpeed)
                {
                    rigid.AddForce(new Vector2(this.acceleration, 0f));
                }
                else
                {
                    rigid.velocity = new Vector2(this.maxSpeed, rigid.velocity.y );
                }
            }

            transform.localScale = charScale;

            if(rigid.velocity.y > 0.6f){
                anim.SetBool("IsFalling", false);
                anim.SetBool("IsJumping", true);
            }

            if(rigid.velocity.y < -0.6f){
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsFalling", true);
            }

            if(rigid.velocity.y <= 0.6f && rigid.velocity.y >= -0.6f){
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsFalling", false);
            }        

            float vertical = Input.GetAxis("Vertical");

            if (onTheGround)
            {
                jump = 2;
            }

            if (Input.GetButtonDown("Jump") && jump > 0 && !timeOut)
            {
                if (!jumpKewDown)
                {
                    jumpKewDown = true;
                    if (onTheGround || wallHitDJOverride)
                    {
                        bool wallHit = false;
                        int wallHitDirection = 0;
                        onTheGround = false;

                        bool leftWallHit = isWallOnLeft();
                        bool rightWallHit = isWallOnRight();

                        if (horizontal != 0)
                        {
                            if (leftWallHit)
                            {
                                wallHit = true;
                                wallHitDirection = 1;
                                jump = 2;
                            }
                            else if (rightWallHit)
                            {
                                wallHit = true;
                                wallHitDirection = -1;
                                jump = 2;
                            }
                        }
                        if (!wallHit)
                        {
                            rigid.velocity = new Vector2(rigid.velocity.x, this.jumpSpeed);                        

                            jmpDuration = 0.0f;

                            canVariableJump = true;

                            jump--;
                        }
                        else
                        {
                            rigid.velocity = new Vector2(this.jumpSpeed * wallHitDirection, this.jumpSpeed * 1.2f);

                            jmpDuration = 0.0f;

                            canVariableJump = true;

                            jump--;
                        }

                    }
                    else if (canVariableJump)
                    {
                        jmpDuration += Time.deltaTime;

                        if (jmpDuration < this.jumpDuration / 1000 && jump > 0)
                        {
                            rigid.velocity = new Vector2(rigid.velocity.x, this.jumpSpeed);
                            jump--;
                        }
                    }
                }
            }
            else
            {
                jumpKewDown = false;
                canVariableJump = false;
            }

        }
        else{
            rigid.velocity = new Vector2(0f, 0.6f);
        }
        
        
    }

    private bool isWallOnLeft()
    {
        if (wallJump)
        {
            bool retVal = false;
            float lenghtToSearch = 0.1f;
            float colliderTreshold = 0.01f;

            Vector2 linestart = new Vector2(this.transform.position.x - this.rend.bounds.extents.x - colliderTreshold, this.transform.position.y);

            Vector2 vectorToSearch = new Vector2(linestart.x - lenghtToSearch, this.transform.position.y);

            RaycastHit2D hitLeft = Physics2D.Linecast(linestart, vectorToSearch);

            retVal = hitLeft;

            return retVal;
        }
        else
        {
            return false;
        }
    }

    private bool isWallOnRight()
    {
        if (wallJump)
        {
            bool retVal = false;
            float lenghtToSearch = 0.1f;
            float colliderTreshold = 0.01f;

            Vector2 linestart = new Vector2(this.transform.position.x + this.rend.bounds.extents.x + colliderTreshold, this.transform.position.y);

            Vector2 vectorToSearch = new Vector2(linestart.x + lenghtToSearch, this.transform.position.y);

            RaycastHit2D hitRight = Physics2D.Linecast(linestart, vectorToSearch);

            retVal = hitRight;

            return retVal;
        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            wallJump = true;
            onTheGround = true;
        }
        if (collision.gameObject.layer == 9)
        {
            wallJump = false;
        }
        if (collision.gameObject.layer == 10)
        {
            wallJump = true;
            jump = 2;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("pushingTrapBot"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 20);
            jump = 1;
        }
        if (col.CompareTag("pushingTrapLeft"))
        {
            rigid.velocity = new Vector2(20, rigid.velocity.y);
            jump = 1;
            timeOut = true;
            timer = 0f;
        }
        if (col.CompareTag("pushingTrapRight"))
        {
            rigid.velocity = new Vector2(-20, rigid.velocity.y);
            jump = 1;
            timeOut = true;
            timer = 0f;
        }
        if (col.CompareTag("sawTrap"))
        {
            gm.lifes--;
            gm.died = true;
            moving = false;
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (col.CompareTag("Finish"))
        {
            anim.SetTrigger("Win");
            gm.levelPassed = true;
        }
    }
}
