using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class arrastrarScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    private Vector3 original;


    private void   Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        original = GetComponent<Transform>().position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("BeginDrag");
        canvasGroup.alpha = .9f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        StartCoroutine("volver");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPinterDown");
    }

    private IEnumerator volver(){
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = original;
    }

}
