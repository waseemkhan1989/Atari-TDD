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
    
    public JoyStick ShootJoystick;
    public JoyStick MoveJoystick;
    
    public bool CanShoot;
    public float ShootRate;
    private float NextShoot;
    //public Vector2 InputDir;
    
    //private SpaceshipEngine m_SpaceshipEngine;

    
    // Start is called before the first frame update
    void Start()
    {
        // use rigid body to move the spaceship
       // m_SpaceshipEngine = this.gameObject.AddComponent<SpaceshipEngine>();
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // If mouse is on the screen user wants to shoot
        if (Input.GetMouseButton(0) && CanShoot
                                    )
        {
            if (NextShoot > 0)
                NextShoot -= Time.deltaTime;
            if (NextShoot <= 0)
                Shoot(); 
        }
        Movement();
        Rotation();    
    }

    public void Movement()
    {
         

        // getting direction through arrow keys
        //Vector2 InputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //rb.AddForce(InputDir * MoveSpeed);

        rb.AddForce(MoveJoystick.InputDir * MoveSpeed);
        //m_SpaceshipEngine.AddForce();
    }

    void Rotation()
    {
        float angle = Mathf.Atan2(ShootJoystick.InputDir.y, ShootJoystick.InputDir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // ship moves from current rotation to the next rotation with a speed
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    public void Shoot()
    {
        NextShoot = ShootRate;
        GameObject bulletClone = Instantiate(bullet,
            new Vector2(bullet.transform.position.x, bullet.transform.position.y), transform.rotation); 
        bulletClone.SetActive(true);
        bulletClone.GetComponent<Bullet>().KillTheBullet();
    }



    /*   void Update()
    {
        Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       
    }
*/
    /*public void Movement(float horizontal, float vertical)
    {
         

        // getting direction through arrow keys
        InputDir = new Vector2(horizontal, vertical);
        rb.AddForce(InputDir * MoveSpeed);

        //rb.AddForce(MoveJoystick.InputDir * MoveSpeed);
        //m_SpaceshipEngine.AddForce();
    }*/
}
