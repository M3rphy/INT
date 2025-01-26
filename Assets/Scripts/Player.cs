using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.VisualScripting;


public class Player : MonoBehaviour
{
    //Odniesie go componentów potrzebnych do poruszania siê oraz do animatora PlayerSprite
    private Animator animator;
    private Vector2 moveInput;
    public Rigidbody2D rBody;
    //prêdkoœ gracza
    public float speed;
    //lista ulepszonych pocisków
    [SerializeField] private GameObject[] upgradesBulletsList;
    //Wyo³ywane funkcje
    public UnityEvent takeDamge;
    public UnityEvent increaseXp;
    //Parametry potrzebne do stworzenia dasha
    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 1f; 
    [SerializeField] private float dashCooldown = 1f;
    public bool isDashing;
    private bool canDash = true;
    
    //Przypisanie wartoœci animator oraz rBody
    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    //W Update sprawdzam za pomoc¹ funkcji Mathf.Clamp ¿eby gracz nie wyszed³ po za opszar mapy
    //oraz po przez if sprawdzam czy gracz klikn¹ przycisk do dashowania i czy mo¿e w danym momencie dashowaæ
    void Update()
    {
        transform.position =new Vector2(Mathf.Clamp(transform.position.x, -17.281f, 17.281f), Mathf.Clamp(transform.position.y, -9.5f, 9.5f));
       
        if (isDashing) { return; }
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            
            StartCoroutine(Dash());
        }
    }
    //w FixedUpdate jeœli gracz jest w trakcie dasha to zwraca funkcje
    //sprawdza czy vector w którym sie porusza gracz jest zerem jeœli jest to zmienia wartoœæ IsMoving na false
    //a jeœli vector jest ró¿ny od 0 to zmienia na IsMoving na true
    //na koñcu ustawia rBody.velocity na kierunek poruszania gracza razy prêdkoœæ
    void FixedUpdate()
    {
        if (isDashing) { return; }
        if(moveInput == Vector2.zero)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
        rBody.velocity = moveInput * speed;
    }
    // za pomoc¹ nowego systemu input wpudowana funkcja pobiera kierunek za pomoc¹ wciœniêtych przycisków WSAD
    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }
    //Funkcja Dash wy³¹cza collider gracza 
    //potem w kierunku w którym sie porusza³ zmienia jego pozycje razy szybkoœæ dasha
    //czeka tyle ile wynosi czas trwania dasha i ustawia collider na true
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        GetComponent<Collider2D>().enabled = false;
        rBody.velocity = moveInput * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        GetComponent<Collider2D>().enabled = true;
        isDashing =false;
        yield return new WaitForSeconds(dashCooldown);
        canDash=true;
    }
    //Funkcja zwiêkszania prêdkoœci gracza wykorzystywana poprzez system Upgradów
    public void IncreaseSpeed()
    {
        GameObject.Find("Player").GetComponent<Player>().speed += 1; 
    }
    //Funkcja zwiêkszania prêdkoœci prze³adowania pistoletu wykorzystywana poprzez system Upgradów
    public void IncreaseReloadingSpeed()
    {
        if(GameObject.Find("Gun").GetComponent<Gun>().reloadTime - .5f > 0)
        {
            GameObject.Find("Gun").GetComponent<Gun>().reloadTime -= .5f;
        }
    }
    //Funkcja wymiany pocisku w magazynku wywo³ywana przez obiekt Magazine
    public void changeBullet(int magazinSlot)
    {
        int x = GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x;
        Debug.Log(magazinSlot + " " + x);
        GameObject.Find("Player").transform.GetChild(1).gameObject.GetComponent<Gun>().magazine[magazinSlot] = upgradesBulletsList[x];
        Time.timeScale = 1;
    }
    //Funkcje sprawdzaj¹ce czy gracz dotkno³ przeciwnika lub kryszta³u i wywo³uj¹ odpowiednie im funkcje 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        { 
            Destroy(other.gameObject);
            increaseXp.Invoke();
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Hit");
            takeDamge.Invoke();
        }
    }

}
