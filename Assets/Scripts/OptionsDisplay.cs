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
    private int temp;
    private int temp2;
    private int temp3;
    public UnityEvent displayNextBullet;
    public int x;

    private void Start()
    {
        background = this.transform.GetChild(5).gameObject.GetComponent<Image>();
    }

    private void Update()
    {
            
           
        //if (levelsMenager.GetComponent<LevelUpScreen>().HideBackground)
        //{
            
        //    DestroyOptions();
        //}
    }
    
    public void DisplayOptions()
    {
        background.enabled = true;
        //levelsMenager.GetComponent<LevelUpScreen>().DestroyElements = false;
        //levelsMenager.GetComponent<LevelUpScreen>().HideBackground = false;

        //1 button
        int a = Random.Range(0, buttonsNum);
        temp = a;

        Instantiate(buttons[a], this.transform);
        Vector3 pos = buttons[a].transform.position;
        pos.x = -300f;
        buttons[a].transform.position = pos;

        //2 button
        while (temp == a)
        {
            a = Random.Range(0, buttonsNum);
        }
        temp2 = a;
    
        Instantiate(buttons[a], this.transform);
        pos.x = 0f;
        buttons[a].transform.position = pos;

        //3button
        while (temp2 == a || temp == a)
        {
            a = Random.Range(0, buttonsNum);
        }
        temp3 = a;
        
        Instantiate(buttons[a], this.transform);
        pos.x = 300f;
        buttons[a].transform.position = pos;
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
        //levelsMenager.GetComponent<LevelUpScreen>().DestroyElements = false;
    }
    public void HideBackground()
    {
        Debug.Log("Time starts");
        Time.timeScale = 1;
        GameObject.Find("Canvas (1)").transform.GetChild(5).gameObject.GetComponent<Image>().enabled = false;
    }
    public void DisplayMagazine(int selectedUpgrade)
    {
        Instantiate(magazine, GameObject.Find("Canvas (1)").transform);
        Debug.Log(selectedUpgrade);
        GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x = selectedUpgrade;
        displayNextBullet.Invoke();
    }
}
