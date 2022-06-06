using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorManos : MonoBehaviour
{
    public Transform[] posiciones;
    public GameObject[] cartas;
    public static GameObject[] mano = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            generarMano();
        }
    }

    public void generarMano(){
        int ncarta = 0;
        for (var i = 0; i < mano.Length; i++)
        {
            if(posiciones[i].transform.childCount == 0){
                ncarta = Random.Range(0, cartas.Length);
                mano[i] = cartas[ncarta];
                var c = Instantiate(mano[i],posiciones[i].position,mano[i].transform.rotation);
                //c.transform.parent = posiciones[i].transform;
                c.transform.SetParent(posiciones[i], true);
            }
        }
    }

/*
    public void ordenarMano(){
        for (var i = 0; i < mano.Length; i++)
        {
            if(posiciones[i].transform.childCount > 0){
                mano[i].transform.position = posiciones[i].transform.position;
                mano[i].transform.parent = posiciones[i].transform;
            }
        }
    }*/


}
