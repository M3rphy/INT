using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class OptionsDisplay : MonoBehaviour
{
    //odniesienie do t³a które sie wyœwietla po wbiciu nowego poziomu
    private Image background;
    //lista mo¿liwych upgraidów
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private int buttonsNum;
    //odniesienie do magazynka gracza oraz do prefabów przycisków start i quit
    [SerializeField] private GameObject magazine;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject quitButton;
    //tymczasowe zmienne przechowuj¹ce wartoœci indexów buttons[] tak by nie pojawi³y sie te same upgrade
    private int temp;
    private int temp2;
    //funkcja wywo³ywana po wyborze nowego pocisku
    public UnityEvent displayNextBullet;
    public int x;
    //zmienna odpowiadaj¹ca czy wyœwietlona jest pauza
    private bool isPauzed = false;
    //miejsce wyœwietlania upgradów
    [SerializeField] private Transform panel;

    //przypisanie background
    private void Start()
    {
        background = this.transform.GetChild(5).gameObject.GetComponent<Image>();
    }
    //sprawdza czy gracz wcisno³ przycisk escape by wyœwietliæ b¹dŸ zniszczyæ scene pauzy
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
    //funkcja która ukrywa lub niszczy wszystkie elementy sk³adaj¹ce sie na ekran pauzy
    public void DestroyPauza()
    {
        Destroy(GameObject.Find("Magazine(Clone)"));
        Destroy(GameObject.Find("StartButton(Clone)"));
        Destroy(GameObject.Find("QuitButton(Clone)"));
        HideBackground();
        GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().isPauzed = false;
    }
    //tworzenie wszystkich obiektów sk³adaj¹cych sie na ekran pauzy
    private void DisplayPauza()
    {
        background.enabled = true;
        Instantiate(startButton, GameObject.Find("Canvas (1)").transform);
        Instantiate(quitButton, GameObject.Find("Canvas (1)").transform);
        Instantiate(magazine, GameObject.Find("Canvas (1)").transform);
    }

    //funkcja która ma za zadanie wyœwietliæ 3 losowe przyciski upgradów oraz zatrzymuje czas w grze
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
    //funkcja niszcz¹ca wszystkie wyœwietlone Upgrady
    public void DestroyOptions()
    {
        Debug.Log("Destroy options");
       
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("Upgrades"))
        {
            Destroy(x);
        }
    }
    //funkcja ukrywaj¹ca t³o
    public void HideBackground()
    {
        Debug.Log("Time starts");
        Time.timeScale = 1;
        GameObject.Find("Canvas (1)").transform.GetChild(5).gameObject.GetComponent<Image>().enabled = false;
    }
    //funkcja która po wybraniu pocisku wyœwietla Magazynek pistoletu
    public void DisplayMagazine(int selectedUpgrade)
    {
        GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x = selectedUpgrade;
        Instantiate(magazine, GameObject.Find("Canvas (1)").transform);
        displayNextBullet.Invoke();
   
    }
    //funkcja która niszczy magazynek
    public void DestroyMagazine()
    {
        Destroy(GameObject.Find("Magazine(Clone)"));
    }
}
