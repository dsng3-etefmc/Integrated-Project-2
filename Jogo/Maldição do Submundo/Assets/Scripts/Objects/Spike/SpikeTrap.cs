using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpikeTrap : GenericTrap 
{
    [SerializeField]
    private bool isActive;
    [SerializeField]
    private float time;

    private Animator animator;

    private bool isDamaging;

    void Start() {
        this.animator = GetComponent<Animator>();

        StartCoroutine(this.StartTrap());
    }

    void Update() {
    }

    // if object is in bonds
    void OnTriggerStay2D (Collider2D collisionInfo)
    {
        GameObject obj = collisionInfo.gameObject;
        Health health = obj.GetComponent<Health>();
        var isNotAlreadyHit = !this.objectsHit.Contains(health);
        if (isDamaging && health != null && isNotAlreadyHit) {
            StartCoroutine(this.Hit(health));
        }
    }

    /// <summary>Starts the trap</summary>
    IEnumerator StartTrap() {
        while (true) {

            this.RetractSpikes();

            yield return new WaitForSeconds(this.time);

            this.LaunchSpikes();

            yield return new WaitForSeconds(this.time);

        }
    }

    /// <summary>Retract spikes animation</summary>
    void RetractSpikes() {
        this.animator.SetBool("spikeout", false);
        isDamaging = false;
    }

    /// <summary>Launch spikes animation</summary>
    void LaunchSpikes() {
        this.animator.SetBool("spikeout", true);
        isDamaging = true;
    }
}