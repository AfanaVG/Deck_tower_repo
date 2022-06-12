using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase que se encarga de impimer en la UI el piso actual
public class pisoScript : MonoBehaviour
{

    public int piso = 1;
    public Text pisoTXT;
    // Start is called before the first frame update
    void Start()
    {
        cargarJugador();
        pisoTXT.text = ""+piso;
    }

    //Metodo que accede al archivo de guardado local
    private void cargarJugador(){
        DatosJugador data = SistemaGuardado.cargar();

        if (data != null)
        {
            piso = data.piso;
        }
    }

}
