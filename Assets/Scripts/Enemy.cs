using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject crystalPrefab;
    public float hp = 2;
    public Transform target;
    public float speed = 3f;
    private Rigidbody2D rb;
    //private bool canMove = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(hp <= 0)
        {
            Instantiate(crystalPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (!target)
        {
            GetTarget();
        }
        
            Vector2 direction = target.position - transform.position;
        if(direction.x >0) 
        { 
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        
    
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            hp -= 1;
        }
        if (other.gameObject.CompareTag("Laser"))
        {
            hp = 0;
        }
        if (other.gameObject.CompareTag("BombBullet"))
        {
            hp -= 2/Vector2.Distance(this.transform.position, other.transform.position) + 1.5f ;
        }
    }




}
