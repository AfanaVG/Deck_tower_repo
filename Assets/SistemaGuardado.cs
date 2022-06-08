using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SistemaGuardado
{
    public static void Guardar(GestionPersonajeScript jugador, pisoScript piso){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/jugador.afana";
        FileStream stream = new FileStream(path, FileMode.Create);

        DatosJugador data = new DatosJugador(jugador,piso);

        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static DatosJugador cargar(){

        string path = Application.persistentDataPath + "/jugador.afana";
        if (File.Exists(path))
        {   
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DatosJugador data = formatter.Deserialize(stream) as DatosJugador;
            stream.Close();

            return data;
        }else{
            Debug.LogError("Archivo de guardado no encontrado"+path);
            return null;
        }


    }

    

}
