using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPersonajeScript : MonoBehaviour
{
     public int saludMax = 100;
     public int saludActual;

     public int escudo = 0;

     public BarraSaludScript barraSaludScript;

    void Start()
    {

        saludActual = saludMax;
        barraSaludScript.setSaludMaxima(saludMax);
        barraSaludScript.SetEscudo(escudo);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            perderSalud(20);
        }
    }

    public void perderSalud(int damage){
        saludActual -= damage;

        if(saludActual < 0){
            barraSaludScript.SetSalud(0);
        }else{
            barraSaludScript.SetSalud(saludActual);
        }
        
    }
}
