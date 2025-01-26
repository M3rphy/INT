using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class MagazineDisplay : MonoBehaviour
{
    //lista wizualnych pocisk�w w benbenku
    [SerializeField] private GameObject[] VBullets;
    //obiekt nast�pnego pocisku wk�adanego do b�nbenka
    [SerializeField] private GameObject nextBullet;
    //odniesienie do grafik pocisk�w w b�benku
    [SerializeField] private Sprite[] images;
    //odniesienie do lokalizacji gdzie ma pojawia� sie kolejny pocisk
    [SerializeField] private Transform panel;
    static public Transform panelStatic;
   

    
   //Sprawdzenie w li�cie kt�ry pocisk zosta� wybrany przypisanie do niego odpowiednia grafiki oraz stworzenie jego prefaba w odpowiednim miejscu
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
    
    // przypisanie panelowi static warto�ci z panela
    //oraz pojawienie wszystkich sze�ciu komur bembna
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
    //funkcja ustawiaj�ca zdj�cie do odpowiednich pocisk�w
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
