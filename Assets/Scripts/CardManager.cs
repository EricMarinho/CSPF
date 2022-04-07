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
    int x, y ,z;

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
            case 6:
                x = Random.Range(0, 10);
                y = Random.Range(0, 10);
                valorCarta = x + y;
                valueText.text = $"{x} + {y}";
                break;
            case 7:
                x = Random.Range(0, 10);
                y = Random.Range(0, 10);
                z = Random.Range(3, 8);
                valorCarta = x + y + z;
                valueText.text = $"{x} + {y} + {z}";
                break;
            case 8:
                x = Random.Range(5, 10);
                y = Random.Range(1, 5);
                valorCarta = x - y;
                valueText.text = $"{x} - {y}";
                break;
            case 9:
                x = Random.Range(5, 10);
                y = Random.Range(1, 5);
                z = Random.Range(0, 10);
                valorCarta = x + z - y;
                valueText.text = $"{x} + {z} - {y}";
                break;
            case 10:
                y = Random.Range(0, 10);
                valorCarta = 2 * y;
                valueText.text = $"2 x {y}";
                break;
            case 11:
                x = Random.Range(0, 10);
                y = Random.Range(0, 10);
                valorCarta = x * y;
                valueText.text = $"{x} x {y}";
                break;
            case 12:
                x = Random.Range(1, 10);
                y = Random.Range(0, 10);
                z = Random.Range(1, 10);
                valorCarta = (y * z) - x;
                valueText.text = $"{x} - {y} x {z}";
                break;
            case 13:
                x = Random.Range(1, 5);
                y = Random.Range(1, 5);
                z = Random.Range(1, 5);
                valorCarta = (y * z) + z;
                valueText.text = $"{x} + {y} x {z}";
                break;
            case 14:
                x = Random.Range(5, 20);
                y = Random.Range(1, 5);
                valorCarta = x / y;
                valueText.text = $"{x} ÷ {y}";
                break;
            case 15:
                x = Random.Range(1, 10);
                y = Random.Range(5, 20);
                z = Random.Range(1, 5);
                valorCarta = (y / z) + x;
                valueText.text = $"{x} + {y} ÷ {z}";
                break;
            case 16:
                x = Random.Range(1, 10);
                y = Random.Range(5, 20);
                z = Random.Range(1, 5);
                valorCarta = x - (y / z);
                valueText.text = $"{x} - {y} ÷ {z}";
                break;
            case 17:
                x = Random.Range(5, 20);
                y = Random.Range(1, 5);
                z = Random.Range(1, 10);
                valorCarta = x / y * z;
                valueText.text = $"{x} ÷ {y} x {z}";
                break;
            case 18:
                x = Random.Range(1, 10);
                valorCarta = Mathf.Pow(x,2);
                valueText.text = $"{x}²";
                break;
            case 19:
                x = Random.Range(1, 10);
                y = Random.Range(1, 10);
                valorCarta = Mathf.Pow(x,2) + y;
                valueText.text = $"{x}² + {y}";
                break;
            case 20:
                x = Random.Range(1, 10);
                y = Random.Range(1, 10);
                valorCarta = Mathf.Pow(x,2) - y;
                valueText.text = $"{x}² - {y}";
                break;
            case 21:
                x = Random.Range(1, 10);
                valorCarta = Mathf.Pow(x,3);
                valueText.text = $"{x}³";
                break;
            case 22:
                x = Random.Range(1, 10);
                y = Random.Range(1, 10);
                valorCarta = Mathf.Pow(x,3) + y;
                valueText.text = $"{x}³ + {y}";
                break;
            case 23:
                x = Random.Range(1, 10);
                y = Random.Range(1, 10);
                valorCarta = Mathf.Pow(x,3) - y;
                valueText.text = $"{x}³ - {y}";
                break;
            case 24:
                x = Random.Range(2, 9);
                y = Random.Range(10, 20);
                valorCarta = y - x;
                valueText.text = $"{y} - √{Mathf.Pow(x,2)}";
                break;
            case 25:
                x = Random.Range(2, 9);
                y = Random.Range(1, 10);
                valorCarta = y - x;
                valueText.text = $"{y} + √{Mathf.Pow(x,2)}";
                break;
            case 26:
                x = Random.Range(2, 9);
                y = Random.Range(10, 20);
                valorCarta = y - x;
                valueText.text = $"{y} - ³√{Mathf.Pow(x,3)}";
                break;
            case 27:
                x = Random.Range(2, 9);
                y = Random.Range(1, 10);
                valorCarta = y - x;
                valueText.text = $"{y} + ³√{Mathf.Pow(x,3)}";
                break;
            case 28:
                x = Random.Range(2, 9);
                y = Random.Range(1, 9);
                valorCarta = y * x;
                valueText.text = $"{y} x √{Mathf.Pow(x,2)}";
                break;
            case 29:
                x = Random.Range(2, 9);
                y = Random.Range(1, 9);
                valorCarta = y * x;
                valueText.text = $"{y} x ³√{Mathf.Pow(x,3)}";
                break;
            case 30:
                x = Random.Range(1, 9);
                y = Random.Range(1, 9);
                valorCarta = x / y;
                valueText.text = $"√{Mathf.Pow(x,2)} ÷ {y}";
                break;
            case 31:
                x = Random.Range(1, 9);
                y = Random.Range(1, 9);
                valorCarta = x / y;
                valueText.text = $"³√{Mathf.Pow(x,3)} ÷ {y}";
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
