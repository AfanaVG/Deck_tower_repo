using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase que pinta los datos de la carta en pantalla
public class cartaDisplay : MonoBehaviour
{
    public Carta carta; //Objeto scipteable con los atributos de la carta
    public Image imgArte;
    public Text txtNombre;
    public Text txtDescripcion;
    private GestionPersonajeScript jugador; // Clase que nos proporcionara los atributos del jugador
    public int cPoder;

    void Start()
    {
        cPoder = carta.poder;
        imgArte.sprite = carta.img;
        txtNombre.text = carta.nombre;
        
        StartCoroutine("getJugador");
    }

    //Pinta la descripción segun las estadistaicas de la carta y del jugador
    public IEnumerator getJugador(){
        yield return new WaitForSeconds(0.2f);
        jugador = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<GestionPersonajeScript>();
        //Consultar la id de la carta en Assets/Prefabs/Carta o en el documento con la información del funcionamiento de cada carta
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
