using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private WayPoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    public Transform puntoDeMira;

    private Transform currentWaypoint;
    private bool estaCaminando = false;
    // Start is called before the first frame update
    void Start()
    {
        //currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        //transform.position = currentWaypoint.position;

        //currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        //transform.LookAt(currentWaypoint);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(estaCaminando)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
                
            }
        
            if(waypoints.IsLastWaypoint()){
                GetComponent<AudioSource>().Stop();
                estaCaminando = false;

                transform.LookAt(puntoDeMira);
            }
        }
        
    }

    public void Camina(WayPoints wp){
        if(!estaCaminando){
            GetComponent<AudioSource>().Play();
            
            waypoints = wp;
            currentWaypoint = waypoints.GetNextWaypoint(null);
            transform.LookAt(currentWaypoint);

            estaCaminando = true;
        }

    }
}

