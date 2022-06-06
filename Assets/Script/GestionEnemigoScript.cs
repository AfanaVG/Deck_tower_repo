using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionEnemigoScript : MonoBehaviour
{
    public string nombre;
     public int saludMax = 100;
     public int saludActual;

     public int energia;

     public int fuerza;
     public int magia;

     public int escudo = 0;

     public BarraSaludScript barraSaludScript;

     public Text nombreTXT;

    void Start()
    {

        this.saludActual = this.saludMax;
        this.barraSaludScript.setSaludMaxima(this.saludMax);
        this.barraSaludScript.SetEscudo(this.escudo);
        this.nombreTXT.text = this.nombre;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            perderSalud(20);
            recargarEnergia(1);
        }
    }

    public void perderSalud(int damage){
        int damageRecibido = damage;
        if(this.escudo > 0){
            
            damageRecibido -= this.escudo;
            if(damageRecibido <= 0 ){
                damageRecibido = 0;
            }

            this.escudo -= damage;
            if(this.escudo <= 0){
                this.barraSaludScript.SetEscudo(0);
            }else{
                this.barraSaludScript.SetEscudo(this.escudo);
            }
            
        }

        this.saludActual -= damageRecibido;
        

        if(this.saludActual < 0){
            this.barraSaludScript.SetSalud(0);
        }else{
            this.barraSaludScript.SetSalud(this.saludActual);
        }
        
    }

    public void curar(int cura){
        this.saludActual += cura;

        if(this.saludActual >= this.saludMax){
            this.barraSaludScript.SetSalud(saludMax);
            this.saludActual = saludMax;
        }else{
            this.barraSaludScript.SetSalud(this.saludActual);
        } 
    }

    public void protegerse(int armadura){
        this.escudo += armadura;
        this.barraSaludScript.SetEscudo(escudo);
        
    }

    public void gastarEnergia(){
        this.energia--;

        if(energia <= 0){
           this.energia = 0;

        }
    }

    public void recargarEnergia(int recarga){
        this.energia += recarga;
    }



}
