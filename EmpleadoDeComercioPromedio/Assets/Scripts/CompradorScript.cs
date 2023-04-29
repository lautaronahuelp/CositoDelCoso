using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] public WayPoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    //public Transform puntoDeMira;
    private Transform currentWaypoint;
    public string nombre;
    private bool entrego = false;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        
        
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        transform.LookAt(currentWaypoint);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Avanzar();
        
    }

    public void Avanzar()
    {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            
            if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
        
            /*if(waypoints.IsLastWaypoint()){
                //GetComponent<AudioSource>().Stop();
                //estaCaminando = false;

                transform.LookAt(puntoDeMira);
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
        Debug.Log(nombre + ": " + elPedido.solicitud);
    }

    public void Irse()
    {
        Destroy(gameObject);
        Debug.Log("AH RE QUE SE IBA");
        
    }

}
