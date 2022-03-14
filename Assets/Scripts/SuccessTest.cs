using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessTest : MonoBehaviour
{
    public struct AnswerVerification
     {
        public int answer;
        public string type;
     }

    public Queue<AnswerVerification> answerQueue;

    void Start(){
        answerQueue = new Queue<AnswerVerification>();
        AnswerVerification answerFiller = new AnswerVerification();
        answerFiller.answer = 4;
        answerQueue.Enqueue(answerFiller);
    }

}
