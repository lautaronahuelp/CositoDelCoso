using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaScript : MonoBehaviour
{
    public GameObject unComprador;
    private GameObject newComprador;
    public WayPoints[] waypointsCompradores;
    public GameObject[] listaDePedidos;
    public Transform player;
    public Transform cuadroDialogo;
    public float tiempoSpawneo;
    public int largoFila;
    private float tiempoRestante;

    private int randomNumber;
    public int maxAttempts;

    public string[] nombres;
    public string[] texto1;
    public string[] texto2;
    public string[] texto3;
    public int[] item1;
    public int[] item2;
    private int[] conteo = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};


    
    // Start is called before the first frame update
    void Start()
    {
        
        tiempoRestante = tiempoSpawneo;

        for(int i = 0;  i < largoFila; i++)
        {
            conteo[i] = 0;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if(!PasaronTodos())
        {

            if(tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
            }
            else
            {
                tiempoRestante = tiempoSpawneo;
                if(transform.childCount < largoFila)
                {
                    //Debug.Log("PASA A SPAWNEAR");
                    
                    SpawneaComprador();
                }

            }
        }
        else
        {
            if(transform.childCount == 0) {
                player.GetComponent<PlayerScript>().FinalDelJuego();
            }
        }
    }

    private void SpawneaComprador()
    {
        int ordenDeComprador;
    
      
        //ordenDeComprador = Random.Range(1, largoFila);
        ordenDeComprador = Random.Range(0, largoFila);
      
        for(int i=0; HayConteosMenores(ordenDeComprador) && i < maxAttempts && ExisteEnFila(nombres[ordenDeComprador]); i++)
        {
         
            ordenDeComprador = Random.Range(0, largoFila);
             
        }
        /*
        do
        {
             ordenDeComprador = Random.Range(0, largoFila);
        }
        while(HayConteosMenores(ordenDeComprador) && ExisteEnFila(nombres[ordenDeComprador]))
        */

        //Debug.Log(">>"/*+ HayConteosMenores(ordenDeComprador)+ */+"orden: "+ordenDeComprador);

        /*while(HayConteosMenores(ordenDeComprador)){
            ordenDeComprador = Random.Range(0, (largoFila - 1));
        }
        /*do
        {
            ordenDeComprador = Random.Range(0, (largoFila - 1));
            Debug.Log("ITERA:"+ordenDeComprador);
        } 
        while(HayConteosMenores(ordenDeComprador));*/
        
    
        //SetComprador(int i1, int i2, string tx, string nm)
        if(!ExisteEnFila(nombres[ordenDeComprador]) /*&& transform.childCount < 1*/)
        {
            newComprador = Instantiate(unComprador, transform);
            newComprador.GetComponent<CompradorScript>().SetComprador(item1[ordenDeComprador],item2[ordenDeComprador], EligeTexto(ordenDeComprador, conteo[ordenDeComprador]), nombres[ordenDeComprador]);
            newComprador.GetComponent<CompradorScript>().waypointsEntrada = waypointsCompradores[0];
            newComprador.GetComponent<CompradorScript>().cuadroDialogo = cuadroDialogo;
            conteo[ordenDeComprador]++;
        }
        
        Debug.Log("conteos:"+conteo[0]+ "|"+conteo[1]+ "|"+conteo[2]+ "|"+conteo[3]+ "|"+conteo[4]+ "|"+conteo[5]);
        
    }

    private bool HayConteosMenores(int ord)
    {
        //Debug.Log(">>ENTRACONTEOSMENORES");
        bool band = false;
        for(int i = 0; i < largoFila; i++)
        {
            //Debug.Log(">>i: "+i);
            if(i != ord)
            {
                if(conteo[i] < conteo[ord]) band = true;
            }
        }

        return band;
    }

    private bool ExisteEnFila(string nm)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<CompradorScript>().GetNombre() == nm) return true;
        }
        return false;
    }
    private bool PasaronTodos()
    {
        for(int i = 0; i < largoFila; i++)
        {
                if(conteo[i] < 3) return false;
        }
        return true;
    }

    private string EligeTexto(int odc, int cnt)
    {
        switch(cnt)
        {
            case 0:
                return texto1[odc];
            case 1:
                return texto2[odc];
            case 2:
                return texto3[odc];
            default:
                return texto1[odc];
        }
    }
    
    public void SeVaUno(){
        
        Debug.Log("spawneados:"+transform.childCount);
    }
}
