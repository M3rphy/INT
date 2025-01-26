using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBullet : MonoBehaviour
{
    //odwo³anie Do prefaba bullet
    [SerializeField] private GameObject bullet;
   
    //Stwarza 3 obiekty pocisków które s¹ odwrócone od siebie ró¿nic¹ 20 stopni od poprzedniego po czym obiekt przestaje istnieæ
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
