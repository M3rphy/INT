using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBullet : MonoBehaviour
{
    //odwo�anie Do prefaba bullet
    [SerializeField] private GameObject bullet;
   
    //Stwarza 3 obiekty pocisk�w kt�re s� odwr�cone od siebie r�nic� 20 stopni od poprzedniego po czym obiekt przestaje istnie�
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 20);
        Instantiate(bullet, transform.position, transform.rotation);

        transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z - 20);
        Instantiate(bullet, transform.position, transform.rotation);
       
        transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z - 20);
        Instantiate(bullet, transform.position, transform.rotation);

        Destroy(gameObject);
    }
    
    
}
