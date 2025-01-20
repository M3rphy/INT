using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
       
        rb.velocity = transform.up * speed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Crystal"))
       {
            rb.bodyType = RigidbodyType2D.Kinematic;

        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Crystal"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
      

    }
    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Crystal"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
       

    }
}
