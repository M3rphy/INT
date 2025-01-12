using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LevelUpScreen : MonoBehaviour
{

    
    public bool HpUpEvent = false;
    public bool SpeedUpEvent = false;
    public bool DestroyElements = false;
    public int a = 0;


    public void HpUpExecutor()
    {
        
        DestroyElements = true;
        HpUpEvent = true;
    }   
    public void SpeedUpExecutor()
    {
        
        DestroyElements = true;
        SpeedUpEvent = true;
    }

    
}
