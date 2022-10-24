using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float randonDestroyFireStart;
    [SerializeField] private float randonDestroyFireEnd;

    [SerializeField] private float damage;

    private bool _canDamagePlayer = true;
    void Start()
    {
        Destroy(gameObject, Random.Range(randonDestroyFireStart, randonDestroyFireEnd));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Health health))
        {
            _canDamagePlayer = false;           
            health.ModifyHealth(-damage);
            StartCoroutine(ResetCanDamagePlayer());
        }
    }

    private IEnumerator ResetCanDamagePlayer()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamagePlayer = true;
    }
      


}
