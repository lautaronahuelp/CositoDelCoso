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
    private AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        waypointMover = playerObject.GetComponent<WaypointMover>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        playerObject.GetComponent<WaypointMover>().Camina(waypointsToThis);
        //waypointMover.enabled = true;
        
    }

    void OnTriggerEnter(Collider player)
    {
        elItem = new Item(nombreItem, idItem);
        if(player.gameObject.GetComponentInParent<PlayerScript>().SetItem(elItem)) audioSource.Play();
    }
}
