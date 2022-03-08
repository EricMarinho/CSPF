using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialCardsScript : MonoBehaviour, IPointerClickHandler
{
    Stage1Tutorial nextSentence;

    void Start(){
    nextSentence = FindObjectOfType<Stage1Tutorial>();
    }

   
    public void OnPointerClick(PointerEventData eventData){
        nextSentence.DisplayNextSentence();      
        Destroy(gameObject);
    }

}
