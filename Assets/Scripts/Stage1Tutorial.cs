using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1Tutorial : MonoBehaviour
{

    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    public Dialogue dialogue;
    public Queue<string> sentences;
    public GameObject dialogueBox;
    string sentence;
    public GameObject canvas;

  void Start()
    {
        dialogueBox.SetActive(true);
        sentences = new Queue<string>();
        StartDialogue(dialogue);
    }

     IEnumerator ErrorMessage(){
         // Mostra uma mensagem caso o jogador escolha uma carta que não satisfaça o desafio
         dialogueText.text = "Você errou, tente novamente.";
         yield return new WaitForSeconds(1.5f);
         dialogueText.text = sentence;
     }
    public void StartDialogue(Dialogue dialogue){
        nameText.text = dialogue.name;
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndStage(){
        // Mostra a tela de fim de estágio
        dialogueBox.SetActive(false);
        canvas.SetActive(true);
    }

}