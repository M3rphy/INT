using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private SpriteRenderer sprite;
    private CapsuleCollider2D collider;
    private LineRenderer line;
    [SerializeField] private float existTime = 2f;

    private float x;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<CapsuleCollider2D>();
         
        line.SetPosition(0, transform.position);
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        const float length = 1000.0f;
        var endPos = new Vector3(mousePosition.x, mousePosition.y);
        endPos = ((endPos - transform.position) * length) + transform.position;
        line.SetPosition(1,endPos);
    }
    
    void Update()
    {
        x += Time.deltaTime;
        if (x > existTime)
        {
            Destroy(gameObject);
        }
        else
        {
            line.SetWidth(1f - x / existTime, 1f - x / existTime);
            transform.localScale = new Vector2(1f-x/existTime,1);
        }
    }
}
