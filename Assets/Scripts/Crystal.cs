using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    //Odniesienie do gracza
    [SerializeField] private GameObject player;
    //odleg�o�c zbierania kryszta�u przez gracza
    //oraz wszystkie parametry potrzebne do okre�lenia
    //czy gracz wszed� w zasi�g kryszta�u
    public float colectebleRadius = 4f;
    private float distance;
    private bool playerCollected = false;
    private float speed = 10f;
    //odniesienia do component�w 
    private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
   
    //przypisanie rb
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    //funkcja Update sprawdza czy gracz jest blisko kryszta�u oraz czy kryszta� ju� jest zebrany
    //je�li jest to kryszta� zaczyna pod��a� w strone gracza
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
    // przypisuje pozycje gracza i przypisuje do dystansu odleg�o�� gracza od kryszta�u je�li
    //dystans jest mniejszy od pola zebrania  to w tedy w�acza sie trial renderer oraz zwraca warto�� true
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
