using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriods : MonoBehaviour
{
    private float rotationSpeed;

    private Rigidbody2D rb;

    public float speed;

    private Vector2 direction;
    private float shift;

    private Spaceship ship;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ship = GameObject.FindObjectOfType<Spaceship>();
        direction = ship.transform.position - transform.position;
        shift = Random.Range(-5, 5);
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
        if(transform.position.x > 117 || transform.position.x < -117)
            Destroy(gameObject);
        if(transform.position.y > 69 || transform.position.y < -69)
            Destroy(gameObject);
    }
}
