using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    //Odniesienie do gracza
    [SerializeField] private GameObject player;
    //odleg³oœc zbierania kryszta³u przez gracza
    //oraz wszystkie parametry potrzebne do okreœlenia
    //czy gracz wszed³ w zasiêg kryszta³u
    public float colectebleRadius = 4f;
    private float distance;
    private bool playerCollected = false;
    private float speed = 10f;
    //odniesienia do componentów 
    private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
   
    //przypisanie rb
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    //funkcja Update sprawdza czy gracz jest blisko kryszta³u oraz czy kryszta³ ju¿ jest zebrany
    //jeœli jest to kryszta³ zaczyna pod¹¿aæ w strone gracza
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
    // przypisuje pozycje gracza i przypisuje do dystansu odleg³oœæ gracza od kryszta³u jeœli
    //dystans jest mniejszy od pola zebrania  to w tedy w³acza sie trial renderer oraz zwraca wartoœæ true
    private bool IsPlayerNear()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance < colectebleRadius)
        {
            tr.emitting = true;
            rb.isKinematic = false;
            return true;
        }
        return false;
    }

   
}
