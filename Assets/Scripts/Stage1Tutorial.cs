using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Tutorial : MonoBehaviour
{

    int i = 0;
    int buildIndex;
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
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        dialogueBox.SetActive(true);
        sentences = new Queue<string>();
        StartDialogue(dialogue);
    }

     IEnumerator ErrorMessage(){
        // Mostra uma mensagem caso o jogador escolha uma carta que não satisfaça o desafio
        if (PlayerPrefs.GetString("Language", "English") == "English")
        {
            dialogueText.text = "You missed it, try again.";
        }
        else
        {
            dialogueText.text = "Você errou, tente novamente.";
        }
         yield return new WaitForSeconds(1.5f);        
         dialogueText.text = sentence + $" {successTestHandler.answerQueue.ToArray()[0].answer}.";

     }

    public void StartDialogue(Dialogue dialogue){
        nameText.text = dialogue.name;
        sentences.Clear();

        if (PlayerPrefs.GetString("Language", "English") == "English")
        {
            foreach (string sentence in dialogue.englishSentences)
            {
                sentences.Enqueue(sentence);
            }
        }
        else
        {
            foreach (string sentence in dialogue.portuguesSentences)
            {
                sentences.Enqueue(sentence);
            }
        }

        successTestHandler = FindObjectOfType<SuccessTest>();
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        sentence = sentences.Dequeue();
        //if build index is 0 show only sentence
        if (buildIndex != 1)
        {
            dialogueText.text = sentence + $" {successTestHandler.answerQueue.ToArray()[0].answer}.";
        }
        else
        {
            if(sentences.Count != 4)
            {
                dialogueText.text = sentence + $" {successTestHandler.answerQueue.ToArray()[0].answer}.";
            }
            else
            {
                dialogueText.text = sentence;
            }

        }

    }

    public void EndStage(){
        // Mostra a tela de fim de estágio
        dialogueBox.SetActive(false);
        canvas.SetActive(true);
        if(buildIndex > PlayerPrefs.GetInt("StageCompleted")){
            PlayerPrefs.SetInt("StageCompleted", buildIndex);
        }
    }

}