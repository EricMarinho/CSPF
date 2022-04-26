using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void ExitGame(){
        Application.Quit();
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void LoadStageOne(){
        SceneManager.LoadScene(1);
    }

    public void LoadStageTwo(){
        SceneManager.LoadScene(2);
    }

    public void LoadStageThree(){
        SceneManager.LoadScene(3);
    }

    public void LoadStageFour(){
        SceneManager.LoadScene(4);
    }

    public void LoadStageFive(){
        SceneManager.LoadScene(5);
    }

    public void LoadStageSix(){
        SceneManager.LoadScene(6);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}