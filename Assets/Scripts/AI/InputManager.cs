using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    internal enum driver
    {
        AI,
        keyboard

    }

    [SerializeField] driver DriveController;

    public Transform currentWaypoint;
    public trackWaypoint waypoints;
    public List<Transform> nodes = new List<Transform>();
    [Range(0, 10)] public int distanceOffset;
    [Range(0, 5)] public float steerForce;

    private void Awake()
    {
        
        waypoints = GameObject.FindGameObjectWithTag("path").GetComponent<trackWaypoint>();


        nodes = waypoints.nodes;

    }

    [HideInInspector] public float vertical;
    [HideInInspector] public float horizontal;

    private void FixedUpdate()
    {
        switch (DriveController)
        {
            case driver.AI:AIDrive();
                break;
            case driver.keyboard:
                break;
        }
    }
    private void AIDrive()
    {
        vertical = .3f;
        AISteer();
    }
    private void calculateDistanceOfWaypoints() {

        Vector3 position = gameObject.transform.position;
        float distance = Mathf.Infinity;


        for(int i=0; i < nodes.Count; i++)
        {
            Vector3 difference = nodes[i].transform.position - position;
            float currentDistance = difference.magnitude;
            if(currentDistance < distance)
            {
                currentWaypoint = nodes[i + distanceOffset];
                distance = currentDistance;

            }

        }
    
    }

    public void AISteer()
    {
        
       Vector3 relative = transform.InverseTransformPoint(currentWaypoint.transform.position);
        relative /= relative.magnitude;

        horizontal=(relative.x / relative.magnitude)* steerForce;


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(currentWaypoint.position, 3);
    }

}
