using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionPersonajeScript : MonoBehaviour
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
     

     public GameObject[] particle;

    void Start()
    {

        this.saludActual = this.saludMax;
        this.barraSaludScript.setSaludMaxima(this.saludMax);
        this.barraSaludScript.SetEscudo(this.escudo);
        this.nombreTXT.text = this.nombre;
        

    }

    public IEnumerator actualizarUI(){
        yield return new WaitForSeconds(0.5f);
        this.barraSaludScript.SetSalud(this.saludActual);
        this.barraSaludScript.SetEscudo(this.escudo);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            perderSalud(20);
        }
        //Debug.Log(energiaTXT.text.ToString());
    }

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

    public void protegerse(int armadura){
        sfxReproductor(2);
        this.escudo += armadura;
        this.barraSaludScript.SetEscudo(escudo);
        
    }

    public void sfxReproductor(int sfx){
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
