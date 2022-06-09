using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject clasMenuUI;
    public static bool clasi_abierto = false;

    public void PlayGame (){
        SceneManager.LoadScene("Transicion");
    }

    public void QuitGame (){
        Application.Quit();
    }

    public void Clasi(){
        if(clasi_abierto){
            clasMenuUI.SetActive(false);
            clasi_abierto = false;
        }else
        {
            clasMenuUI.SetActive(true);
            clasi_abierto = true;
        }
    }
}
