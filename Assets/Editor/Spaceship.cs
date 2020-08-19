using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{

    public Rigidbody2D rb;

    public float MoveSpeed;

   // public JoyStick MoveJoystick;
    // Start is called before the first frame update
    void Start()
    {
        // use rigid body to move the spaceship
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public void Movement(float horizontal, float vertical)
    {
        // getting direction through arrow keys
        Vector2 InputDir = new Vector2(horizontal, vertical);
        rb.AddForce(InputDir * MoveSpeed);

        //rb.AddForce(MoveJoystick.InputDir * MoveSpeed);
    }
}
