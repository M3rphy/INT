using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Prêdkoœæ pocisku oraz jego czas ¿ycia
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;
    //Odniesienie do componentu RigidBody2D
    private Rigidbody2D rb;

    //przypisanie rb oraz ustawianie czasu zniszczenia obiektu
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // porusza sie w prosto w jednym kierunku z prêdkoœci¹ pocisku
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

}
