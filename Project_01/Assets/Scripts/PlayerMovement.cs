using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xSpeed = 3.0f;
    public float ySpeed = 4.0f;
    private float hDir;
    private float vDir;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool doJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime * Speed *hDir;
        if(Input.GetButtonDown("Jump"))
        {
            doJump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hDir *xSpeed, rb.velocity.y);
        if(doJump)
        {
            if(!isJumping)
            {
                rb.AddForce(Vector2.up * ySpeed, ForceMode2D.Impulse);
                isJumping = true;
            }
            doJump = false;
        }
        if(rb.velocity.y == 0) isJumping = false;
    }
}
