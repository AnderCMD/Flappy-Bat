using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Fisicas
    public Renderer Fondo;

    //Variables Globales

    // Se llama a Start antes de la actualización del primer cuadro
    void Start()
    {
        
    }

    // La actualización se llama una vez por cuadro
    void Update()
    {
        //Movimiento fondo
        Fondo.material.mainTextureOffset = Fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;
    }
}
