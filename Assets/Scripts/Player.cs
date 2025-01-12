using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    public Rigidbody2D rBody;
    [SerializeField] private float speed;
    private Vector2 moveInput;
    [SerializeField] private GameObject levelsMenager;



    public UnityEvent takeDamge;
    public UnityEvent increaseXp;
     




    //[Header("Health Menager")]
    //[SerializeField] private Image healthBar;
    //[SerializeField] private float currentHealth = 100f;
    //[SerializeField] private float MaxHealth = 100f;



    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 1f; 
    [SerializeField] private float dashCooldown = 1f;
    private bool isDashing;
    private bool canDash = true;
    
    void Start()
    {
        //MaxHealth = 100;
    }
    void Awake()
    {
        

        rBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (levelsMenager.GetComponent<LevelUpScreen>().SpeedUpEvent) 
        { IncreaseSpeed(); };
        if (isDashing) { return; }
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    void FixedUpdate()
    {
        if (isDashing) { return; }
        rBody.velocity = moveInput * speed;
    }
    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }
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
    private void IncreaseSpeed()
    {
        speed += 1;
        levelsMenager.GetComponent<LevelUpScreen>().SpeedUpEvent = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {

            increaseXp.Invoke();
            Destroy(other.gameObject);
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
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
            
            
    //    }
    //}
    
    //private void UpdateHealthBar()
    //{
    //    healthBar.fillAmount = currentHealth / MaxHealth;
    //}
    //public void IncreaseHp()
    //{
    //    MaxHealth = MaxHealth + 20;
    //    Debug.Log(MaxHealth);
    //    UpdateHealthBar();
    //}
}
