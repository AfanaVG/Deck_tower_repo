using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enemigoDrop : MonoBehaviour, IDropHandler
{

    public GestionPersonajeScript personaje;
    private generadorManos generadorManos;
    private GameObject gc;
    private Carta cartaSel;
    private GameObject jugador;

    private void Start(){
        jugador = GameObject.FindGameObjectsWithTag("Player")[0];
        generadorManos = GameObject.Find("ManoCartas").GetComponent<generadorManos>();
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Ondrop");
        //cartaSel = eventData.pointerDrag.GetComponent<cartaDisplay>().carta.id;
        cartaSel = eventData.pointerDrag.GetComponent<cartaDisplay>().carta;
        gc = eventData.pointerDrag;
        jugador.GetComponent<GestionPersonajeScript>().gastarEnergia();

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

        Destroy(gc);
        //generadorManos.ordenarMano();

        
        
        

    }


}
