using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class XpMenager : MonoBehaviour
{
    [Header("XP Menager")]
    [SerializeField] private Image xpBar;
    [SerializeField] private float curXp;
    [SerializeField] private float maxXp;
    public int level = 1;
    public UnityEvent levelUp;
    
    private void Start()
    {
        xpBar.fillAmount = 0;
    }
    public void GainXp()
    {
        curXp += 2;
        
        if(curXp >= maxXp)
        {
            level++;
            curXp = 0;
            levelUp.Invoke();
        }
        xpBar.fillAmount = curXp / maxXp;
    }
   
}