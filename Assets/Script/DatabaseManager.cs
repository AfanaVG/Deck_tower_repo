using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;

public class DatabaseManager : MonoBehaviour
{
    public TMP_InputField Nombre;
    public TMP_InputField Piso;

    private string usuarioID;
    private DatabaseReference dbReference;

    // Start is called before the first frame update
    void Start()
    {
        usuarioID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CrearUsuario(){
        Usuario nuevoUsuario = new Usuario(Nombre.text, int.Parse(Piso.text));
        string json = JsonUtility.ToJson(nuevoUsuario);

        dbReference.Child("usuarios").Child(usuarioID).SetRawJsonValueAsync(json);
        //no admite caracteres que no sean letras o números
        dbReference.Child("usuarios").Child("deferre").SetRawJsonValueAsync(json);
    }

}
