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
    //lista obiekt�w pociwk�w w magazynku oraz wszystkie parametry potrzebne
    //do stworzenia wystra�u pocisku op�nionego po ka�dym wystrzale oraz do prze�adowywania
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
    //Funkcja daj�ca sygna� do wizualnego przedstawienia prze�adowania
    public UnityEvent ReloadVisExecute;

    //przypisanie warto�ci do gunRBody
    void Awake()
    {
        gunRBody = GetComponent<Rigidbody2D>();
    }
    //funkcja Update sprawdzaj�ca czy gracz wcisno� przycisk prze�adowania i czy wszystkie warunki s� spe�nione by pistolet m�g� prze�adowa�
    //sprawdza czy przycisk wystrza�u zosta� wci�ni�ty oraz czy wszystkie warunki s� spe�nione by pistolet m�g� wystrzeli� kolejny pocisk w kolejno�ci
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
    //ustawia pozycje pistoletu na pozycje gracza by pitolet pod��a� za graczem
    //oraz obraca go w kierunki myszki oraz odwraca Sprite pistoletu by przy odwracaniu go w kierunku myszki nigdy nie by� do g�ry nogami
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
    // tworzy obiekt pocisku z listy w pozycji i kierunku firingPoint oraz zmienia na zmienn� indexu dla kolejnego pocisku
    private void Shoot(int whichBullet)
    {
        Instantiate(magazine[whichBullet], firingPoint.position, firingPoint.rotation);
        curMagazinSize++;
    }
    //funkcja prze�adowania czeka przez czas prze�adowania a nast�pnie
    //zmienia currentDelay na 0 oraz index pocisku w magazynku by
    //po prze�adowaniu znowu m�g� wystrzeli� pierwszy pocisk
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
