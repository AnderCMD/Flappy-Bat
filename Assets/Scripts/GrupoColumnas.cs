using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrupoColumnas : MonoBehaviour
{
    //Fisicas
    public GameObject ColumnaPrefabricada;
    private Vector2 ObjetoGrupoPosicion = new Vector2(-14, 0);

    //Variables Globales
    public int TamañoGrupoColumnas = 5;
    private int ColumnaActual;
    private int Dificultad;

    private float TiempoUltimaGeneracion;
    private float TasaGeneracion;
    private float ColumnaMin = -1.1f;
    private float ColumnaMax = 4.1f; 
    private float SpawnXPosicion = 10f;

    //Arreglos Globales
    private GameObject[] Columnas;

    // Se llama a Start antes de la actualización del primer cuadro
    void Start()
    {
        Columnas = new GameObject[TamañoGrupoColumnas];

        for(int i = 0; i < TamañoGrupoColumnas; i++)
        {
            Columnas[i] = Instantiate(ColumnaPrefabricada, ObjetoGrupoPosicion, Quaternion.identity);
        }
    }

    // La actualización se llama una vez por cuadro
    void Update()
    {
        //Niveles de dificultad & medallas
        if (Dificultad >= 0) //Puntuaje
        {
            TasaGeneracion = 3f;
        }
        if (Dificultad >= 20) //Puntuaje
        {
            TasaGeneracion = 2.8f;
        }
        if (Dificultad >= 40) //Puntuaje
        {
            TasaGeneracion = 2.6f;
        }
        if (Dificultad >= 60) //Puntuaje
        {
            TasaGeneracion = 2.4f;
        }
        if (Dificultad >= 80) //Puntuaje
        {
            TasaGeneracion = 2.2f;
        }
        if (Dificultad >= 100) //Puntuaje
        {
            TasaGeneracion = 2f;
        }

        TiempoUltimaGeneracion += Time.deltaTime;
        if(!GameController.instance.GameOver && TiempoUltimaGeneracion >= TasaGeneracion)
        {
            TiempoUltimaGeneracion = 0;
            float SpawnYPosicion = Random.Range(ColumnaMin, ColumnaMax);
            Columnas[ColumnaActual].transform.position = new Vector2(SpawnXPosicion, SpawnYPosicion);
            ColumnaActual++;
            Dificultad++;
            if (ColumnaActual >= TamañoGrupoColumnas)
            {
                ColumnaActual = 0;
            }
        }
    }
}
