using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Clase que maneja los menus para avanzar piso o reiniciar
public class avancePisoScript : MonoBehaviour
{
    public GameObject menuSiguienteUI; //Menú para avanzar al siguiente nivel
    public GameObject menuReinicioUI; //Menú para volver al primer nivel

    //Activa el menú para avanzar al siguiente nivel 
    public void menuSig(){
        Time.timeScale = 0f;
        menuSiguienteUI.SetActive(true);
    }

    //Activa el menú para volver al primer nivel
    public void menuRe(){
        Time.timeScale = 0f;
        menuReinicioUI.SetActive(true);
    }

    //Lanza la escena de transición
    public void cargarTransi(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Transicion");
    }

    //Cierra el juego
    public void QuitGame(){
        Application.Quit();
    }
}
