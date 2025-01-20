using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BulletSlot : MonoBehaviour, IDropHandler
{
    public UnityEvent selectedBulletslot;
    public void OnDrop(PointerEventData eventData)
    {
        int x = GameObject.Find("Canvas (1)").GetComponent<OptionsDisplay>().x;
        if (eventData.pointerDrag != null)
        {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
            selectedBulletslot.Invoke();
            Debug.Log("bb");
        }
    }
}
