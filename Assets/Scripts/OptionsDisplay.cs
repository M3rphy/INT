using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class OptionsDisplay : MonoBehaviour
{
    //odniesienie do t�a kt�re sie wy�wietla po wbiciu nowego poziomu
    private Image background;
    //lista mo�liwych upgraid�w
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private int buttonsNum;
    //odniesienie do magazynka gracza oraz do prefab�w przycisk�w start i quit
    [SerializeField] private GameObject magazine;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject quitButton;
    //tymczasowe zmienne przechowuj�ce warto�ci index�w buttons[] tak by nie pojawi�y sie te same upgrade
    private int temp;
    private int temp2;
    //funkcja wywo�ywana po wyborze nowego pocisku
    public UnityEvent displayNextBullet;
    public int x;
    //zmienna odpowiadaj�ca czy wy�wietlona jest pauza
    private bool isPauzed = false;
    //miejsce wy�wietlania upgrad�w
    [SerializeField] private Transform panel;

    //przypisanie background
    private void Start()
    {
        background = this.transform.GetChild(5).gameObject.GetComponent<Image>();
    }
    //sprawdza czy gracz wcisno� przycisk escape by wy�wietli� b�d� zniszczy� scene pauzy
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPauzed)
            {
                Time.timeScale = 0;
                DisplayPauza();
                
                isPauzed = true;
            }
            else
            {
                DestroyPauza();
            }
        }
    }
    //funkcja kt�ra ukrywa lub niszczy wszystkie elementy sk�adaj�ce sie na ekran pauzy
    public void DestroyPauza()
    {
        Destroy(GameObject.Find("Magazine(Clone)"));
        Destroy(GameObject.Find("StartButton(Clone)"));
        Destroy(GameObject.Find("QuitButton(Clone)"));
        HideBackground();
        GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().isPauzed = false;
    }
    //tworzenie wszystkich obiekt�w sk�adaj�cych sie na ekran pauzy
    private void DisplayPauza()
    {
        background.enabled = true;
        Instantiate(startButton, GameObject.Find("Canvas (1)").transform);
        Instantiate(quitButton, GameObject.Find("Canvas (1)").transform);
        Instantiate(magazine, GameObject.Find("Canvas (1)").transform);
    }

    //funkcja kt�ra ma za zadanie wy�wietli� 3 losowe przyciski upgrad�w oraz zatrzymuje czas w grze
    public void DisplayOptions()
    {
        background.enabled = true;
        //1 button
        int a = Random.Range(0, buttonsNum);
        temp = a;
        Instantiate(buttons[a], panel);
    
        //2 button
        while (temp == a)
        {
            a = Random.Range(0, buttonsNum);
        }
        temp2 = a;
        Instantiate(buttons[a], panel);

        //3button
        while (temp2 == a || temp == a)
        {
            a = Random.Range(0, buttonsNum);
        }
        Instantiate(buttons[a], panel);
        Time.timeScale = 0;
        Debug.Log("Time stop");
    }
    //funkcja niszcz�ca wszystkie wy�wietlone Upgrady
    public void DestroyOptions()
    {
        Debug.Log("Destroy options");
       
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("Upgrades"))
        {
            Destroy(x);
        }
    }
    //funkcja ukrywaj�ca t�o
    public void HideBackground()
    {
        Debug.Log("Time starts");
        Time.timeScale = 1;
        GameObject.Find("Canvas (1)").transform.GetChild(5).gameObject.GetComponent<Image>().enabled = false;
    }
    //funkcja kt�ra po wybraniu pocisku wy�wietla Magazynek pistoletu
    public void DisplayMagazine(int selectedUpgrade)
    {
        GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x = selectedUpgrade;
        Instantiate(magazine, GameObject.Find("Canvas (1)").transform);
        displayNextBullet.Invoke();
   
    }
    //funkcja kt�ra niszczy magazynek
    public void DestroyMagazine()
    {
        Destroy(GameObject.Find("Magazine(Clone)"));
    }
}
