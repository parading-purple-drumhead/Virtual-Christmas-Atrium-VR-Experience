using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Range(0f,2f)]
    [SerializeField] private float waypointSize = 1f;
    private void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position,waypointSize);
        }
        Gizmos.color = Color.red;
        for(int i = 0; i<transform.childCount-1;i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position,transform.GetChild(i+1).position);
        }
        Gizmos.DrawLine(transform.GetChild(transform.childCount-1).position,transform.GetChild(0).position);
    }
    public Transform GetNextWaypoint(Transform current)
    {
        if(current == null)
        {
            return transform.GetChild(0);
        }
        if(current.GetSiblingIndex()<transform.childCount-1)
        {
            return transform.GetChild(current.GetSiblingIndex()+1);
        }
        else
        {
            return transform.GetChild(0);
        }
    }
}
