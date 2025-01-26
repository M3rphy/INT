using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Odniesienie do Prefaba kryszta�u
    [SerializeField] private GameObject crystalPrefab;
    //ilo�� �ycia
    public float hp = 2;
    //Pozycja gracza
    public Transform target;
    //pr�dko��
    public float speed = 3f;

    //Funkcja Update sprawdza czy �ycie przeciwnika jest mniejsze lub r�wne zero je�li tak to tworzy krysta� i znika
    //je�li nie ma pozycji graca to wywo�uje funkcje GetTarget
    //kieruje przeciwnika w strone gracza 
    //i obraca sprita w zale�no�ci czy gracz jest po jego lewej b�d� prawej stronie
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
    // przypisuje pozycje gracza je�li gracz istnieje
    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    //Collizje przeciwnika z pociskami zwyk�ym odejmuje mu 1 �ycie, laser ustwia jego �ycie na 0,
    //bomba to odejmuje od �ycia 2/dystans wybuchu od gracza+1,5;
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
