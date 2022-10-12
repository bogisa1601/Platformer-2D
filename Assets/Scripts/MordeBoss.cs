using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MordeBoss : MonoBehaviour
{
    [field:SerializeField] public float MoveSpeed { get; set; }
    [field:SerializeField] public float Damage { get; set; }
    [field:SerializeField] public float AttackThreshold { get; set; }
    [field:SerializeField] public float MoveThreshold { get; set; }
    [field:SerializeField] public Animator Animator { get; set; }

    private const string AttackTriggerName = "Attack";

    private Player Player => GameController.singleton.currentActivePlayer;

    
    
    void Update()
    {

        if (Vector2.Distance(transform.position, Player.transform.position) > MoveThreshold) return;

        RotateTowardsPlayer();

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), MoveSpeed * Time.deltaTime);

        if(Mathf.Abs(transform.position.x - Player.transform.position.x) < AttackThreshold)
        {
            Animator.SetTrigger(AttackTriggerName);
            
            Debug.Log("Boss Attack");
        }
    }

    private void RotateTowardsPlayer()
    {
        if(transform.position.x < Player.transform.position.x)
        {
            transform.localScale = Vector2.one;
            return;
        }
        transform.localScale = new Vector2(-1, 1);
    }
}
