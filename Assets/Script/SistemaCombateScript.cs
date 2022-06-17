using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST } //Variable enumeracion que almacena los distintos estados del combate

public class SistemaCombateScript : MonoBehaviour
{
    public GameObject jugadorPrefab; //Personaje que manejara el jugador
    public GameObject[] enemigoPrefab; //Array con los enemigos que pueden ser generados

    public Transform posJugador; //Posición del personaje jugador
    public Transform posEnemigo; //Posición del personaje enemigo

    GestionPersonajeScript jugadorGest; //Script con los datos del jugador en la partida
    public GestionPersonajeScript jugadorInicio; //Script con los datos del jugador base
    GameObject jugadorGO; //Objeto del personaje jugador
    private Text energiaTXT; //Texto con la energia actual del jugador en pantalla

    GestionPersonajeScript enemigoGest; //Script con los datos del enemigo en la partida
    GameObject enemigoGO; //Objeto del personaje enemigo

    public GameObject dialogo; //Panel usado para los dialogos de los turnos
    public Text dialogoTXT; //Texto impreso entre turnos

    public BattleState state; //Variable que controlara el estado actual de los turnos

    private GameObject generadorManos; //Mano de cartas del jugador
    public DatabaseInGame dbIngame; //Control de base de datos usado dentro del combate
    public pisoScript pisoScript; //Control del piso en el que se encuentra el jugador
    public avancePisoScript avancePisoScript; //Control de los menus para la transición entre pisos
    
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

        yield return new WaitForSeconds(1f);

        dialogo.SetActive(false);

        state = BattleState.PLAYERTURN;
        cargarJugador();
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

    public IEnumerator usarCarta(){
        gastarEnergia(1,jugadorGest);
        StartCoroutine(comprobarGanar());
        yield return new WaitForSeconds(0.5f);
        if(jugadorGest.energia <= 0 && state == BattleState.PLAYERTURN){
            generadorManos.SetActive(false); 
            state = BattleState.ENEMYTURN;
            StartCoroutine(turnoEnemigo());
        }
    }

    IEnumerator turnoEnemigo(){

        yield return new WaitForSeconds(0.2f);

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
        //Debug.Log(enemigoGest.saludActual);
        if (enemigoGest.saludActual <= 0){
            Destroy(enemigoGO);
            state = BattleState.WON;
            pisoScript.piso++;
            SistemaGuardado.Guardar(jugadorGest,pisoScript);
            StartCoroutine(mostrarDialogo("¡Has ganado!"));
            dbIngame.GuardarPiso(pisoScript.piso);
            yield return new WaitForSeconds(1f);
            avancePisoScript.menuSig();
        }else if(jugadorGest.saludActual <= 0){
            Destroy(jugadorGO);
            state = BattleState.LOST;
            pisoScript.piso = 1;
            SistemaGuardado.Guardar(jugadorInicio,pisoScript);
            StartCoroutine(mostrarDialogo("¡Has perdido!"));
            yield return new WaitForSeconds(1f);
            avancePisoScript.menuRe();
            
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

    private void cargarJugador(){
        DatosJugador data = SistemaGuardado.cargar();

        if (data != null)
        {
            jugadorGest.saludActual = data.saludActual;
            jugadorGest.saludMax = data.saludMax;
            jugadorGest.escudo = data.escudo;
            jugadorGest.magia = data.magia;
            jugadorGest.fuerza = data.fuerza;
        }
        StartCoroutine(jugadorGest.actualizarUI());
        
    }

}
