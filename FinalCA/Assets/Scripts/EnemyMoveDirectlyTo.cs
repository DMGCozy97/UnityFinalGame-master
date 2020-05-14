using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveDirectlyTo : NavMeshMover
{
    public string tagToTrack = "Player";
    GameObject trackedPlayer;

    public override void Start()
    {
        trackedPlayer = GameObject.FindGameObjectWithTag(tagToTrack);

        base.Start();
        //if (trackedPlayer != null)
        //{
        //    Debug.Log("EnemyMoveDirectly- start: IN If");
        //    MoveTo(trackedPlayer);
        //}
    }

    public override void Update()
    {
        base.Update();
        if (trackedPlayer != null)
        {
            //MoveTo(trackedPlayer);
            agent.SetDestination(trackedPlayer.transform.position);
            //Debug.Log("EnemyMoveDirectly- Update: IN If");
        }

    }
}
