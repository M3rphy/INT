using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class XpMenager : MonoBehaviour
{
    [Header("XP Menager")]
    //Odniesienie do wizualnego paska doświadczenia
    private Image xpBar;
    //aktualne doświadczenie oraz lista punktów doświadczenia potrzebnych do zdobycia nowego poziomu
    [SerializeField] private float curXp;
    private float[] maxXp = {10,15,20,25,30,35,40,45,50,55,60,65,70,75,80,85,90,100,120,125};
    // aktualny poziom oraz index dla maxXp[]
    public int level = 0;
    //Wywołanie funkcji gdy dochodzi do zdobycia nowego poziomu
    public UnityEvent levelUp;
    
    // przypisanie xpBar oraz ustawienie jego fillAmount na 0
    private void Start()
    {
        xpBar = GameObject.Find("Canvas (1)").transform.GetChild(4).gameObject.GetComponent<Image>();
        xpBar.fillAmount = 0;
    }

    //zwiększenie aktualnego doświadczenia oraz sprawdzenie czy aktualne doświadczenie jest wystarczająceby zdobyć następny poziom
    //gdy zdobędzie sie nowy poziom to invokuje sie funkja levelUp a gdy poziomów jest już 19 to przechodzi do sceny z gratulacjami za przejście gry
    //oraz na końcu aktualizuje wizualną część paska doświadczenia
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
