using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject settingsButton;
    public GameObject cardManager;
    public Animator animator;
    public Animator personagemAnimator;
    public Text nameText;
    public Text dialogueText;
    public Dialogue dialogue;
    private Queue<string> sentences;
    
    void Start()
    {
        sentences = new Queue<string>();
        StartDialogue(dialogue);
    }

    private void Update() {
        if (Input.anyKeyDown){
            DisplayNextSentence();
        }
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
        if(sentences.Count==0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;         
    }

    public void EndDialogue(){
        animator.SetBool("isEnd", true);
        personagemAnimator.SetBool("isEnd", true);
        cardManager.SetActive(true);
        settingsButton.SetActive(true);
    }
}
