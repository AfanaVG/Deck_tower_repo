using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Clase que maneja los eventos relacionados con manipular la posicion de las cartas en pantalla
public class arrastrarScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup; //Clase necesaria para interactuar con la carta
    private Vector3 original; //Posicion original de la carta


    private void   Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        original = GetComponent<Transform>().position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .9f;
        canvasGroup.blocksRaycasts = false;
    }

    //Centra la carta en el puntero del ratón
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    //Contrala lo que sucede al soltar la carta
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        StartCoroutine("volver");
    }



    //Devuelve la carta a su posición original en la mano
    private IEnumerator volver(){
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = original;
    }

}
