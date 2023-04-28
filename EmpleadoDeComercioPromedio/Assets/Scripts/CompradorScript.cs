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
    
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(-29.5699997f, -0.629999995f,-1.22000003f);
        elPedido = new Pedido(1, 2, "Necesito un firulete para sostener la repisa contra la pared. Me pregunto si en el bazar de enfrente venden repisas...");
        
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        transform.LookAt(currentWaypoint);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Avanzar();
        
    }

    /*public void SetWaypoints(WayPoints wp)
    {
        waypoints = wp;
    }*/

    public void Avanzar()
    {
            Debug.Log("AVANZAR");
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            //Debug.Log(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold);
            if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                Debug.Log("AVANZAR IF IN");
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
                
            }
        
            /*if(waypoints.IsLastWaypoint()){
                //GetComponent<AudioSource>().Stop();
                //estaCaminando = false;

                transform.LookAt(puntoDeMira);
            }*/
    }

    public Pedido GetPedido()
    {
        return elPedido;
    }
    
    public void MostrarSolicitud()
    {
        Debug.Log(elPedido.solicitud);
    }

}
