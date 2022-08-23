using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2D;
    public float speed;
    
    void Start()
    {
        //rb2D.velocity = new Vector2(speed, 0);
        rb2D.velocity = Vector2.right * speed;
    }

}
