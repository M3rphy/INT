using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Image reloadImage;
    public float x ;
    public bool y = false;
   
    void Update()
    {
        if (y) { x = 0.5f; }
      
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 pos = new Vector2(player.transform.position.x, player.transform.position.y+2.5f);
        reloadImage.transform.position = pos;
        reloadImage.fillAmount = x;
         Debug.Log(x);
    }
    
    public void startVisualReload()
    {
        y = true;
    }
     private float VisualUpdate(float x)
    {   
        Debug.Log(x);
        return x;
    }
  
}
