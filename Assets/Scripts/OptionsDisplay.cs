using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsDisplay : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private int buttonsNum;
    [SerializeField] private GameObject levelsMenager;
    private int temp;
    private int temp2;
    private int temp3;
    private GameObject object1;
    private GameObject object2;
    private GameObject object3;

    private void Update()
    {
            
           
        if (levelsMenager.GetComponent<LevelUpScreen>().DestroyElements)
        {
            
            DestroyOptions();
        }
    }
    
    public void DisplayOptions()
    {
        background.enabled = true;
        levelsMenager.GetComponent<LevelUpScreen>().DestroyElements = false;

        //1 button
        int a = Random.Range(0, buttonsNum);
        temp = a;
        object1 = buttons[a];
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
        object2 = buttons[a];
        Instantiate(buttons[a], this.transform);
        pos.x = 0f;
        buttons[a].transform.position = pos;

        //3button
        while (temp2 == a || temp == a)
        {
            a = Random.Range(0, buttonsNum);
        }
        temp3 = a;
        object3 = buttons[a];
        Instantiate(buttons[a], this.transform);
        pos.x = 300f;
        buttons[a].transform.position = pos;
    }
    public void DestroyOptions()
    {
        
        background.enabled = false;
        //Destroy(object1);
        //Destroy(object2);
        //Destroy(object3);
       
        
    }
}
