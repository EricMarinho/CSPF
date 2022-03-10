using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessTest : MonoBehaviour
{
    public struct AnswerVerification
     {
        public int answer;
        public string typeOf;
     }

    public Queue<AnswerVerification> answerQueue;

    void Start(){
        answerQueue = new Queue<AnswerVerification>();
        AnswerVerification answerFiller = new AnswerVerification();
        answerFiller.answer = 4;
        answerQueue.Enqueue(answerFiller);
    }
    void Update()
    {
     Debug.Log(answerQueue.ToArray()[0].answer);  
    }
}
