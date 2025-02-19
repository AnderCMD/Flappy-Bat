using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoObjetos : MonoBehaviour
{
    //Fisicas
    private Rigidbody2D rigidbody2D;

    //Variables Globales

    // Se llama a Start antes de la actualizaci�n del primer cuadro
    void Start()
    {
        rigidbody2D.linearVelocity = new Vector2(GameController.instance.VelocidadObjetos, 0);
    }

    // La actualizaci�n se llama una vez por cuadro
    void Update()
    {
        if (GameController.instance.GameOver)
        {
            rigidbody2D.linearVelocity = Vector2.zero;
        }
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
