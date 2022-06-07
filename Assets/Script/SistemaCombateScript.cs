using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class SistemaCombateScript : MonoBehaviour
{
    public GameObject jugadorPrefab;
    public GameObject[] enemigoPrefab;

    public Transform posJugador;
    public Transform posEnemigo;

    GestionPersonajeScript jugadorGest;
    GameObject jugadorGO;
    private Text energiaTXT;

    GestionPersonajeScript enemigoGest;
    GameObject enemigoGO;

    public GameObject dialogo;
    public Text dialogoTXT;

    public BattleState state;

    private GameObject generadorManos;
    
    void Start()
    {
        state = BattleState.START;
        generadorManos = GameObject.Find("ManoCartas");
        this.energiaTXT = GameObject.Find("energiaTXT").GetComponent<Text>();
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        jugadorGO = Instantiate(jugadorPrefab, posJugador.position,Quaternion.identity);
        jugadorGest = jugadorGO.GetComponent<GestionPersonajeScript>();
        int enemigospawn = Random.Range(0, enemigoPrefab.Length);
        enemigoGO = Instantiate(enemigoPrefab[enemigospawn], posEnemigo.position, enemigoPrefab[enemigospawn].GetComponent<Transform>().rotation);
        enemigoGest = enemigoGO.GetComponent<GestionPersonajeScript>();

        dialogo.SetActive(true);

        dialogoTXT.text = "Comienza el combate";

        yield return new WaitForSeconds(2f);

        dialogo.SetActive(false);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

        
    }

    void PlayerTurn()
        {
            StartCoroutine(mostrarDialogo("Tu turno"));
            generadorManos.SetActive(true);   
            generadorManos.GetComponent<generadorManos>().generarMano();
            recargarEnergia(3,1,jugadorGest);

        }

    IEnumerator mostrarDialogo(string txt){
        dialogo.SetActive(true);

        dialogoTXT.text = txt;

        yield return new WaitForSeconds(1f);

        dialogo.SetActive(false);
    }

    public void gastarEnergia(int modo, GestionPersonajeScript p){
        p.energia--;

        switch (modo)
        {
            case 1:
                if(p.energia <= 0){
                    this.energiaTXT.text = p.energia+" / 3";

                }else{
                    this.energiaTXT.text = p.energia+" / 3";
                } 
                break;
            default:
                break;
        } 
    }

    public void recargarEnergia(int recarga, int modo, GestionPersonajeScript p){
        switch (modo)
        {
            case 1:
                p.energia += recarga;
                this.energiaTXT.text = p.energia+" / 3";
                break;
            case 2:
                p.energia += recarga;
                break;
            default:
                break;
        }
    }

    public void usarCarta(){
        gastarEnergia(1,jugadorGest);
        StartCoroutine(comprobarGanar());
        if(jugadorGest.energia <= 0 && state == BattleState.PLAYERTURN){
            generadorManos.SetActive(false); 
            state = BattleState.ENEMYTURN;
            StartCoroutine(turnoEnemigo());
        }
    }

    IEnumerator turnoEnemigo(){

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(mostrarDialogo(enemigoGest.nombre + " te ataca"));

        yield return new WaitForSeconds(1.2f);

        jugadorGest.perderSalud(enemigoGest.fuerza);

        yield return new WaitForSeconds(1f);

        StartCoroutine(comprobarGanar());

        yield return new WaitForSeconds(0.5f);

        if(state == BattleState.ENEMYTURN){
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    IEnumerator comprobarGanar(){
        yield return new WaitForSeconds(0.5f);
        Debug.Log(enemigoGest.saludActual);
        if (enemigoGest.saludActual <= 0){
            state = BattleState.WON;
            StartCoroutine(mostrarDialogo("¡Has ganado!"));
        }else if(jugadorGest.saludActual <= 0){
            StartCoroutine(mostrarDialogo("¡Has perdido!"));
            state = BattleState.LOST;
        }
    }

    public void pasarTurno(){
        StartCoroutine(mostrarDialogo("Pasas tu turno"));
        this.energiaTXT.text = 0+" / 3";
        jugadorGest.energia = 0;
        generadorManos.SetActive(false); 
        state = BattleState.ENEMYTURN;
        StartCoroutine(turnoEnemigo());
    }

}
