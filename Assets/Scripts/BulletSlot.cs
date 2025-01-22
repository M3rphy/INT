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
        if (eventData.pointerDrag != null)
        {
      
            selectedBulletslot.Invoke();
          
        }
    }
}
