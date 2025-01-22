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
    private GameObject gun;
    private GameObject[] magazine;

    
   
    public void DisplayNextBullet()
    {
        int x = GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x;
    
        if (x == 1)
        {
            nextBullet.GetComponent<Image>().color = Color.red;
        }
        else if(x == 0 )
        {
            nextBullet.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            nextBullet.GetComponent<Image>().color = Color.white;
        }
        Instantiate(nextBullet, GameObject.Find("Magazine(Clone)").transform);
    }
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            VBullets[i].GetComponent<Image>().color = aaa(i);
            Instantiate(VBullets[i], this.transform);
        }
    }
    private Color aaa(int i)
    {
        if (GameObject.Find("Gun").GetComponent<Gun>().magazine[i].name == "TripleBullet")
        {
            return Color.yellow;
        }
        if (GameObject.Find("Gun").GetComponent<Gun>().magazine[i].name == "Laser")
        {
            return Color.red;
        }
        else if (GameObject.Find("Gun").GetComponent<Gun>().magazine[i].name == "Bullet")
        {
            return Color.white;
        }
        return Color.white;
    }
}
