using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    //Odniesienie do gracza
    [SerializeField] private Player player;
    //Odniesienie do pozycji FiringPoint
    [SerializeField] private Transform firingPoint;
    //lista obiektów pociwków w magazynku oraz wszystkie parametry potrzebne
    //do stworzenia wystra³u pocisku opóŸnionego po ka¿dym wystrzale oraz do prze³adowywania
    public GameObject[] magazine;
    [SerializeField] private float fireRate = 0.5f;
    public int curMagazinSize = 0;
    public int maxMagazinSize = 6;
    public float reloadTime = 2f;
    private bool canReload = true;
    public bool isReloading = false;
    private float fireTimer;
    public float currentDelay;
    //odniesienie do componentu RigidBody 2D
    private Rigidbody2D gunRBody;
    //Funkcja daj¹ca sygna³ do wizualnego przedstawienia prze³adowania
    public UnityEvent ReloadVisExecute;

    //przypisanie wartoœci do gunRBody
    void Awake()
    {
        gunRBody = GetComponent<Rigidbody2D>();
    }
    //funkcja Update sprawdzaj¹ca czy gracz wcisno³ przycisk prze³adowania i czy wszystkie warunki s¹ spe³nione by pistolet móg³ prze³adowaæ
    //sprawdza czy przycisk wystrza³u zosta³ wciœniêty oraz czy wszystkie warunki s¹ spe³nione by pistolet móg³ wystrzeliæ kolejny pocisk w kolejnoœci
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
    //ustawia pozycje pistoletu na pozycje gracza by pitolet pod¹¿a³ za graczem
    //oraz obraca go w kierunki myszki oraz odwraca Sprite pistoletu by przy odwracaniu go w kierunku myszki nigdy nie by³ do góry nogami
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
    // tworzy obiekt pocisku z listy w pozycji i kierunku firingPoint oraz zmienia na zmienn¹ indexu dla kolejnego pocisku
    private void Shoot(int whichBullet)
    {
        Instantiate(magazine[whichBullet], firingPoint.position, firingPoint.rotation);
        curMagazinSize++;
    }
    //funkcja prze³adowania czeka przez czas prze³adowania a nastêpnie
    //zmienia currentDelay na 0 oraz index pocisku w magazynku by
    //po prze³adowaniu znowu móg³ wystrzeliæ pierwszy pocisk
    private IEnumerator Reload()
    {
        Debug.Log("Reloading");
        
        isReloading = true;
        canReload = false;
        yield return new WaitForSeconds(reloadTime);
        currentDelay = 0;
        curMagazinSize = 0;
        canReload = true;
        isReloading = false;
    }
    

}
