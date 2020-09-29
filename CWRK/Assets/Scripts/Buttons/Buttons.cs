using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Hero hero;
    public int doit;

    bool working = false;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        working = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        working = false;
        hero.ReSet();
    }

    public void Update()
    {
        if(working)
        {
            if (doit == 1)
                hero.Left();
            else hero.Right();
        }
    }
}
