using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsDestroy : MonoBehaviour
{
    [SerializeField] GameObject levelsMenager;
   private void Start()
    {
        //Destroy(gameObject, 1f);
    }
    
    void Update()
    {
        if (levelsMenager.GetComponent<LevelUpScreen>().DestroyElements)
        {
            Destroy(gameObject);
        }
    }
}
