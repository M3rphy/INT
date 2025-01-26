using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class XpMenager : MonoBehaviour
{
    [Header("XP Menager")]
    //Odniesienie do wizualnego paska do�wiadczenia
    private Image xpBar;
    //aktualne do�wiadczenie oraz lista punkt�w do�wiadczenia potrzebnych do zdobycia nowego poziomu
    [SerializeField] private float curXp;
    private float[] maxXp = {10,15,20,25,30,35,40,45,50,55,60,65,70,75,80,85,90,100,120,125};
    // aktualny poziom oraz index dla maxXp[]
    public int level = 0;
    //Wywo�anie funkcji gdy dochodzi do zdobycia nowego poziomu
    public UnityEvent levelUp;
    
    // przypisanie xpBar oraz ustawienie jego fillAmount na 0
    private void Start()
    {
        xpBar = GameObject.Find("Canvas (1)").transform.GetChild(4).gameObject.GetComponent<Image>();
        xpBar.fillAmount = 0;
    }

    //zwi�kszenie aktualnego do�wiadczenia oraz sprawdzenie czy aktualne do�wiadczenie jest wystarczaj�ceby zdoby� nast�pny poziom
    //gdy zdob�dzie sie nowy poziom to invokuje sie funkja levelUp a gdy poziom�w jest ju� 19 to przechodzi do sceny z gratulacjami za przej�cie gry
    //oraz na ko�cu aktualizuje wizualn� cz�� paska do�wiadczenia
    public void GainXp()
    {
        curXp += 2;

        if(curXp >= maxXp[GameObject.Find("XpMenager").GetComponent<XpMenager>().level])
        {
            GameObject.Find("XpMenager").GetComponent<XpMenager>().level++;
            curXp = 0;
            if(GameObject.Find("XpMenager").GetComponent<XpMenager>().level == 19)
            {
                SceneManager.LoadScene(2);
                return;
            }
            levelUp.Invoke();
        }

        xpBar.fillAmount = curXp / maxXp[GameObject.Find("XpMenager").GetComponent<XpMenager>().level];
    }
   
}
