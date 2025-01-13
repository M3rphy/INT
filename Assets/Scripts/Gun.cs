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
    [SerializeField] private GameObject[] magazin;
    public int curMagazinSize = 6;
    [SerializeField] private float reloadTime = 2f;
    private bool canReload = true;
    private bool isReloading = false;
    private float fireTimer;
    private float currentDelay;
    private Rigidbody2D gunRBody;

    public UnityEvent ReloadVisExecute;

    void Awake()
    {
        gunRBody = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.R) || !(curMagazinSize > 0) && canReload )
        {
            StartCoroutine(Reload());
        }
        if (Input.GetMouseButton(0) && fireTimer <= 0f && !isReloading && curMagazinSize > 0)
        {
            Shoot(curMagazinSize - 1);
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
        
    }
    private void Shoot(int whichBullet)
    {
        curMagazinSize--;
        Instantiate(magazin[whichBullet], firingPoint.position, firingPoint.rotation);
    }
    private IEnumerator Reload()
    {
        Debug.Log("Reloading");
        ReloadVisExecute.Invoke();
        isReloading = true;
        canReload = false;
        yield return new WaitForSeconds(reloadTime);
        curMagazinSize = 6;
        canReload = true;
        isReloading = false;
    }

}
