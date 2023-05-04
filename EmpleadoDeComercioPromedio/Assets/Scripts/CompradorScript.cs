using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pedido {
    public int[] pedido = new int[2];
    public string solicitud;
    
    public Pedido(int it1, int it2, string solic){
        pedido[0] = it1;
        pedido[1] = it2;
        solicitud = solic;
    }

    
}

public class CompradorScript : MonoBehaviour
{
    private Pedido elPedido;

    [SerializeField] public WayPoints waypointsEntrada;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    public Transform puntoDeMira;
    private Transform currentWaypoint, waypointProvisorio;
    public string nombre;
    private bool entrego = false;
    private bool listoParaCompra = false;

    public Transform cuadroDialogo;
    private TMP_Text textoDialogo;

    //private int pasitos = 0;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        
        textoDialogo = cuadroDialogo.GetComponent<TMP_Text>();
        transform.position = waypointsEntrada.GetNextWaypoint(null).position;
        currentWaypoint = waypointsEntrada.GetFirstFreeWaypoint();
        currentWaypoint.GetComponent<WayPointScript>().Ocupar();
        transform.LookAt(currentWaypoint);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(pasitos < 2)
        //{
            Avanzar();
            //Debug.Log(currentWaypoint.name);
        //}

        

    }

    public void Avanzar()
    {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            //Debug.Log(nombre+":"+currentWaypoint.tag);
            if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                
                if(currentWaypoint.tag == "mostrador")
                {
                    listoParaCompra = true;
        
                }
                else  
                {
                    waypointProvisorio = waypointsEntrada.GetNextWaypoint(currentWaypoint);
                    if(waypointProvisorio.GetComponent<WayPointScript>().EstaLibre())
                    {
                        currentWaypoint.GetComponent<WayPointScript>().Abandonar();
                        currentWaypoint = waypointProvisorio;
                        currentWaypoint.GetComponent<WayPointScript>().Ocupar();
                        transform.LookAt(currentWaypoint);
                    }
                    
                }
                
                

                

                //pasitos++;
            }
        
            /*if(waypointsEntrada.IsLastWaypoint()){
                //GetComponent<AudioSource>().Stop();
                //estaCaminando = false;

                transform.LookAt(new Vector3(-12, -0, -0));
            }*/
    }

    public void SetComprador(int i1, int i2, string tx, string nm)
    {

        nombre = nm;

        elPedido = new Pedido(i1, i2, tx);
    }

    public Pedido GetPedido()
    {
        if(listoParaCompra)
        {
            entrego = true;
            return elPedido;
        }

        return null;

        
    }

    public bool Entrego()
    {
        return entrego;
    }

    public bool ListoParaCompra()
    {
        return listoParaCompra;
    }

    public string GetNombre()
    {
        return nombre;
    }
    
    public void MostrarSolicitud()
    {
        textoDialogo.text = nombre + ": " + elPedido.solicitud;
    }

    public void LimpiarSolicitud()
    {
        textoDialogo.text = "";
    }

    public void Irse()
    {
        LimpiarSolicitud();
        currentWaypoint.GetComponent<WayPointScript>().Abandonar();
        Destroy(gameObject);
        
        //Debug.Log("AH RE QUE DESAPARECIA");
        
    }

}
