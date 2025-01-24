using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class OptionsDisplay : MonoBehaviour
{
    private Image background;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private int buttonsNum;
    [SerializeField] private GameObject magazine;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject quitButton;
    private int temp;
    private int temp2;
    private int temp3;
    public UnityEvent displayNextBullet;
    public int x;
    private bool isPauzed = false;
    [SerializeField] private Transform panel;

    private void Start()
    {
        background = this.transform.GetChild(5).gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPauzed)
            {
                Instantiate(startButton, GameObject.Find("Canvas (1)").transform);
                Instantiate(quitButton, GameObject.Find("Canvas (1)").transform);
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
    public void DestroyPauza()
    {
        Destroy(GameObject.Find("Magazine(Clone)"));
        Destroy(GameObject.Find("StartButton(Clone)"));
        Destroy(GameObject.Find("QuitButton(Clone)"));
        HideBackground();
        GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().isPauzed = false;
    }
    private void DisplayPauza()
    {
        background.enabled = true;
        Instantiate(magazine, GameObject.Find("Canvas (1)").transform);
    }
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
        temp3 = a;
        
        Instantiate(buttons[a], panel);
      
        Time.timeScale = 0;
        Debug.Log("Time stop");
    }
    public void DestroyOptions()
    {
        Debug.Log("Destroy options");
       
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("Upgrades"))
        {
            Destroy(x);
        }
    }
    public void HideBackground()
    {
        Debug.Log("Time starts");
        Time.timeScale = 1;
        GameObject.Find("Canvas (1)").transform.GetChild(5).gameObject.GetComponent<Image>().enabled = false;
    }
    public void DisplayMagazine(int selectedUpgrade)
    {
        GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x = selectedUpgrade;
        Instantiate(magazine, GameObject.Find("Canvas (1)").transform);
        displayNextBullet.Invoke();
   
    }
    public void DestroyMagazine()
    {
        Destroy(GameObject.Find("Magazine(Clone)"));
    }
}
