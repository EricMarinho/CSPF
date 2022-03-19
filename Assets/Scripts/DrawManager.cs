using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject handManager;
    CardManager cardManager;
    Animation anim;

    public Deck []decks;
    public Queue<Deck> decksList = new Queue<Deck>();
    
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        foreach(Deck deck in decks){
            decksList.Enqueue(deck);
        }
        comprarMao();
    }

    public CardManager Draw(){
        GameObject randomCardInCurrentDeck = decksList.ToArray()[0].cards[Random.Range(0, decksList.ToArray()[0].cards.Length)];
        GameObject cardInstance = Instantiate(randomCardInCurrentDeck, new Vector3(0,0,0),Quaternion.identity);
        cardInstance.transform.SetParent(handManager.transform, false);
        return cardInstance.GetComponent<CardManager>();
    }

    public void NextDeck(){
        decksList.Dequeue();
        excluirMao();
        comprarMao();
    }

    void comprarMao(){
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
        CardManager cardPicked = Draw();
        cardPicked.cardAppear();
    }
}