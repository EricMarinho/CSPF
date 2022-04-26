using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject triesOject; 
    public GameObject settingsButton;
    public GameObject cardManager;
    public Animator animator;
    public Animator personagemAnimator;
    public Text nameText;
    public Text dialogueText;
    public Dialogue dialogue;
    private Queue<string> sentences;
    public GameObject alfredo;
    public GameObject dialogueBox;
    
    void Start()
    {
        sentences = new Queue<string>();
        // Inicia o dialogo no início da execução do código
        StartDialogue(dialogue);
    }

    private void Update(){
        // Caso o jogador pressione qualquer tecla o dialogo avança
        if (Input.anyKeyDown){
            DisplayNextSentence();
        }
    }

    IEnumerator DestroyAssets(){
        //Destrói os objetos que não serão utilizados quando acabar o diálogo
        yield return new WaitForSeconds(2);
        Destroy(alfredo);
        Destroy(dialogueBox);
        Destroy(gameObject);
    }

    public void StartDialogue(Dialogue dialogue){
        // Mostra a primeira sentença do diálogo e preenche a fila de sentenças do diálogo
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    
    public void DisplayNextSentence(){
        // Função para passar para a próxima sentença do dialogo e limpar a anterior da fila
        if(sentences.Count==0){
            // Caso seja a última sentença da fila o diálogo encerra
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;         
    }

    public void EndDialogue(){
        // Transiciona para o início da gameplay e encerra o diálogo
        animator.SetBool("isEnd", true);
        personagemAnimator.SetBool("isEnd", true);
        cardManager.SetActive(true);
        settingsButton.SetActive(true);
        triesOject.SetActive(true);
        StartCoroutine("DestroyAssets");
    }
}