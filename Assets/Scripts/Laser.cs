using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //odniesienienie do componentu LineRenderer
    private LineRenderer line;
    //Czas ¿ycia obiektu
    [SerializeField] private float existTime = 2f;
    private float curTime;

    //przypisanie line oraz ustawienie pocz¹tkowego punktu line renderera
    //nastêpnie obliczenie punktu w kierunku myszki oddalonego o 1000
    //i przypisanie tej wartoœci jako koñcowy punkt line Renderera
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        const float length = 1000.0f;
        var endPos = new Vector3(mousePosition.x, mousePosition.y);
        endPos = ((endPos - transform.position) * length) + transform.position;
        line.SetPosition(1,endPos);
    }
    //w trakcie czasu ¿ycia obiektu powolne zmienianie mu jego szerokoœci
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > existTime)
        {
            Destroy(gameObject);
        }
        else
        {
            line.SetWidth(1f -curTime / existTime, 1f -curTime / existTime);
            transform.localScale = new Vector2(1f- curTime / existTime,1);
        }
    }
}
