using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Player player;
    private Rigidbody2D gunRBody;
    void Awake()
    {
        gunRBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        gunRBody.velocity = player.rBody.velocity;
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
