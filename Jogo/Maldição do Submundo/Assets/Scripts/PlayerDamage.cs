using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    // [SerializeField] private float knockbackForce;
    [SerializeField] private float hitDuration;

    private bool _canAttack = true;

    IEnumerator ApplyExhaustion ()
    {
        _canAttack = false;
        yield return new WaitForSeconds(hitDuration);
        _canAttack = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        OnHit(other);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        OnHit(other.collider);
    }

    void OnHit (Collider2D other)
    {
        if (other.gameObject == Player.current.gameObject && _canAttack)
        {
            Player.current.Health.damage(damage);
            StartCoroutine(ApplyExhaustion());
        }
    }

    // not working
    // void Knockback (GameObject target, float angle)
    // {
    //     // var vectorFromAngle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * knockbackForce;
    //     target.GetComponent<Rigidbody2D>()?.AddForce(
    //         (target.transform.position - this.transform.position).normalized * knockbackForce,
    //         ForceMode2D.Impulse
    //     );
    // }
}

