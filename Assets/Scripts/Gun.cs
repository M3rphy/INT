using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private Player player;

    //bullet
    
    [SerializeField] private Transform firingPoint;
    [SerializeField] private float fireRate = 0.5f;
    public GameObject[] magazine;
    public int curMagazinSize = 0;
    public int maxMagazinSize = 6;
    public float reloadTime = 2f;
    private bool canReload = true;
    public bool isReloading = false;
    private float fireTimer;
    public float currentDelay;
    private Rigidbody2D gunRBody;

    public UnityEvent ReloadVisExecute;

    void Awake()
    {
        gunRBody = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
     
        if ((Input.GetKeyDown(KeyCode.R) || !(curMagazinSize < 6)) && canReload && !isReloading && curMagazinSize != 0)
        {
            StartCoroutine(Reload());
        }
        if (Input.GetMouseButton(0) && fireTimer <= 0f && !isReloading && curMagazinSize <=5  && !player.isDashing && !(Time.timeScale == 0))
        {
            Shoot(curMagazinSize);
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        gunRBody.velocity = player.rBody.velocity;
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
  
        if (direction.x < 0) {
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = false;
        }
        
    }
    private void Shoot(int whichBullet)
    {
        Instantiate(magazine[whichBullet], firingPoint.position, firingPoint.rotation);
        curMagazinSize++;
    }
    private IEnumerator Reload()
    {
        Debug.Log("Reloading");
        
        isReloading = true;
        canReload = false;
        yield return new WaitForSeconds(reloadTime);
        curMagazinSize = 0;
        canReload = true;
        isReloading = false;
    }
    

}
