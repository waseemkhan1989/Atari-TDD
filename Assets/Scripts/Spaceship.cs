using System.Collections;
using System.Collections.Generic;
//using Assets.Editor;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D rb;
    public float MoveSpeed;
    public float rotationSpeed;
    public bool MouseButtonPressed { get; set; }

    public JoyStick ShootJoystick;
    public JoyStick MoveJoystick;

    public bool CanShoot;
    public float ShootRate;
    private float NextShoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        // If mouse is on the screen user wants to shoot
        if (Input.GetMouseButton(0))
        {
            MouseButtonPressed = true;
        }
        
        if (MouseButtonPressed && CanShoot)
        {
            if (NextShoot > 0)
                NextShoot -= Time.deltaTime;
            if (NextShoot <= 0)
                Shoot();
        }

        Movement();
        Rotation();
    }


    // to move spaceship left, right, up and downward
    public void Movement()
    {
        rb.AddForce(MoveJoystick.InputDir * MoveSpeed);
    }

    //Time to rotate Spaceship within 360 degree
    public void Rotation()
    {
        float angle = Mathf.Atan2(ShootJoystick.InputDir.y, ShootJoystick.InputDir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // ship moves from current rotation to the next rotation with a speed
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    // shoot bullets from spaceship
    public void Shoot()
    {
        NextShoot = ShootRate;
        GameObject bulletClone = Instantiate(bullet,
            new Vector2(bullet.transform.position.x, bullet.transform.position.y), transform.rotation);
        bulletClone.SetActive(true);
        
        bulletClone.GetComponent<Bullet>().KillTheBullet();
    }
}
