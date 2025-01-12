using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
        if(GetComponent<Collider2D>().enabled == false)
        {

            StartCoroutine(x());
        }
        rb.velocity = transform.up * speed;
    }
    private IEnumerator x()
    {
        yield return new WaitForSeconds(0.05F);
        GetComponent<Collider2D>().enabled = true;
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
        if (other.gameObject.CompareTag("Bullet"))
        {
            GetComponent<Collider2D>().enabled = false;
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
