using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DatabaseManagerScript : MonoBehaviour
{
    public TMP_InputField Nombre;
    public TMP_InputField Piso;

    private string usuarioID;
    private DatabaseReference dbReference;

    public TMP_Text[] tablaNombre_array;
    public TMP_Text[] tablaPiso_array;

    // Start is called before the first frame update
    void Start()
    {
        usuarioID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine("GetBoard");
        
    }

    public void CrearUsuario(){
        Usuario nuevoUsuario = new Usuario(Nombre.text, int.Parse(Piso.text));
        string json = JsonUtility.ToJson(nuevoUsuario);

        /*
        Usuario nuevoUsuario2 = new Usuario("Cacatua Rapera", 12345);
        string json2 = JsonUtility.ToJson(nuevoUsuario2);
        dbReference.Child("usuarios").Child("t").SetRawJsonValueAsync(json2);
        */

        dbReference.Child("usuarios").Child(usuarioID).SetRawJsonValueAsync(json);
        //no admite caracteres que no sean letras o números
        //dbReference.Child("usuarios").Child("deferre").SetRawJsonValueAsync(json);
        StartCoroutine("GetBoard");

    }

    public void GuardarPiso(int piso){
        Usuario nuevoUsuario = new Usuario("Afana", piso);
        string json = JsonUtility.ToJson(nuevoUsuario);
        dbReference.Child("usuarios").Child(usuarioID).SetRawJsonValueAsync(json);
        StartCoroutine(comprobarMax(piso));
    }

    private IEnumerator comprobarMax(int p){
        var n = dbReference.Child("usuarios").Child("usuarioID").GetValueAsync();
        yield return new WaitUntil(predicate: () => n.IsCompleted);
        if (n != null)
        {
            DataSnapshot snapshot = n.Result;
            foreach (var item in snapshot.Children.Reverse<DataSnapshot>())
            {
                if((int)item.Child("piso").Value > p){
                    Debug.Log(false);
                }                
            } 
        }
    }

    public IEnumerator GetBoard(){
        var n = dbReference.Child("usuarios").OrderByChild("piso").GetValueAsync();

        yield return new WaitUntil(predicate: () => n.IsCompleted);
        if (n != null)
        {
            DataSnapshot snapshot = n.Result;
            int i = 0;
            foreach (var item in snapshot.Children.Reverse<DataSnapshot>().Take(5))
            {
                tablaNombre_array[i].text = item.Child("nombre").Value.ToString();
                tablaPiso_array[i].text = item.Child("piso").Value.ToString();
                // Debug.Log("Nombre"+item.Child("nombre").Value);
                // Debug.Log("Piso"+item.Child("piso").Value);
                i++;
            }
            
        }
        

    }

    public void cargarDatos(){
        StartCoroutine("GetBoard");
    }

}
