using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private GameObject bulletSlot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.7f; 
       canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Input.mousePosition;
       
        rectTransform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.position = MagazineDisplay.panelStatic.position;
        Debug.Log(bulletSlot.transform.Find("Panel1").name);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        
    }

}
