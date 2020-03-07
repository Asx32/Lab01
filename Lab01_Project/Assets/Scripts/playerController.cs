using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float pSpeed = 1f;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement *= pSpeed *Time.deltaTime;
        transform.position += new Vector3(movement.x, movement.y, 0);        
    }
}
