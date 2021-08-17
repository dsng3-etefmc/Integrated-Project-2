using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikeTrap : MonoBehaviour {

    public float damage = 25f;
    public bool isActive = false;
    public float time = 15f;

    private Animator animator;

    private bool isPlayerInside = false;
    private bool alreadyHit = false;
    private bool shouldAttack = false;

    public void setActive() {
        this.isActive = true;
    }

    void Start() {
        this.alreadyHit = false;
        this.animator = GetComponent<Animator>();

        StartCoroutine(this.StartTrap());
    }

    void Update() {
        if (this.isPlayerInside && this.shouldAttack && !this.alreadyHit) {
            StartCoroutine(this.triggerHit());
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player"))
            this.isPlayerInside = true;
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("Player"))
            this.isPlayerInside = false;
    }

    /// <summary>Starts the trap</summary>
    IEnumerator StartTrap() {
        while (true) {

            this.RetractSpikes();
            this.shouldAttack = false;

            yield return new WaitForSeconds(this.time);

            this.LaunchSpikes();
            this.shouldAttack = true;

            yield return new WaitForSeconds(this.time);

        }
    }

    /// <summary>Retract spikes animation</summary>
    void RetractSpikes() {
        this.animator.SetTrigger("retractSpike");
    }

    /// <summary>Launch spikes animation</summary>
    void LaunchSpikes() {
        this.animator.SetTrigger("setSpike");
    }

    /// <summary>Triggers the hit damage and awaits a bit</summary>
    IEnumerator triggerHit() {
        this.alreadyHit = true;
        PlayerEvents.current.playerTriggerChangeHealth(
            Health.HealthChange.damage, 
            this.damage
        );

        yield return new WaitForSeconds(3);

        this.alreadyHit = false;
    }
}