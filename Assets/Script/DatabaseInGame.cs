using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Firebase.Database;

//Clase que controla los usos de la base de datos dentro del combate
public class DatabaseInGame : MonoBehaviour
{
    private string usuarioID; //ID de usuario generada en base al dispotivo actual
    private DatabaseReference dbReference; //Referencia a la base de datos Realtime de Firebase

    // Start is called before the first frame update
    void Start()
    {
        usuarioID = SystemInfo.deviceUniqueIdentifier;
    }

    //Guarda el piso actual en la base de datos si se supera el record anterior del jugador
    public void GuardarPiso(int piso){
        dbReference = FirebaseDatabase.DefaultInstance.RootReference; //Obtiene la referencia la base de datos
        Usuario nuevoUsuario = new Usuario("Afana"+ usuarioID.Substring(usuarioID.Length - 4), piso);
        string json = JsonUtility.ToJson(nuevoUsuario);
        dbReference.Child("usuarios").Child(usuarioID).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot sn = task.Result;
                if(int.Parse(sn.Child("piso").Value.ToString()) < piso){
                    dbReference.Child("usuarios").Child(usuarioID).SetRawJsonValueAsync(json);
                }
            }
        });
    }
}
