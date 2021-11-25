using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Player sprite
    public Sprite avatar;

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
    }
}