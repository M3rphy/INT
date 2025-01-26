using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class XpMenager : MonoBehaviour
{
    [Header("XP Menager")]
    //Odniesienie do wizualnego paska doœwiadczenia
    private Image xpBar;
    //aktualne doœwiadczenie oraz lista punktów doœwiadczenia potrzebnych do zdobycia nowego poziomu
    [SerializeField] private float curXp;
    private float[] maxXp = {10,15,20,25,30,35,40,45,50,55,60,65,70,75,80,85,90,100,120,125};
    // aktualny poziom oraz index dla maxXp[]
    public int level = 0;
    //Wywo³anie funkcji gdy dochodzi do zdobycia nowego poziomu
    public UnityEvent levelUp;
    
    // przypisanie xpBar oraz ustawienie jego fillAmount na 0
    private void Start()
    {
        xpBar = GameObject.Find("Canvas (1)").transform.GetChild(4).gameObject.GetComponent<Image>();
        xpBar.fillAmount = 0;
    }

    //zwiêkszenie aktualnego doœwiadczenia oraz sprawdzenie czy aktualne doœwiadczenie jest wystarczaj¹ceby zdobyæ nastêpny poziom
    //gdy zdobêdzie sie nowy poziom to invokuje sie funkja levelUp a gdy poziomów jest ju¿ 19 to przechodzi do sceny z gratulacjami za przejœcie gry
    //oraz na koñcu aktualizuje wizualn¹ czêœæ paska doœwiadczenia
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
