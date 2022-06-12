using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase que maneja los metodos y atributos del personaje
public class GestionPersonajeScript : MonoBehaviour
{
    public string nombre;
     public int saludMax = 100;
     public int saludActual;
     public int energia;
     public int fuerza;
     public int magia;
     public int escudo = 0; //Escudo del personaje
     public BarraSaludScript barraSaludScript; //Clase que nos permitira acceder a los metodos de la barrra de salud en la UI
     public Text nombreTXT; //Nombre del personaje en la UI
     public GameObject[] particle; //Array con las particulas disponibles para el personaje

    void Start()
    {
        this.saludActual = this.saludMax;
        this.barraSaludScript.setSaludMaxima(this.saludMax);
        this.barraSaludScript.SetEscudo(this.escudo);
        this.nombreTXT.text = this.nombre;
    }

    //Metodo usado para actualizar los datos de la interfaz
    public IEnumerator actualizarUI(){
        yield return new WaitForSeconds(0.5f);
        this.barraSaludScript.SetSalud(this.saludActual);
        this.barraSaludScript.SetEscudo(this.escudo);
    }

    //El personaje perdera salud en base al valor recibido y a su escudo
    public void perderSalud(int damage){
        int damageRecibido = damage;
        sfxReproductor(0);
        if(this.escudo > 0){
            damageRecibido -= this.escudo;
            if(damageRecibido <= 0 ){
                damageRecibido = 0;
            }
            this.escudo -= damage;
            if(this.escudo <= 0){
                this.barraSaludScript.SetEscudo(0);
                escudo = 0;
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

    //Recupera la salud del jugador en base al valor recibido
    public void curar(int cura){
        sfxReproductor(1);
        this.saludActual += cura;

        if(this.saludActual >= this.saludMax){
            this.barraSaludScript.SetSalud(saludMax);
            this.saludActual = saludMax;
        }else{
            this.barraSaludScript.SetSalud(this.saludActual);
        } 
    }

    //Añade escudo al jugador en base al valor recibido
    public void protegerse(int armadura){
        sfxReproductor(2);
        this.escudo += armadura;
        this.barraSaludScript.SetEscudo(escudo);
        
    }

    //Controla la particula generada
    public void sfxReproductor(int sfx){
        //Para consultar la particula correspondiente a cada numero ver en el inspector del personaje correspondiente
        switch (sfx)
        {
            case 0:
                Instantiate(particle[sfx],new Vector3(transform.position.x,transform.position.y*0.5f,transform.position.z-1),particle[sfx].transform.rotation);
                break;
            case 1:
                Instantiate(particle[sfx],new Vector3(transform.position.x,transform.position.y*0.5f,transform.position.z-1),particle[sfx].transform.rotation);
                break;
            case 2:
                Instantiate(particle[sfx],new Vector3(transform.position.x,transform.position.y*0.5f,transform.position.z-1),particle[sfx].transform.rotation);
                break;
            default:
                break;
        }
        
    }


}
