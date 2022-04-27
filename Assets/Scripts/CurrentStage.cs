using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentStage : MonoBehaviour
{
    public GameObject[] stages;
    void Start() {
        
        int stageCompleted = PlayerPrefs.GetInt("stageCompleted");

    }

}
