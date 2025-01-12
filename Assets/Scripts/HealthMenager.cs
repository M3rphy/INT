using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMenager : MonoBehaviour
{
    [Header("Health Menager")]
    [SerializeField] private GameObject levelsMenager;
    [SerializeField] private Image healthBar;
    [SerializeField] private float currentHealth = 100f;
    [SerializeField] private float MaxHealth = 100f;
   
 
    private void Update()
    {
        if(levelsMenager.GetComponent<LevelUpScreen>().HpUpEvent)
        {
            IncreaseHp();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / MaxHealth;
    }

    public void TakeDemage()
    {
        currentHealth -= 2;
        Debug.Log(currentHealth);
        UpdateHealthBar(); 
    }
    public void IncreaseHp()
    {
        
        MaxHealth += 20;
        currentHealth = currentHealth * (MaxHealth / 100);
        if(currentHealth > MaxHealth )
        {
            currentHealth = MaxHealth;
        }
        Debug.Log(MaxHealth);
        UpdateHealthBar();
        levelsMenager.GetComponent<LevelUpScreen>().HpUpEvent = false;
    }
}
