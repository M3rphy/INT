using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class levelCount : MonoBehaviour
{
    [SerializeField] private XpMenager xpMenager;
    [SerializeField] private TextMeshProUGUI text;
    

    void Update()
    {
        text.text = (xpMenager.level + 1 )+ "/ 20";
    }
}
