using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columnas : MonoBehaviour
{
    //Fisicas

    //Variables Globales

    // Se llama a Start antes de la actualización del primer cuadro
    void Start()
    {
        
    }

    // La actualización se llama una vez por cuadro
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.instance.MurcielagoScore();
        }
    }
}
