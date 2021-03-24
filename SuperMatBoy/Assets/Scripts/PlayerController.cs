using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private int jumps;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumps--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            jumps = 2;
        }
    }
}
