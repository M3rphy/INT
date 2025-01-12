using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
   

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 20);
        Instantiate(bullet, transform.position, transform.rotation);
        Debug.Log(transform.rotation.eulerAngles.z);
        transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z - 20);
        Instantiate(bullet, transform.position, transform.rotation);
        Debug.Log(transform.rotation.eulerAngles.z);
        transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z - 20);
        Instantiate(bullet, transform.position, transform.rotation);
        Debug.Log(transform.rotation.eulerAngles.z);

        Destroy(gameObject);
    }
    
    
}
