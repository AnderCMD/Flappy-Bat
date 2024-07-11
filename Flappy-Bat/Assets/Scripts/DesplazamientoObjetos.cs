using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoObjetos : MonoBehaviour
{
    //Fisicas
    private Rigidbody2D rigidbody2D;

    //Variables Globales

    // Se llama a Start antes de la actualización del primer cuadro
    void Start()
    {
        rigidbody2D.velocity = new Vector2(GameController.instance.VelocidadObjetos, 0);
    }

    // La actualización se llama una vez por cuadro
    void Update()
    {
        if (GameController.instance.GameOver)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
