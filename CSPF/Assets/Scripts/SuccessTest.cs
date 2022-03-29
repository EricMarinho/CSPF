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
        
        foreach(Answers answers in answers){
            answerQueue.Enqueue(answers);
        }

    }

    public bool Verify(float answer){

        Answers playerAnswer = answerQueue.ToArray()[0];
        bool passTest;

        switch(playerAnswer.type){
            case "less":
                passTest = answer < playerAnswer.answer;
            break;

            case "more":
                passTest = answer > playerAnswer.answer;
            break;

            default:
                passTest = answer == playerAnswer.answer;
            break;
            
        }

        if(passTest){
            answerQueue.Dequeue();
        }
        return passTest;        
    }

    public bool VerifySimple(float answer){
        Answers playerAnswer = answerQueue.ToArray()[0];
        bool passTest;

        switch(playerAnswer.type){
            case "less":
                passTest = answer < playerAnswer.answer;
            break;

            case "more":
                passTest = answer > playerAnswer.answer;
            break;

            default:
                passTest = answer == playerAnswer.answer;
            break;
            
        }
        return passTest;        
    }

}