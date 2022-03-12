using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardManager : MonoBehaviour, IPointerClickHandler
{

    public UnityEvent cardFunction;

    public void OnPointerClick(PointerEventData eventData){
        Destroy(gameObject);
    }


}
