using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectHandler : MonoBehaviour
{
    
    public GameObject stageSelect;
    [SerializeField] private GameObject optionsMenu;

    private void Awake() {

        if(PlayerPrefs.GetInt("stage") == 1){
            stageSelect.SetActive(true);
            PlayerPrefs.SetInt("stage", 0);
            return;
        }

        if (PlayerPrefs.GetInt("stage") == 2)
        {
            optionsMenu.SetActive(true);
            PlayerPrefs.SetInt("stage", 0);
        }

    }

}
