using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMover : MonoBehaviour
{

    public List<Transform> Waypoints = new List<Transform>();
    public float MoveSpeed = 2.0f;
    private bool errorMessageShown;
    private int WaypointIndex = 0;
    public bool IgnoreWaypointHeight = true;
    private Transform TemporaryTarget;
    public int SlowDownOnApproachFactor = 3;
    public Transform NextTarget { get; private set; }

    public void AddTemporaryWaypoint(Transform temporaryTarget)
    {
        TemporaryTarget = temporaryTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (Waypoints == null || Waypoints.Count == 0)
        {
            if (!errorMessageShown)
                Debug.Log("No Waypoints set for " + this.name + ". So it will not move right now.");
            return;
        }
       
        if(WaypointIndex == Waypoints.Count)
        {
            //Debug.Log("Setting next waypoint to origin");
            WaypointIndex = 0;
        }

        //Override next target at end of sequence
        if (TemporaryTarget != null && WaypointIndex == 0)
        {
            NextTarget = TemporaryTarget;
        }
        else
        {
            NextTarget = Waypoints[WaypointIndex];
        }

        // Move our position a step closer to the target, go to 1/3 speed if 
        float step = (TemporaryTarget != null ? MoveSpeed / SlowDownOnApproachFactor : MoveSpeed) * Time.deltaTime; // calculate distance to move

        Vector3 NextPosition = new Vector3(NextTarget.position.x, IgnoreWaypointHeight ? transform.position.y : NextTarget.position.y, NextTarget.position.z);

        transform.position = Vector3.MoveTowards(transform.position, NextPosition, step);

        // Check if the position of the target and the subject are approximately equal.
        if (Vector3.Distance(transform.position, NextPosition) < 0.001f)
        {
            //Clear temporary target once reached
            if (WaypointIndex == 0)
                TemporaryTarget = null;

            WaypointIndex++;
            
            Debug.Log(System.String.Format("Waypoint reached by {0}, moving to next waypoint # {1}", this.gameObject.name, WaypointIndex));
        }
        else
            transform.LookAt(NextPosition);
    }
}
