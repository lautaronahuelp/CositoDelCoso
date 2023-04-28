using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaScript : MonoBehaviour
{
    public GameObject unComprador, newComprador;
    public WayPoints[] waypointsCompradores;

    // Start is called before the first frame update
    void Start()
    {
        newComprador = Instantiate(unComprador, transform);
        newComprador.GetComponent<CompradorScript>().waypoints = waypointsCompradores[0];
        //Debug.Log(waypointsCompradores.transform.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
