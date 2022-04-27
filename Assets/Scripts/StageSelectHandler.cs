using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectHandler : MonoBehaviour
{
    
    public GameObject stageSelect;

    private void Awake() {

        if(PlayerPrefs.GetInt("stage") == 1){
            stageSelect.SetActive(true);
            PlayerPrefs.SetInt("stage", 0);
        }

    }

}
