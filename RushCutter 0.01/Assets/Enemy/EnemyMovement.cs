using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float waitTime = 1f;
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    void Update()
    {
        
    }
    IEnumerator FollowPath()
    {
        foreach (WayPoint waypoints in path)
        {
            Debug.Log(waypoints.name);
            transform.position = new Vector3(waypoints.transform.position.x, transform.position.y, waypoints.transform.position.z);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
