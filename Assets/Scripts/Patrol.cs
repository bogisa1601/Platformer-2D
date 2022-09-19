using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [SerializeField] public List<Transform> patrolPoints;

    [SerializeField] private float moveSpeed;

    public int currentIndex = 0;
    
    public virtual void Start()
    {
        transform.position = patrolPoints[0].position;
        StartPatrol();
    }

    public virtual void StartPatrol()
    {
        StartCoroutine(PatrolLoop());
    }
    
    public IEnumerator PatrolLoop()
    {
        
        while (gameObject.activeSelf)
        {
            if (Mathf.Abs(transform.position.x - patrolPoints[currentIndex].position.x) > Mathf.Epsilon)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    patrolPoints[currentIndex].position,
                    moveSpeed * Time.deltaTime);

                yield return null;
                    
                continue;
            }

            currentIndex += 1;

            if (currentIndex > patrolPoints.Count - 1)
            {
                currentIndex = 0;
                patrolPoints.Reverse();
            }
            
            yield return null;

        }
    }
    
    public virtual void OnDrawGizmos()
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
