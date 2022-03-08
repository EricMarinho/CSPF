using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void LoadStageOne(){
        SceneManager.LoadScene(2);
    }

    public void LoadStageTwo(){
        SceneManager.LoadScene(3);
    }

    public void LoadStageThree(){
        SceneManager.LoadScene(4);
    }

    public void LoadStageFour(){
        SceneManager.LoadScene(5);
    }

}
