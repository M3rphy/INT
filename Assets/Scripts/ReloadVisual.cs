using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ReloadVisual : MonoBehaviour
{
    [SerializeField] private GameObject player;
     private GameObject gun;
    private Image reloadImage;
    public float x ;


    private void Start()
    {
        reloadImage = this.transform.GetChild(6).gameObject.GetComponent<Image>();
        gun = GameObject.Find("Gun");
    }
    void Update()
    {
        if (gun.GetComponent<Gun>().isReloading) 
        { 
            gun.GetComponent<Gun>().currentDelay+= Time.deltaTime;
            startVisualReload(); 
            if(gun.GetComponent<Gun>().currentDelay>2f)
            {
                x = 0;
                gun.GetComponent<Gun>().currentDelay = 0;
                return;
            }
        }
        else
        {
            x = 0;
        }
      
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 pos = new Vector2(player.transform.position.x, player.transform.position.y+2.5f);
        reloadImage.transform.position = pos;
        reloadImage.fillAmount = x;
         //Debug.Log(x);
    }
    
    public void startVisualReload()
    {
        
        x = gun.GetComponent<Gun>().currentDelay/ gun.GetComponent<Gun>().reloadTime;
        
     
    }
     private float VisualUpdate(float x)
    {   
        Debug.Log(x);
        return x;
    }
  
}
