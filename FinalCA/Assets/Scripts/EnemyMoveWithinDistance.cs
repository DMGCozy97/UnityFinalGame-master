using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveWithinDistance : NavMeshMover
{
    public string tagToTrack = "Player";
    GameObject trackedPlayer;
    public float trackingDistance = 2f;

    public override void Start()
    {
        trackedPlayer = GameObject.FindGameObjectWithTag(tagToTrack);

        base.Start();

    }

    public override void Update()
    {
        base.Update();
        if (trackedPlayer != null)
        {
            if (Vector3.Distance(transform.position, trackedPlayer.transform.position) <= trackingDistance)
            {
                Resume();
                agent.SetDestination(trackedPlayer.transform.position);
            }
            else
            {
                MoveTo(transform.position);
                Stop();
            }
            //MoveTo(trackedPlayer);            
            //Debug.Log("EnemyMoveDirectly- Update: IN If");
        }
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = DebugLineColor;
        Gizmos.DrawWireSphere(transform.position, trackingDistance);

        base.OnDrawGizmos();
    }
}
