using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nueva carta",menuName ="Carta")]
public class Carta : ScriptableObject
{
    public int id;
    public int poder;
    public string nombre;
    public string descripcion;
    public Sprite img;


}
