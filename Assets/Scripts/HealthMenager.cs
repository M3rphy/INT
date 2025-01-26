using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthMenager : MonoBehaviour
{
    [Header("Health Menager")]
    //Odniesienie do wizualnego paska ¿ycia
    private Image healthBar;
    //Maxymalne ¿ycie i aktualne
    public float currentHealth = 100f;
    public float MaxHealth = 100f;

    //prze³¹czenie na scene z napisem You Died
    private void Death()
    {
        SceneManager.LoadScene(1);
    }
    //Updatuje wizualn¹ czêœæ paska ¿ycia w oparciu o aktualne ¿ycie/maksymalne ¿ycie przypisane do healthBar.fillAmount
    private void UpdateHealthBar()
    {
        healthBar = GameObject.Find("Canvas (1)").transform.GetChild(1).gameObject.GetComponent<Image>();
        Debug.Log(currentHealth+" max: "+MaxHealth);
        healthBar.fillAmount = currentHealth / MaxHealth;
    }

    //Funkcja odejmuj¹ca ¿ycie gdy ¿ycie jest poni¿ej zera nastêpuje funkcja œmierci
    public void TakeDemage()
    {
       currentHealth -= 2;
        if(currentHealth <= 0)
        {
            Death();
        }
        UpdateHealthBar(); 
    }
    //funkcja która po wyborze HpUpa zwiêksza maksymalne ¿ycie gracza
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
