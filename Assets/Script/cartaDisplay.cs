using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cartaDisplay : MonoBehaviour
{
    public Carta carta;
    public Image imgArte;
    public Text txtNombre;
    public Text txtDescripcion;
    private GestionPersonajeScript jugador;
    public int cPoder;

    void Start()
    {
        cPoder = carta.poder;
        imgArte.sprite = carta.img;
        txtNombre.text = carta.nombre;
        
        StartCoroutine("getJugador");
    }

    public IEnumerator getJugador(){
        yield return new WaitForSeconds(0.2f);
        jugador = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<GestionPersonajeScript>();

        switch (carta.id)
        {
            case 0:
            txtDescripcion.text = carta.descripcion.ToString().Replace("*",(jugador.fuerza + cPoder).ToString());
                break;
            case 1:
            txtDescripcion.text = carta.descripcion.ToString().Replace("*",(jugador.magia + cPoder).ToString());
                break;
            case 2:
            txtDescripcion.text = carta.descripcion.ToString().Replace("*",(cPoder).ToString());
                break;
            default:
                break;
        }
        

        
    }




}
