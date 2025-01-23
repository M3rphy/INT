using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GombBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 2f;
    private float explosionTime = 0.1f;
    private float curTime;
    private float explosionSize;
    private float x;
    private bool isDetonate = false;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Explosion());
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
        if (isDetonate)
        {
                speed = 0;
        curTime += Time.deltaTime;
            if (curTime <= explosionTime)
            {

                explosionSize += 2;

                transform.localScale = new Vector2(explosionSize, explosionSize);
            }
            else
            {
                x += 1f;
                if (explosionSize / x < 1f)
                {
                    Destroy(gameObject);
                }
                transform.localScale = new Vector2(explosionSize / x, explosionSize / x);
            }
        }
    }
 
    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds (lifeTime);
        isDetonate = true;
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDetonate = true;
        }
    }
}
