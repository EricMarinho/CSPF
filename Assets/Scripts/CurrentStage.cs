using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentStage : MonoBehaviour
{
    [SerializeField] int numeroEstagio;
    void Start() {
        
        if(numeroEstagio > PlayerPrefs.GetInt("StageCompleted")){
            this.gameObject.SetActive(false);
        }

    }

}
