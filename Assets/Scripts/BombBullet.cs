using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    //Przedko�� oraz czas �ycia obiektu
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 2f;
    //Czas trwania eksplozji
    private float explosionTime = 0.1f;
    private float curTime;
    //Wielko�� eksplozji
    private float explosionSize;
    private float x;
    private bool isDetonate = false;
    //Odniesienie do componentu RigidBody2D
    private Rigidbody2D rb;

    //Przypisanie rb oraz zadeklarowanie czasu eksplozji 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Explosion());
    }

    //przemieszcza sie w prostym kierunku z podan� pr�dko�ci� 
    //je�li zostanie zdetonowana to bomba najpierw sie powi�ksza o p�niej zmniejsza i obiekt znika
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
    
    //Po czasie �ycia ustawia IsDetonate na true
    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds (lifeTime);
        isDetonate = true;
    }

    //kolizja kt�ra gdy bomba dotkie przeciwnika ustawia IsDetonate na true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDetonate = true;
        }
    }
}
