using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase que maneja el apartado visual de la barra de salud
public class BarraSaludScript : MonoBehaviour
{
    public Slider slider; //Clase nativa de  Unity para crear sliders
    public Text saludTXT; //Cantidad de salud en la UI
    public Text escudoTXT; //Cantidad de escudo en la UI

    //Imprime la salud maxima en la UI
    public void setSaludMaxima(int salud){
        slider.maxValue = salud;
        slider.value = salud;
        saludTXT.text = salud + " / " + slider.maxValue;
    }

    //Imprime la salud actual en la UI
    public void SetSalud(int salud){
        slider.value = salud;
        saludTXT.text = salud + " / " + slider.maxValue;
        
    } 

    //Imprime el escudo actual en la UI
    public void SetEscudo(int escudo){
        escudoTXT.text = escudo+"";
    }
}
