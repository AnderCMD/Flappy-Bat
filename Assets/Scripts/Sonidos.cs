using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public float TiempoVuelo;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TiempoVuelo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {

    }
}
