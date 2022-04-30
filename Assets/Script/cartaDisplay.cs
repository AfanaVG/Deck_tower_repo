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
    void Start()
    {
        imgArte.sprite = carta.img;
        txtNombre.text = carta.nombre;
        txtDescripcion.text = carta.descripcion;
    }
}
