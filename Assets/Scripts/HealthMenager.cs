using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthMenager : MonoBehaviour
{
    [Header("Health Menager")]
    //Odniesienie do wizualnego paska �ycia
    private Image healthBar;
    //Maxymalne �ycie i aktualne
    public float currentHealth = 100f;
    public float MaxHealth = 100f;

    //prze��czenie na scene z napisem You Died
    private void Death()
    {
        SceneManager.LoadScene(1);
    }
    //Updatuje wizualn� cz�� paska �ycia w oparciu o aktualne �ycie/maksymalne �ycie przypisane do healthBar.fillAmount
    private void UpdateHealthBar()
    {
        healthBar = GameObject.Find("Canvas (1)").transform.GetChild(1).gameObject.GetComponent<Image>();
        Debug.Log(currentHealth+" max: "+MaxHealth);
        healthBar.fillAmount = currentHealth / MaxHealth;
    }

    //Funkcja odejmuj�ca �ycie gdy �ycie jest poni�ej zera nast�puje funkcja �mierci
    public void TakeDemage()
    {
       currentHealth -= 2;
        if(currentHealth <= 0)
        {
            Death();
        }
        UpdateHealthBar(); 
    }
    //funkcja kt�ra po wyborze HpUpa zwi�ksza maksymalne �ycie gracza
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
