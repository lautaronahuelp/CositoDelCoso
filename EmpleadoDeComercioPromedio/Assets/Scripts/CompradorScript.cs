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
    private Transform currentWaypoint;
    public string nombre;
    private bool entrego = false;

    public Transform cuadroDialogo;
    private TMP_Text textoDialogo;

    private int pasitos = 0;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        
        textoDialogo = cuadroDialogo.GetComponent<TMP_Text>();
        currentWaypoint = waypointsEntrada.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        transform.LookAt(currentWaypoint);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(pasitos < 2)
        {
            Avanzar();
            
        }
    }

    public void Avanzar()
    {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            
            if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypointsEntrada.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
                pasitos++;
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
        entrego = true;
        return elPedido;
    }

    public bool Entrego()
    {
        return entrego;
    }

    public string GetNombre()
    {
        return nombre;
    }
    
    public void MostrarSolicitud()
    {
        textoDialogo.text = nombre + ": " + elPedido.solicitud;
    }

    public void Irse()
    {
        Destroy(gameObject);
        //Debug.Log("AH RE QUE DESAPARECIA");
        
    }

}
