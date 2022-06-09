using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TransicionScript : MonoBehaviour
{
    public TMP_Text pisoTXT;

    void Start()
    {
        cargarJugador();
        StartCoroutine(avance());
    }

    private void cargarJugador(){
        DatosJugador data = SistemaGuardado.cargar();

        if (data != null)
        {
            pisoTXT.text = "Piso "+data.piso;
        }
    }

    IEnumerator avance(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene");
    }

    
}
