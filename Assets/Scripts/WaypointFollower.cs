using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GameObject targetWaypoint = waypoints[currentWaypointIndex];
        if (Vector3.Distance(transform.position, targetWaypoint.transform.position) < 0.1f)
        {
            // if touching waypoint, increment way point indexing, wrapping around if reached end 
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {

                currentWaypointIndex = 0;
            }
        }

        // time.deltatime is to handle different framerates
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.transform.position, speed * Time.deltaTime);
    }
}
