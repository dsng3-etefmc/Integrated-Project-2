using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// A Class that englobes general player features like health, avatar, etc...
/// </summary>
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerInteracting))]
public class Player : MonoBehaviour {
    public static Player current;

    [SerializeField] private HUDController _HUDController;

    [System.NonSerialized]
    public Health Health;
    [System.NonSerialized]
    public PlayerMovement Movement;
    [System.NonSerialized]
    public PlayerAnimation Animation;
    [System.NonSerialized]
    public Collider2D Collider;
    private PlayerInteracting Interacting;

    private void Awake() { 
        current = this; 
        Health = GetComponent<Health>();
        Movement = GetComponent<PlayerMovement>();
        Animation = GetComponent<PlayerAnimation>();
        Collider = GetComponent<Collider2D>();
        Interacting = GetComponent<PlayerInteracting>();
    }

    void Start () {
        Health.onDeath += OnDeath;
    }

    void OnDeath(Health health) {
        Animation.PlayerDeath();
        Movement.AllowPlayerToMove(false);
        Interacting.AllowPlayerToInteract(false);
        _HUDController.TransitTo(_HUDController.deathScreen);
    }
}