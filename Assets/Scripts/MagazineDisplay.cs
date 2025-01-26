using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class MagazineDisplay : MonoBehaviour
{
    //lista wizualnych pocisków w benbenku
    [SerializeField] private GameObject[] VBullets;
    //obiekt nastêpnego pocisku wk³adanego do bênbenka
    [SerializeField] private GameObject nextBullet;
    //odniesienie do grafik pocisków w bêbenku
    [SerializeField] private Sprite[] images;
    //odniesienie do lokalizacji gdzie ma pojawiaæ sie kolejny pocisk
    [SerializeField] private Transform panel;
    static public Transform panelStatic;
   

    
   //Sprawdzenie w liœcie który pocisk zosta³ wybrany przypisanie do niego odpowiednia grafiki oraz stworzenie jego prefaba w odpowiednim miejscu
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
    
    // przypisanie panelowi static wartoœci z panela
    //oraz pojawienie wszystkich szeœciu komur bembna
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
    //funkcja ustawiaj¹ca zdjêcie do odpowiednich pocisków
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
