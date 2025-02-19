using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //Fisicas
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public GameController gameController;
    public GameObject SonidoVuelo;
    public GameObject SonidoMuerte;

    //Variables Globales
    private bool EstaMuerto;
    
    public float FuerzaSalto = 200f;

    // Se llama a Start antes de la actualizaci�n del primer cuadro
    void Start()
    {
       
    }

    // La actualizaci�n se llama una vez por cuadro
    void Update()
    {
        if (EstaMuerto) return; //Si no esta muerto cumplir funciones

        if(Input.GetMouseButtonDown(0)) //Volar con boton Click Izquierdo
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            rigidbody2D.AddForce(Vector2.up * FuerzaSalto);
            animator.SetTrigger("Volar");
            Instantiate(SonidoVuelo);
        }
    }

    //Verificar las Fisicas
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Detecta que el personaje choca con el suelo, muere y genera el GameOver
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EstaMuerto = true;
        animator.SetTrigger("Muerte");
        Instantiate(SonidoMuerte);
        GameController.instance.MurcielagoMuerto();
        rigidbody2D.linearVelocity = Vector2.zero;
    }
}
