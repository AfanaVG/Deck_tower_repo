using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraSaludScript : MonoBehaviour
{
    public Slider slider;
    public Text saludTXT;
    public Text escudoTXT;

    public void setSaludMaxima(int salud){

        slider.maxValue = salud;
        slider.value = salud;
        saludTXT.text = salud + " / " + slider.maxValue;
    }

    public void SetSalud(int salud){
        slider.value = salud;
        saludTXT.text = salud + " / " + slider.maxValue;
        
    } 
    public void SetEscudo(int escudo){
        escudoTXT.text = escudo+"";
    }
}
