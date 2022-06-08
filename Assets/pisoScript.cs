using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void cargarJugador(){
        DatosJugador data = SistemaGuardado.cargar();

        if (data != null)
        {
            piso = data.piso;
        }
    }

}
