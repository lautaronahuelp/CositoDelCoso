using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstanteriaScript : MonoBehaviour
{
    public GameObject playerObject;
    public WayPoints waypointsToThis;
    public string nombreItem;
    public int idItem;
    private WaypointMover waypointMover;
    private Item elItem;
    

    // Start is called before the first frame update
    void Start()
    {
        waypointMover = playerObject.GetComponent<WaypointMover>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        playerObject.GetComponent<WaypointMover>().waypoints = waypointsToThis;
        waypointMover.enabled = true;
        //elItem = new Item(nombreItem, idItem);
        //playerObject.GetComponent<PlayerScript>().SetItem(elItem);
        //Debug.Log("CLIC");
    }

    void OnTriggerEnter(Collider player)
    {
        elItem = new Item(nombreItem, idItem);
        player.gameObject.GetComponentInParent<PlayerScript>().SetItem(elItem);
        //Debug.Log("COLLISION");
    }
}
