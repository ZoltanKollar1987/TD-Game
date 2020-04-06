using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = WayPoint.WayPoints[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);

        if (Vector3.Distance(transform.position,target.position) <=0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {

        if (wavepointIndex >= WayPoint.WayPoints.Length - 1)
        {           
            return;
        }
        wavepointIndex++;
        target = WayPoint.WayPoints[wavepointIndex];
    }
}
