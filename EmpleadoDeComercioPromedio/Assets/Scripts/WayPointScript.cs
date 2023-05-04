using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointScript : MonoBehaviour
{
    private bool ocupado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ocupar()
    {
        ocupado = true;
        Debug.Log(transform.name+"|ocupado");
    }

    public void Abandonar()
    {
        ocupado = false;
        Debug.Log(transform.name+"|desocupado");
    }

    public bool EstaLibre()
    {
        return !ocupado;
    }
}
