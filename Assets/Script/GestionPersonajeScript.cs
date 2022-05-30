using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionPersonajeScript : MonoBehaviour
{
    public string nombre;
     public int saludMax = 100;
     public int saludActual;

     public int energia;

     public int fuerza;
     public int magia;

     public int escudo = 0;

     public BarraSaludScript barraSaludScript;

     public Text nombreTXT;

    void Start()
    {

        saludActual = saludMax;
        barraSaludScript.setSaludMaxima(saludMax);
        barraSaludScript.SetEscudo(escudo);
        nombreTXT.text = nombre;

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

    public void curar(int cura){
        saludActual += cura;

        if(saludActual > saludMax){
            barraSaludScript.SetSalud(saludMax);
        }else{
            barraSaludScript.SetSalud(saludActual);
        }
        
    }
}
