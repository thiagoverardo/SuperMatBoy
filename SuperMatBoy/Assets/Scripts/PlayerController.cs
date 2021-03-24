using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private int jumps;
    private bool wallJump;
    private float lastMov;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        lastMov = 0f;
        rigid = GetComponent<Rigidbody2D>();
        jumps = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Move();  

        if (jumps > 0){

            Jump();
        }
    }

    void Move()
    {
        if(!wallJump){
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * speed;
            lastMov = movement.x;
        }        
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !wallJump)
        {
            rigid.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumps--;
        }
        else if(Input.GetButtonDown("Jump") && wallJump)
        {
            if (lastMov > 0)
            {
                rigid.AddForce(new Vector2(jumpForce/1.5f, jumpForce), ForceMode2D.Impulse);
                jumps--;
            }
            else if(lastMov < 0)
            {
                rigid.AddForce(new Vector2(-jumpForce/2, jumpForce), ForceMode2D.Impulse);
                jumps--;
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            jumps = 2;
            wallJump = false;
        }
        if(collision.gameObject.layer == 9)
        {
            wallJump = false;
        }
        else if(collision.gameObject.layer == 10)
        {
            jumps = 2;
            wallJump = true;
            lastMov = -lastMov;
        }
    }
}
