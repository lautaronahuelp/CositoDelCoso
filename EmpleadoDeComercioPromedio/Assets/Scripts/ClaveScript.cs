using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaveScript : MonoBehaviour
{
    private int contrasenia = 0, tecleos = 0;
    public GameObject pantallaAjustes;
    public Transform elCanvas;
    public Transform player;
    public Transform fila;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(EstadoDelJuego.habilitaJuego) LeePalabraClave();
    }

    private void LeePalabraClave()
    {
        if(Input.anyKeyDown) tecleos++;
        if(Input.GetKeyDown(KeyCode.A) && contrasenia == 0) contrasenia++;
        if(Input.GetKeyDown(KeyCode.J) && contrasenia == 1) contrasenia++;
        if(Input.GetKeyDown(KeyCode.U) && contrasenia == 2) contrasenia++;
        if(Input.GetKeyDown(KeyCode.S) && contrasenia == 3) contrasenia++;
        if(Input.GetKeyDown(KeyCode.T) && contrasenia == 4) contrasenia++;
        if(Input.GetKeyDown(KeyCode.E) && contrasenia == 5) contrasenia++;
        if(Input.GetKeyDown(KeyCode.S) && contrasenia == 6) contrasenia++;

        if(tecleos != contrasenia)
        {
            contrasenia = 0;
            tecleos = 0;
        }

        if(contrasenia == 7) 
        {
            contrasenia = 0;
            AbreAjustes();
        }
    }

    private void AbreAjustes()
    {
        EstadoDelJuego.habilitaJuego = false;
        GameObject newPantalla = Instantiate(pantallaAjustes, elCanvas);
        newPantalla.GetComponent<AjustesScript>().elPlayer = player;
        newPantalla.GetComponent<AjustesScript>().laFila = fila;
    }
}
