using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    Enemy enemy;
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
        
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();     
    }

    void FindPath()
    {
        path.Clear();

        GameObject parentObj = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform childObj in parentObj.transform)
        {
            WayPoint waypoint = childObj.GetComponent<WayPoint>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }
    IEnumerator FollowPath()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        FinishPath();
    }

    private void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
}
