using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessTest : MonoBehaviour
{
    public Answers []answers;

    public Queue<Answers> answerQueue;

    void Start(){
        answerQueue = new Queue<Answers>();
        answerQueue.Clear();
        
        // Preenchendo a fila com as respostas dos desafios da fase
        foreach(Answers answers in answers){
            answers.answer = answers.answers[Random.Range(0, answers.answers.Length)];
            answerQueue.Enqueue(answers);
        }

    }

    public bool Verify(float valorCarta){
    // Função para verificar se a resposta do jogador satisfaz a questão, caso esteja certo o código passa para o próximo desafio
        Answers playerAnswer = answerQueue.ToArray()[0];
        bool passTest;
    // Os desafios podem pedir um número igual, menor ou maior que o valor dado. Dependendo de qual o critério de acerto, o código analisará a resposta e retornará
    // o resultado
        switch(playerAnswer.type){
            case "less":
                passTest = valorCarta < playerAnswer.answer;
            break;

            case "more":
                passTest = valorCarta > playerAnswer.answer;
            break;

            default:
                passTest = valorCarta == playerAnswer.answer;
            break;
            
        }

        if(passTest){
            answerQueue.Dequeue();
        }
        return passTest;        
    }

    public bool VerifySimple(float valorCarta){
        // Função para verificar se a resposta do jogador satisfaz a questão, mas que caso acerte ele só retorna o resultado, sem passar para o próximo desafio
        Answers playerAnswer = answerQueue.ToArray()[0];
        bool passTest;

        switch(playerAnswer.type){
            case "less":
                passTest = valorCarta < playerAnswer.answer;
            break;

            case "more":
                passTest = valorCarta > playerAnswer.answer;
            break;

            default:
                passTest = valorCarta == playerAnswer.answer;
            break;
            
        }
        return passTest;        
    }

}