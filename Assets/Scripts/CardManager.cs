using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardManager : MonoBehaviour, IPointerClickHandler
{
    public int idCarta;
    float valorCarta;
    SuccessTest teste;
    DrawManager draw;
    Stage1Tutorial nextSentence;
    Animation anim;

    void Awake() {
        nextSentence = FindObjectOfType<Stage1Tutorial>();
        draw = FindObjectOfType<DrawManager>();
        teste = FindObjectOfType<SuccessTest>();
        anim = GetComponent<Animation>();
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
        Debug.Log(draw.decksList.ToArray().Length);
        if(!teste.Verify(valorCarta)){
            draw.ErrorDraw();
            //FALTA MENSAGEM DE ERRO
        }
        else if(draw.decksList.ToArray().Length > 1){
            nextSentence.DisplayNextSentence();
            draw.NextDeck();
        }
        Destroy(gameObject);
    }

    public bool verifyQuestion(){
        return teste.VerifySimple(valorCarta);
    }

    public void cardAppear(){
        anim = gameObject.GetComponentInChildren<Animation>();
        anim.Play("CartaEntrando");
    }
}
