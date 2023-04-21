using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstanteriaScript : MonoBehaviour
{
    public  GameObject otherObject;
    public WayPoints waypointsToThis;
    private WaypointMover waypointMover;
    

    // Start is called before the first frame update
    void Start()
    {
        waypointMover = otherObject.GetComponent<WaypointMover>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        otherObject.GetComponent<WaypointMover>().waypoints = waypointsToThis;
        waypointMover.enabled = true;
        //Debug.Log("CLIC");
    }
}
