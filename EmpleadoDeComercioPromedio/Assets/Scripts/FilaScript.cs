using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaScript : MonoBehaviour
{
    public GameObject unComprador;
    private GameObject newComprador;
    public WayPoints[] waypointsCompradores;
    public GameObject[] listaDePedidos;
    public float tiempoSpawneo;
    public int largoFila;
    private float tiempoRestante;

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
        if(tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
        }
        else
        {
            tiempoRestante = tiempoSpawneo;
            if(transform.childCount < largoFila - 1)//ESTE -1 EVITA QUE SE TILDE. NO TENGO EXPLICACION, PERO FUNCIONA. ALGUN DIA SABRE QUE PASO.
            {
                Debug.Log("PASA A SPAWNEAR");
                SpawneaComprador();
            }
        }
    }

    private void SpawneaComprador()
    {
        int ordenDeComprador;
        Debug.Log("ENTRO A SPAWNEAR");
        do
        {
            ordenDeComprador = Random.Range(0, (largoFila - 1));
            Debug.Log("ITERA:"+ordenDeComprador);
        } 
        while(HayConteosMenores(conteo[ordenDeComprador], ordenDeComprador));

        Debug.Log("PASA DO-WHILE");
        //SetComprador(int i1, int i2, string tx, string nm)

        newComprador = Instantiate(unComprador, transform);
        newComprador.GetComponent<CompradorScript>().SetComprador(item1[ordenDeComprador],item2[ordenDeComprador], EligeTexto(ordenDeComprador, conteo[ordenDeComprador]), nombres[ordenDeComprador]);
        newComprador.GetComponent<CompradorScript>().waypoints = waypointsCompradores[0];
        conteo[ordenDeComprador]++;
    }

    private bool HayConteosMenores(int cn, int ord)
    {
        for(int i = 0; i < largoFila; i++)
        {
            if(i == ord) continue;
            if(conteo[i] < cn) return true;
        }

        return false;
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
}
