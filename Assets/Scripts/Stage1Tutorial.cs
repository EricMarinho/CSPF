using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Tutorial : MonoBehaviour
{

    int i = 0;
    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    public Dialogue dialogue;
    public Queue<string> sentences;
    public GameObject dialogueBox;
    string sentence;
    public GameObject canvas;
    SuccessTest successTestHandler;

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
         if(SceneManager.GetActiveScene().buildIndex != 2){         
            dialogueText.text = sentence + $" {successTestHandler.answerQueue.ToArray()[0].answer}.";
        }
         else{
            stage1Function(i - 1);
         }
     }
    public void StartDialogue(Dialogue dialogue){
        nameText.text = dialogue.name;
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        successTestHandler = FindObjectOfType<SuccessTest>();
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        sentence = sentences.Dequeue();
         if(SceneManager.GetActiveScene().buildIndex != 1){         
            dialogueText.text = sentence + $" {successTestHandler.answerQueue.ToArray()[0].answer}.";
         }
         else{
             stage1Function(i);
             i++;
         }
    }

    public void EndStage(){
        // Mostra a tela de fim de estágio
        dialogueBox.SetActive(false);
        canvas.SetActive(true);
        if(SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("StageCompleted")){
            PlayerPrefs.SetInt("stageCompleted", SceneManager.GetActiveScene().buildIndex);
        }    
    }

    void stage1Function(int x){
        if (x == 0){
                dialogueText.text = sentence;        
             }
        else if (x == 1){
                dialogueText.text = $"Parabéns, você conseguiu. Agora escolha a carta com {successTestHandler.answerQueue.ToArray()[0].answer} LADOS." ;
        }
        else if (x == 2){
                dialogueText.text = $"Continue assim! Escolha uma carta com {successTestHandler.answerQueue.ToArray()[0].answer} LADOS." ;
        }
        else{ 
                dialogueText.text = sentence + $" {successTestHandler.answerQueue.ToArray()[0].answer}.";
        }
    }
}