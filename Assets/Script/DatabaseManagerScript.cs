using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;
using System.Linq;

//Clase que controla los usos de la base de datos en el menude clasificaciones
public class DatabaseManagerScript : MonoBehaviour
{
    public TMP_InputField Nombre; //Variable para debug
    public TMP_InputField Piso; //Variable para debug

    private string usuarioID; //ID de usuario generada en base al dispotivo actual
    private DatabaseReference dbReference; //Referencia a la base de datos Realtime de Firebase

    public TMP_Text[] tablaNombre_array; //Array con los contenedores del nombre de los jugadores
    public TMP_Text[] tablaPiso_array; //Array con los contenedores del piso de los jugadores

    // Start is called before the first frame update
    void Start()
    {
        usuarioID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine("GetBoard");
        
    }

    //Metodo para debug
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
                i++;
            }
        }
    }

    public void cargarDatos(){
        StartCoroutine("GetBoard");
    }

}
