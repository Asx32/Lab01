using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public Rigidbody Bullet;
    public Transform bOrigin;
    public float power;
    private Rigidbody projectile;
    private bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            projectile = Instantiate(Bullet, bOrigin.position, transform.rotation);
            isShooting = true;
        }
    }

    private void FixedUpdate()
    {
        if(isShooting)
        {
            projectile.velocity = transform.TransformDirection(Vector3.forward * power);
            isShooting = false;
            //Destroy(projectile.gameObject, 3);
        }
        
    }
}
