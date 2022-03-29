using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardManager : MonoBehaviour, IPointerClickHandler
{
    public int idCarta;
    float valorCarta;
    SuccessTest successTestHandler;
    DrawManager draw;
    Stage1Tutorial nextSentence;
    Animation anim;
    Text valueText;

    void Awake() {

        // Coleta os componentes dos seguinte objetos

        valueText = gameObject.GetComponentInChildren<Text>();
        nextSentence = FindObjectOfType<Stage1Tutorial>();
        draw = FindObjectOfType<DrawManager>();
        successTestHandler = FindObjectOfType<SuccessTest>();
        anim = gameObject.GetComponentInChildren<Animation>();
        
        
        // Escolhe qual o valor da carta de acordo com o ID

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
            case 5:
                valorCarta = (int) Random.Range(0f, 10f);
                valueText.text = valorCarta.ToString();
                break;
            default:
                Debug.Log("Carta Inválida");
                break;
        }
    }    

    // Ativa quando o usuário seleciona a carta
    public void OnPointerClick(PointerEventData eventData){
        
        // Testando se o desafio condiz com o valorCarta

        if(!successTestHandler.Verify(valorCarta)){
            // Caso a resposta não satisfaça o desafio, outra carta será comprada pela função draw e aparecerá uma mensagem de erro.
            draw.ErrorDraw();
            nextSentence.StartCoroutine("ErrorMessage");
        }
        else if(draw.decksList.ToArray().Length > 1){
            // Caso a resposta satisfaça o desafio, o dialogo prossegue e outra mão é comprada
            nextSentence.DisplayNextSentence();
            draw.NextDeck();
        }
        else{
            // Caso termine todos os desafios, aparece a tela de fim de estágio
            nextSentence.EndStage();
        }
        // Destrói a carta quando o jogador a escolhe
        Destroy(gameObject);
    }

    public bool verifyQuestion(){
        // Verifica se a carta satisfaz o desafio
        return successTestHandler.VerifySimple(valorCarta);
    }

    public void cardAppear(){
        // Roda a animação da carta aparecendo
        anim.Play("CartaEntrando");
    }
}
