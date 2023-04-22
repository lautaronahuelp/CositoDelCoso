using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;

    Transform currentWaypointGlobal;

    private void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }

        Gizmos.color = Color.red;
        for( int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild( i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
    }

    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if(currentWaypoint == null){
            return transform.GetChild(0);
        }
        
        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            currentWaypointGlobal = currentWaypoint;
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
            
        }
        else
        {
            currentWaypointGlobal = currentWaypoint;
            return transform.GetChild(0);
            
        }
    }

    public bool IsLastWaypoint(){
        //Debug.Log(currentWaypointGlobal);
        if(currentWaypointGlobal.GetSiblingIndex() == transform.childCount - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

