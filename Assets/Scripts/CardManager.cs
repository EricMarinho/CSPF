using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardManager : MonoBehaviour, IPointerClickHandler
{
    public int idCarta;
    int valorCarta = 0;


    private void Start() {    
     
        switch(idCarta){
            case 1:
                valorCarta = 4;
                break;
            case 2:
                valorCarta = 3;
                break;
            case 3:
                valorCarta = 5;
                break;
            case 4:
                valorCarta = 6;
                break;
            default:
                Debug.Log("Carta Inválida");
                break;
        }
    }    

    public void OnPointerClick(PointerEventData eventData){
        Destroy(gameObject);
    }


}
