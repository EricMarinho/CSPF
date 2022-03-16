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
    DrawManager draw;
    Stage1Tutorial nextSentence;

    private void Start() {
        nextSentence = FindObjectOfType<Stage1Tutorial>();
        draw = FindObjectOfType<DrawManager>();
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
        if(teste.Verify(valorCarta) == false){
            draw.Draw();
            Destroy(gameObject);
            //FALTA MENSAGEM DE ERRO
        }
        else{
            Debug.Log("Porra é essa");
            nextSentence.DisplayNextSentence();
            draw.Draw();
            Destroy(gameObject);
            //TROCAR METODO DE DRAW PELO METODO DE TROCA DE BARALHO
        }
        
    }


}
