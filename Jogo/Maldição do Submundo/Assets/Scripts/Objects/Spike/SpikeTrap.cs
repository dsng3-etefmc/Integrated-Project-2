using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class SpikeTrap : GenericTrap 
{
    [SerializeField]
    private bool isActive;
    [SerializeField]
    private float time;

    private Animator _animator;
    private AudioSource _audioSource;

    private bool isDamaging;

    void Start() {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

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
        this._animator.SetBool("spikeout", false);
        isDamaging = false;
    }

    /// <summary>Launch spikes animation</summary>
    void LaunchSpikes() {
        this._animator.SetBool("spikeout", true);
        isDamaging = true;
    }

    void MakeSoundOnRelease ()
    {
        _audioSource.Play();
    }
}