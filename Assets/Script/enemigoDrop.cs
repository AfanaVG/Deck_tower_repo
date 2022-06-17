using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Clase que maneja los posibles eventos al usar una carta
public class enemigoDrop : MonoBehaviour, IDropHandler
{

    public GestionPersonajeScript personaje; //Clase que proporcionara los atributos y metodos del jugador
    private GameObject gc; //Carta usada en el drop
    private Carta cartaSel;
    private GameObject jugador;
    private SistemaCombateScript sistema; //Nos permitira usar metodos del sistema de combate

    private void Start(){
        jugador = GameObject.FindGameObjectsWithTag("Player")[0];
        sistema = GameObject.Find("SistemaCombate").GetComponent<SistemaCombateScript>();
    
    }

    public void OnDrop(PointerEventData eventData)
    {
        cartaSel = eventData.pointerDrag.GetComponent<cartaDisplay>().carta;
        gc = eventData.pointerDrag; // Obtiene el objeto que se ha usado en el drop
        StartCoroutine(sistema.usarCarta()); 
        //Consultar la id de la carta en Assets/Prefabs/Carta o en el documento con la información del funcionamiento de cada carta
        switch (cartaSel.id)
        {
            case 0:
            personaje.perderSalud(cartaSel.poder+jugador.GetComponent<GestionPersonajeScript>().fuerza);
                break;
            case 1:
            personaje.curar(cartaSel.poder + jugador.GetComponent<GestionPersonajeScript>().magia);
                break;
            case 2:
            personaje.protegerse(cartaSel.poder);
                break;
            default:
                break;
        }

        //Se destruye la carta
        Destroy(gc);

        
        
        

    }


}
