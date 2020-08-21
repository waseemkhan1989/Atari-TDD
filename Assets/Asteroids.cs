using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private float rotationSpeed;

    private Rigidbody2D rb;

    public float speed;

    public Vector3 direction;
    private float shift;

    public float boundLeft, boundRight, boundUp, boundDown;
    
    // private Spaceship ship;
    // Start is called before the first frame update
    // void Start()
    public void Initialize(Vector3 targetPosition)
    {
        rb = GetComponent<Rigidbody2D>();
        // ship = GameObject.FindObjectOfType<Spaceship>();
        // direction = ship.transform.position - transform.position;
        direction = targetPosition - transform.position;
        shift = Random.Range(-7, 7);
        rb.AddForce(new Vector2(direction.x + shift, direction.y + shift) * speed);
        
        
        rotationSpeed = Random.Range(-25, 25);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,rotationSpeed) * Time.deltaTime);
    }

    public void CheckPosition()
    {
        if(transform.position.x > boundRight ||
           transform.position.x < boundLeft ||
           transform.position.y > boundUp ||
           transform.position.y < boundDown ) 
            DestroyImmediate(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "bullet(Clone)")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

    }
    
}
