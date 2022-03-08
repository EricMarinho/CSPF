using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData){
        Destroy(gameObject);
    }

}
