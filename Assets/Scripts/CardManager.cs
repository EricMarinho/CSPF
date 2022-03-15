using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardManager : MonoBehaviour, IPointerClickHandler
{
    public int idCarta;
    float valorCarta = 0;
    SuccessTest teste;

    private void Start() {    
     
        teste = FindObjectOfType<SuccessTest>();

        switch(idCarta){
            case 1:
                valorCarta = 4f;
                break;
            case 2:
                valorCarta = 3f;
                break;
            case 3:
                valorCarta = 5f;
                break;
            case 4:
                valorCarta = 6f;
                break;
            default:
                Debug.Log("Carta Inválida");
                break;
        }
    }    

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log(teste.Verify(valorCarta));
        Destroy(gameObject);
    }


}
