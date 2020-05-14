using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void ReachedDestinationDelegate();

[RequireComponent(typeof(NavMeshAgent))]

public class NavMeshMover : MonoBehaviour
{
    protected NavMeshAgent agent;
    public event ReachedDestinationDelegate ReachedDestination;

    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }
    public virtual void MoveTo(GameObject position)
    {
        agent.SetDestination(gameObject.transform.position);
    }

    public virtual void Stop()
    {
        agent.isStopped = true;
    }

    public virtual void Resume()
    {
        if (agent.isStopped)
        {
            agent.isStopped = false;
        }
    }

    public float RangeThreshold = 0.1f;
    public void HasReachedDestination()
    {
        if (Vector3.Distance(transform.position, agent.destination) <= RangeThreshold)
        {
            if (ReachedDestination != null)
            {
                ReachedDestination();
            }
        }
    }

    public virtual void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete || agent.pathStatus == NavMeshPathStatus.PathPartial)
        {
            //Debug.Log("NavMeshMover: IN If");
            HasReachedDestination();
        }

    }

    public Color DebugLineColor = Color.red;

    public virtual void OnDrawGizmos()
    {
        if (agent != null)
        {
            if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                for (int i = 0; i < agent.path.corners.Length; i++)
                {
                    if (i + 1 < agent.path.corners.Length)
                    {
                        Gizmos.color = DebugLineColor;
                        Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
                    }
                }
            }
        }
    }
}