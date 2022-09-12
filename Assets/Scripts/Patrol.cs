using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [SerializeField] private List<Transform> patrolPoints;

    [SerializeField] private float moveSpeed;

    private void Start()
    {
        transform.position = patrolPoints[0].position;
        StartPatrol();
    }

    private void StartPatrol()
    {
        StartCoroutine(PatrolLoop());
        
        //local method
        IEnumerator PatrolLoop()
        {
            int index = 0;
        
            while (gameObject.activeSelf)
            {
                if (Mathf.Abs(transform.position.x - patrolPoints[index].position.x) > Mathf.Epsilon)
                {
                    transform.position = Vector2.MoveTowards(
                        transform.position,
                        patrolPoints[index].position,
                        moveSpeed * Time.deltaTime);

                    yield return null;
                    
                    continue;
                }

                index += 1;

                if (index > patrolPoints.Count - 1)
                {
                    index = 0;
                    patrolPoints.Reverse();
                }
            
                yield return null;

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        
        for (int i = 0; i < patrolPoints.Count; i++)
        {
            if (i+1 < patrolPoints.Count)
            {
                Gizmos.DrawLine(patrolPoints[i].position,patrolPoints[i+1].position);
            }
        }
    }
}
