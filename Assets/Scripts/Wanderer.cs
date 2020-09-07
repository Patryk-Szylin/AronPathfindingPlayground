using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    public Transform Waypoint1;
    public Transform Waypoint2;

    public Transform LastVisitedWaypoint;
    public Transform NextWaypoint;

    public float speed = 2f;


    private void Start()
    {
        NextWaypoint = Waypoint1;
        LastVisitedWaypoint = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var dist = (NextWaypoint.position - transform.position).magnitude;

        if (dist <= 1f)
            SetNextWaypoint();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetNextWaypoint();
        }

        this.transform.position = Vector3.MoveTowards(transform.position, NextWaypoint.position, speed * Time.deltaTime);


    }

    private void SetNextWaypoint()
    {
        if (LastVisitedWaypoint.position == Waypoint1.position)
        {
            NextWaypoint = Waypoint2;
        }

        if (LastVisitedWaypoint.position == Waypoint2.position)
        {
            NextWaypoint = Waypoint1;
        }
    }
}
