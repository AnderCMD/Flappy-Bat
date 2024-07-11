using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFondo : MonoBehaviour
{
    //Fisicas
    private BoxCollider2D boxCollider2D;

    //Variables Globales
    private float LargoHorizontal;

    // Se llama a Start antes de la actualización del primer cuadro
    void Start()
    {
        LargoHorizontal = boxCollider2D.size.x;
    }

    // La actualización se llama una vez por cuadro
    void Update()
    {
        if(transform.position.x < -LargoHorizontal)
        {
            ReposicionarFondo();
        }
    }

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void ReposicionarFondo()
    {
        transform.Translate(Vector2.right * LargoHorizontal * 2);
    }
}
