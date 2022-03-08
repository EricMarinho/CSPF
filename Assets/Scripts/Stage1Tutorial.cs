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
    private Queue<string> sentences;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(true);
        sentences = new Queue<string>();
        StartDialogue(dialogue);
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
    }

}
