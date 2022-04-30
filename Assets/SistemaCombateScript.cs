using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class SistemaCombateScript : MonoBehaviour
{
    public GameObject jugadorPrefab;
    public GameObject enemigoPrefab;

    public Transform posJugador;
    public Transform posEnemigo;
    public BattleState state;
    
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        Instantiate(jugadorPrefab, posJugador);
        Instantiate(enemigoPrefab, posEnemigo);
    }

}
