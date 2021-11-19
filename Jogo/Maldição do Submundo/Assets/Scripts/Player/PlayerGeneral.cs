using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Class that englobes general player features like health, avatar, etc...
/// </summary>
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerGeneral : MonoBehaviour {
    public static PlayerGeneral current;

    // Player sprite
    public Sprite avatar;

    [System.NonSerialized]
    public Health Health;
    [System.NonSerialized]
    public PlayerMovement Movement;
    [System.NonSerialized]
    public PlayerAnimation Animation;

    private void Awake() { 
        current = this; 
        Health = GetComponent<Health>();
        Movement = GetComponent<PlayerMovement>();
        Animation = GetComponent<PlayerAnimation>();
    }

    void Start () {
    }
}