using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessTest : MonoBehaviour
{
    public struct AnswerVerification
     {
        public float answer;
        public string type;
        public AnswerVerification(float answer, string type){
            this.answer = answer;
            this.type = type;
        }
     }

    AnswerVerification answerStruct;
    [SerializeField] int idFase;

    public Queue<AnswerVerification> answerQueue;

    void Start(){
        answerQueue = new Queue<AnswerVerification>();
        if(idFase == 1){
            answerStruct = new AnswerVerification(0f,"more");
            answerQueue.Enqueue(new AnswerVerification(3f, "equal"));
            answerQueue.Enqueue(new AnswerVerification(4f, "equal"));
        }
        else if(idFase == 2){
            return;
        }
           
    }

    public bool Verify(float answer){
        if(answerStruct.type == "less"){
            if(answer < answerStruct.answer){            
                answerStruct = (answerQueue.ToArray())[0];
                answerQueue.Dequeue();
                return true;
            }
            else{
                return false;
            }
        }
        else if(answerStruct.type == "more"){
            if(answer > answerStruct.answer){            
                answerStruct = (answerQueue.ToArray())[0];
                answerQueue.Dequeue();
                return true;
            }
            else{
                return false;
            }
        }
        else{
            if(answer == answerStruct.answer){            
                answerStruct = (answerQueue.ToArray())[0];
                answerQueue.Dequeue();
                return true;
            }
            else{
                return false;
            }
        }
    }

}

