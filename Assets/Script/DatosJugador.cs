using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que almacenara los datos para generar el archivo de guardado
[System.Serializable]
public class DatosJugador
{
    public int piso;
    public int saludActual;
    public int saludMax;
    public int escudo;
    public int magia;
    public int fuerza;
    
    public DatosJugador(GestionPersonajeScript jugador, pisoScript p){
        piso = p.piso;

        saludActual = jugador.saludActual;
        saludMax = jugador.saludMax;
        escudo = jugador.escudo;
        magia = jugador.magia;
        fuerza = jugador.fuerza;
    }

}
