using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Force applied on the bullet in the downward direction
        GetComponent<Rigidbody2D>().AddForce(transform.up * 400f * (-1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillTheBullet()
    {
        //destroy bullet after 2 seconds
        Destroy(gameObject, 2f);
    }
}
