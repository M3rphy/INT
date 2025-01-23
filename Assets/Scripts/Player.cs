using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rBody;
    public float speed;
    private Vector2 moveInput;

    [SerializeField] private GameObject[] upgradesBulletsList;


    public UnityEvent takeDamge;
    public UnityEvent increaseXp;
     

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 1f; 
    [SerializeField] private float dashCooldown = 1f;
    public bool isDashing;
    private bool canDash = true;
    
    void Start()
    {
        //MaxHealth = 100;
    }
    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        

        rBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
         if (!(transform.position.x + moveInput.x < 17.781f - 0.5f)|| !(transform.position.x + moveInput.x > -17.781f + 0.5))
        {
            moveInput.x = 0 ;
        }
        if(!(transform.position.y + moveInput.y < 10 - 0.5f) || !(transform.position.y + moveInput.y > -10 + 0.5f))
        {
            moveInput.y = 0 ;
        }
        if (isDashing) { return; }
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            
            StartCoroutine(Dash());
        }
    }
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
    public void IncreaseSpeed()
    {
        GameObject.Find("Player").GetComponent<Player>().speed += 1; 
    }
    public void IncreaseReloadingSpeed()
    {
        if(GameObject.Find("Gun").GetComponent<Gun>().reloadTime - .5f > 0)
        {
            GameObject.Find("Gun").GetComponent<Gun>().reloadTime -= .5f;
        }
    }
    public void changeBullet(int magazinSlot)
    {
        int x = GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x;
        Debug.Log(magazinSlot + " " + x);
        GameObject.Find("Player").transform.GetChild(1).gameObject.GetComponent<Gun>().magazine[magazinSlot] = upgradesBulletsList[x];
        Time.timeScale = 1;
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

}
