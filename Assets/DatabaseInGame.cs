using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Firebase.Database;

public class DatabaseInGame : MonoBehaviour
{

    private string usuarioID;
    private DatabaseReference dbReference;

    // Start is called before the first frame update
    void Start()
    {
        usuarioID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void GuardarPiso(int piso){
        Usuario nuevoUsuario = new Usuario("Afana", piso);
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

    private bool comprobarMax(int p){
        bool superado = false;
        /*
        var n = dbReference.Child("usuarios").EqualTo(usuarioID).GetValueAsync();
        yield return new WaitUntil(predicate: () => n.IsCompleted);
        
        if (n != null)
        {
            Debug.Log(usuarioID);
            DataSnapshot snapshot = n.Result;
            foreach (var item in snapshot.Children.Reverse<DataSnapshot>())
            {
                Debug.Log(usuarioID);
                
                if(item.Child("piso").Value.ToString() == "5"){
                    Debug.Log(usuarioID);
                    Debug.Log(false);
                } 
                Debug.Log(item.Child("piso").Value);          
            } 
        }
        */

        dbReference.Child("usuarios").Child(usuarioID).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot sn = task.Result;
                Debug.Log("Piso base de datos "+sn.Child("piso").Value);
                Debug.Log("Piso en partida "+ p);
                
                if(int.Parse(sn.Child("piso").Value.ToString()) < p){
                    superado = true;
                    //Debug.Log(superado);
                }
            }
        });

        return superado;


        
    }
}
