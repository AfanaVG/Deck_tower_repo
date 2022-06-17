using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destruira la particula tras esperar el tiempo establecido
public class DestroyParticle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject.transform.parent.gameObject,0.5f);
    }
}
