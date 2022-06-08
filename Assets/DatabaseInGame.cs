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
        //dbReference.Child("usuarios").Child(usuarioID).SetRawJsonValueAsync(json);
        StartCoroutine(comprobarMax(piso));
    }

    private IEnumerator comprobarMax(int p){
        
        var n = dbReference.Child("usuarios").Child(usuarioID).Child("piso").GetValueAsync();
        yield return new WaitUntil(predicate: () => n.IsCompleted);
        
        if (n != null)
        {
            Debug.Log(usuarioID);
            DataSnapshot snapshot = n.Result;
            foreach (var item in snapshot.Children.Reverse<DataSnapshot>())
            {
                if(item.Child("piso").Value.ToString() == "5"){
                    Debug.Log(false);
                }                
            } 
        }
    }
}
