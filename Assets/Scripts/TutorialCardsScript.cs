using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialCardsScript : MonoBehaviour, IPointerClickHandler
{
    Stage1Tutorial nextSentence;
    DrawManager draw;
    
    void Start(){
    nextSentence = FindObjectOfType<Stage1Tutorial>();
    draw = FindObjectOfType<DrawManager>();
    }

   
    public void OnPointerClick(PointerEventData eventData){
        nextSentence.DisplayNextSentence();
        draw.Draw();      
        Destroy(gameObject);
    }

}
