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
    GestionPersonajeScript enemigoGest;

    public GameObject dialogo;
    public Text dialogoTXT;

    public BattleState state;
    
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject jugadorGO = Instantiate(jugadorPrefab, posJugador.position,Quaternion.identity);
        jugadorGest = jugadorGO.GetComponent<GestionPersonajeScript>();
        int enemigospawn = Random.Range(0, enemigoPrefab.Length);
        GameObject enemigoGO = Instantiate(enemigoPrefab[enemigospawn], posEnemigo.position, enemigoPrefab[enemigospawn].GetComponent<Transform>().rotation);
        enemigoGest = jugadorGO.GetComponent<GestionPersonajeScript>();

        dialogo.SetActive(true);

        dialogoTXT.text = "Comienza el combate";

        yield return new WaitForSeconds(2f);

        dialogo.SetActive(false);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

        
    }

    void PlayerTurn()
        {
            dialogoTXT.text = "Tu turno";

        }

}
