using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class XpMenager : MonoBehaviour
{
    [Header("XP Menager")]
    private Image xpBar;
    [SerializeField] private float curXp;
    private float[] maxXp = {10,15,20,25,30,35,40,45,50,55,60,65,70,75,80,85,90,100,120,125};
    public int level = 0;
    public UnityEvent levelUp;
    
    private void Start()
    {
        xpBar = GameObject.Find("Canvas (1)").transform.GetChild(4).gameObject.GetComponent<Image>();
        xpBar.fillAmount = 0;
    }
    public void GainXp()
    {
        curXp += 2;
        Debug.Log(GameObject.Find("XpMenager").GetComponent<XpMenager>().level);
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
