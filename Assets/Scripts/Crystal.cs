using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private float value = 2f;
    public float colectebleRadius = 4f;
    private Rigidbody2D rb;
    private float distance;
    private float speed = 10f;
    private bool playerCollected = false;
    [SerializeField] private TrailRenderer tr;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = false;
        distance = Vector2.Distance(this.transform.position, player.transform.position);

    }

    void Update()
    {
        if (IsPlayerNear() && !playerCollected)
        {
            playerCollected = true;
        }
        if (playerCollected)
        {
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    private bool IsPlayerNear()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance < colectebleRadius)
        {
            tr.emitting = true;
            rb.isKinematic = false;
            GetComponent<Collider2D>().enabled = true;
            return true;
        }
        return false;
    }

   
}
