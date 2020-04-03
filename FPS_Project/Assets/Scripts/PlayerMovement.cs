using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerChar;
    public float playerSpeed = 10;
    public Transform groundCheck;   //sfera? do sprawdzania kolizji z podłożem
    public float groundDist = 0.2f; //promień sfery ^
    public LayerMask groundLayer;   //podłoże
    private float xDir;
    private float yDir;
    private float zDir;
    private Vector3 moveDir;
    private bool isGrounded;
    private float jumpForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayer);
        if(isGrounded && (yDir<0))
        {
            yDir = -2;
        }
        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");
        yDir += Physics.gravity.y * Time.deltaTime;

        moveDir = transform.right*xDir*playerSpeed + transform.forward*zDir*playerSpeed + transform.up*yDir;
        playerChar.Move(moveDir * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            yDir = Mathf.Sqrt(jumpForce * -2 * Physics.gravity.y);
        }
    }
}
