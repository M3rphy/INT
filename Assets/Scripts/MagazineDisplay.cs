using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class MagazineDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] VBullets;
    [SerializeField] private GameObject nextBullet;
    [SerializeField] private Sprite[] images;
    [SerializeField] private Transform panel;
    static public Transform panelStatic;
   

    
   
    public void DisplayNextBullet()
    {
        int x = GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x;
    
        if (x == 1)
        {
            nextBullet.GetComponent<Image>().sprite = images[2];
        }
        else if(x == 0 )
        {
            nextBullet.GetComponent<Image>().sprite = images[1];
        }
        else if(x == 2)
        {
            nextBullet.GetComponent<Image>().sprite = images[3];
        }
        else
        {
            nextBullet.GetComponent<Image>().sprite = images[0];
        }
        GameObject bullet = Instantiate(nextBullet, GameObject.Find("Magazine(Clone)").transform);
        
      
    }
    private void Start()
    {
        panelStatic = panel;
        for (int i = 0; i < 6; i++)
        {
            VBullets[i].GetComponent<Image>().sprite = GetBulletImage(i);
            GameObject bulletSlot = Instantiate(VBullets[i], this.transform);
            bulletSlot.transform.SetAsFirstSibling();
        }
    }
    private Sprite GetBulletImage(int i)
    {
        if (GameObject.Find("Gun").GetComponent<Gun>().magazine[i].name == "TripleBullet")
        {
            return images[1];
        }
        else if (GameObject.Find("Gun").GetComponent<Gun>().magazine[i].name == "Laser")
        {
            return images[2];
        }
        else if (GameObject.Find("Gun").GetComponent<Gun>().magazine[i].name == "BombBullet")
        {
            return images[3];
        }
        else if (GameObject.Find("Gun").GetComponent<Gun>().magazine[i].name == "Bullet")
        {
            return images[0];
        }
        return images[0];
    }
}
