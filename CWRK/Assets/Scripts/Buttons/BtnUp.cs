using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Hero hero;
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        hero.IsUp();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }

}
