using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class LevelUpScreen : MonoBehaviour
{

    
    public bool HpUpEvent = false;
    public bool SpeedUpEvent = false;
    public bool DestroyElements = false;
    public bool HideBackground = false;
    public int a = 0;
  


    public void HpUpExecutor()
    {
  
        DestroyObjects();
        EnabledBackground();
    }   
    public void SpeedUpExecutor()
    {
        SpeedUpEvent = true;
        DestroyObjects();
        EnabledBackground();
    }
    public void TripleShot()
    {
        DestroyObjects();
        
    }
    public void DestroyObjects()
    {
        DestroyElements = true;
    }
    public void EnabledBackground()
    {
        HideBackground = true;
    }
   
    
}
