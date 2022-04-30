using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enemigoDrop : MonoBehaviour, IDropHandler
{

    public GestionPersonajeScript personaje;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Ondrop");

        personaje.perderSalud(10);

    }


}
