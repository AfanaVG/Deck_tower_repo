using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausaScript : MonoBehaviour
{

    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            control();
        }
    }

public void paused(){
    control();
}

void control(){
    if(GamePaused){
        Resume();
    }else
    {
        Pause();
    }
}

public void Resume(){
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GamePaused = false;
}

void Pause(){
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    GamePaused = true;
}

public void LoadMenu(){
    Time.timeScale = 1f;
    GamePaused = false;
    SceneManager.LoadScene("Menu");
}

public void QuitGame(){
    Application.Quit();
}

}
