using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que generara la mano de cartas
public class generadorManos : MonoBehaviour
{
    public Transform[] posiciones; //Posiciones de las cartas en pantalla
    public GameObject[] cartas; //Array Cartas que pueden ser generadas
    public static GameObject[] mano = new GameObject[5]; // Cartas en la mano

    //Metodo que controla las cartas creadas
    public void generarMano(){
        int ncarta = 0;
        for (var i = 0; i < mano.Length; i++)
        {
            if(posiciones[i].transform.childCount == 0){
                ncarta = Random.Range(0, cartas.Length);
                mano[i] = cartas[ncarta];
                var c = Instantiate(mano[i],posiciones[i].position,mano[i].transform.rotation);
                c.transform.SetParent(posiciones[i], false);
                c.transform.localScale = posiciones[i].transform.localScale;
                c.transform.position = posiciones[i].position;

            }
        }
    }
}
