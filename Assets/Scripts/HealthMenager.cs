using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthMenager : MonoBehaviour
{
    [Header("Health Menager")]
    [SerializeField] private GameObject levelsMenager;
     private Image healthBar;
    public float currentHealth = 100f;
    public float MaxHealth = 100f;

    private void Death()
    {
        SceneManager.LoadScene(1);
    }
    private void UpdateHealthBar()
    {
        healthBar = GameObject.Find("Canvas (1)").transform.GetChild(1).gameObject.GetComponent<Image>();
        Debug.Log(currentHealth+" max: "+MaxHealth);
        healthBar.fillAmount = currentHealth / MaxHealth;
    }

    public void TakeDemage()
    {
       currentHealth -= 2;
        if(currentHealth <= 0)
        {
            Death();
        }
        UpdateHealthBar(); 
    }
    public void IncreaseHp()
    {
        MaxHealth = GameObject.Find("HealthMenager").GetComponent<HealthMenager>().MaxHealth += 20;
        
        GameObject.Find("HealthMenager").GetComponent<HealthMenager>().currentHealth = GameObject.Find("HealthMenager").GetComponent<HealthMenager>().currentHealth * (MaxHealth / 100);
        if (GameObject.Find("HealthMenager").GetComponent<HealthMenager>().currentHealth > MaxHealth)
        {
            GameObject.Find("HealthMenager").GetComponent<HealthMenager>().currentHealth = MaxHealth;
        }
        currentHealth = GameObject.Find("HealthMenager").GetComponent<HealthMenager>().currentHealth;
        UpdateHealthBar();
     
    }
}
