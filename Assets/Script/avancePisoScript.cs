using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class avancePisoScript : MonoBehaviour
{
    public GameObject menuSiguienteUI;
    public GameObject menuReinicioUI;

    // Update is called once per frame
    void Update()
    {
        
    }

public void menuSig(){
    Time.timeScale = 0f;
    menuSiguienteUI.SetActive(true);
}

public void menuRe(){
    Time.timeScale = 0f;
    menuReinicioUI.SetActive(true);
}

public void CargarSig(){
    Time.timeScale = 1f;
    SceneManager.LoadScene("Transicion");
}

public void CargarReinicio(){
    Time.timeScale = 1f;
    SceneManager.LoadScene("Transicion");
}

public void QuitGame(){
    Application.Quit();
}
}
