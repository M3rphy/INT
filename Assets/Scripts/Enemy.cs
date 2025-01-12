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
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        
    
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
         if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            hp -= 1;
        }
        //if(other.gameObject.CompareTag("Enemy"))
        //{
        //    canMove = false;
        //    Debug.Log("bb");
        //}

    }
    
    
}
