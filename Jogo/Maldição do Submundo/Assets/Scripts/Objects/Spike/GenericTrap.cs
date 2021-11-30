using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericTrap : MonoBehaviour
{
    [SerializeField]
    protected float damage;
    
    protected List<Health> objectsHit = new List<Health>();

    /// <summary>Triggers the hit damage and awaits a bit</summary>
    protected virtual IEnumerator Hit(Health health)
    {
        this.objectsHit.Add(health);
        health.damage(this.damage);

        yield return new WaitForSeconds(3);

        this.objectsHit.Remove(health);
    }
}
