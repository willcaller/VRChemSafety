using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float moveSpeed = 5f; // Speed at which the object moves
    public float idleTime = 5f; // Time to idle at each waypoint
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isIdling = false; // Flag to track if the object is idling
    private float idleTimer = 0f; // Timer for idling

    private NavMeshAgent agent;
    private Animator anim;
    private SliderController sliderController; // Reference to the slider controller

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sliderController = GetComponent<SliderController>(); // Get the slider controller component
        sliderController.npcTransform = transform; // Set the transform of the NPC in the slider controller

        // Check if there are waypoints assigned
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned.");
            return;
        }

        SetDestinationToWaypoint(currentWaypointIndex);
    }

    void Update()
    {
        if (isIdling)
        {
            idleTimer += Time.deltaTime;
            sliderController.UpdateProgress(); // Update the progress on the slider when idling
            if (idleTimer >= idleTime)
            {
                isIdling = false;
                idleTimer = 0f;
                anim.SetTrigger("isWalking");
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
                SetDestinationToWaypoint(currentWaypointIndex);
            }
        }
        else if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isIdling = true;
            anim.SetTrigger("isIdle");
        }
    }

    void SetDestinationToWaypoint(int index)
    {
        agent.SetDestination(waypoints[index].position);
        isIdling = false;
        sliderController.ResetProgress(); // Reset the progress on the slider when moving to a new waypoint
        anim.SetTrigger("isWalking");
    }
}