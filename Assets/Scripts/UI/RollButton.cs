using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RollButton : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction Clicked;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }
}
