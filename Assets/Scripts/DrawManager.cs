using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject handManager;

    public Deck []decks;
    public Queue<Deck> decksList = new Queue<Deck>();
    
    void Start()
    {
        foreach(Deck deck in decks){
            decksList.Enqueue(deck);
        }
        StartCoroutine(setarMao());
    }

    public void Draw(){
        GameObject randomCardInCurrentDeck = decksList.ToArray()[0].cards[Random.Range(0, decksList.ToArray()[0].cards.Length)];
        GameObject cardInstance = Instantiate(randomCardInCurrentDeck, new Vector3(0,0,0),Quaternion.identity);
        cardInstance.transform.SetParent(handManager.transform, false);
    }

    IEnumerator setarMao(){
        for(var i = 0; i < 4; i++){
            yield return new WaitForSeconds(1);
            Draw();
        }
    }

    public void NextDeck(){
        decksList.Dequeue();
    }

}