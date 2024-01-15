using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{
    public GameObject handManager;
    CardManager cardManager;
    Animation anim;
    int errorCount = 0;

    public Deck []decks;
    public Queue<Deck> decksList = new Queue<Deck>();
    public GameObject defeatCanvas;
    public GameObject mainCanvas;
    public Text errorText;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        foreach(Deck deck in decks){
            // Coloca na fila os desafios daquela fase
            decksList.Enqueue(deck);
        }
        comprarMao();
    }

    public CardManager Draw(){
        // Escolhe aleatoriamente uma das cartas do deck atual e a cria
        GameObject randomCardInCurrentDeck = decksList.ToArray()[0].cards[Random.Range(0, decksList.ToArray()[0].cards.Length)];
        GameObject cardInstance = Instantiate(randomCardInCurrentDeck, new Vector3(0,0,0),Quaternion.identity);
        cardInstance.transform.SetParent(handManager.transform, false);
        return cardInstance.GetComponent<CardManager>();
    }

    public void NextDeck(){
        // Exclui a mão atual caso o jogador resolva o desafio e passa para o próximo
        decksList.Dequeue();
        excluirMao();
        comprarMao();
    }

    void comprarMao(){
        // Cria cartas e verifica se tem alguma carta que resolva o desafio, caso tenha, as cartas aparecem na tela, caso contrário as cartas serão substituídas até ter
        // uma mão onde pelo menos uma das cartas solucione o desafio
        bool isTrue = false;
        do{
            for(var i = 0; i < 4; i++){
                CardManager cardPicked = Draw();
                isTrue = cardPicked.verifyQuestion() ? true : isTrue;
            }

            if(!isTrue){
                excluirMao();
            }
         
        }while(!isTrue);
        anim.Play("HandAnimation");
            
    }

    void excluirMao(){
        foreach (Transform child in handManager.transform){
            Destroy(child.gameObject);
        }
    }

    public void ErrorDraw(){
        // Imprime uma nova carta caso o jogador escolha uma carta que não solucione o desafio
        CardManager cardPicked = Draw();
        cardPicked.cardAppear();
        errorCount++;
        if (PlayerPrefs.GetString("Language", "English") != "English")
        {
            errorText.text = $"Tentativas Restantes: {3 - errorCount}";
        }
        else
        {
            errorText.text = $"Remaining Attempts: {3 - errorCount}";
        }
        if (errorCount == 3){
            // Caso o jogador tenha errado 3 vezes, o jogo acaba
            defeatCanvas.SetActive(true);
            Destroy(mainCanvas);
        }
    }
}