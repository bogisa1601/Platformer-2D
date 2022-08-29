using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform transformToFollow;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    
    
    // Update is called once per frame
    void Update()
    {
        transform.position =
            new Vector3(transformToFollow.position.x + xOffset, transformToFollow.position.y + yOffset, transform.position.z);
    }
}
