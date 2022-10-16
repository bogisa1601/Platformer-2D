using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlock : MonoBehaviour
{

    [field: SerializeField] private Vector3 StartPos { get; set; }
    [field: SerializeField] private Vector3 EndPosition { get; set; }
    [field: SerializeField] private float FallDuration { get; set; }
    [field: SerializeField] private Transform RayOrigin { get; set; }
    [field: SerializeField] private BoxCollider2D BoxCollider2D { get; set; }
    [field: SerializeField] private LayerMask GroundLayerMask { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        GetGroundPosition();
        MoveToGround();
    }

   private void GetGroundPosition()
    {
        var rHit = Physics2D.Raycast(RayOrigin.position, Vector2.down, Mathf.Infinity, GroundLayerMask);
        if (rHit)
        {
            // EndPosition = rHit.point;
            EndPosition = new Vector3(transform.position.x, rHit.point.y + BoxCollider2D.bounds.extents.y + Mathf.Epsilon);
            
        }
    }

    private void MoveToGround()
    {
        StartCoroutine(Move());
        IEnumerator Move()
        {
            yield return new WaitForSeconds(0.5f);
            transform.DOMove(EndPosition, FallDuration).OnComplete(MoveToStartPosition).WaitForStart();
        }
    } 
    private void MoveToStartPosition()
    {
        StartCoroutine(Move());

        IEnumerator Move()
        {
            yield return new WaitForSeconds(0.5f);
            transform.DOMove(StartPos, FallDuration).OnComplete(MoveToGround);
        }
    }
}
