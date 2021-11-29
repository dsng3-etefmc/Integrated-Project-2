using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealthChange { heal, damage }

/// <summary>Represents health</summary>
[DisallowMultipleComponent]
public class Health : MonoBehaviour {
    // slider
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _minHealth;
    [SerializeField]
    private float _health;

    // expose private fields as public
    public float maxHealth { get => this._maxHealth; }
    public float minHealth { get => this._minHealth; }
    public float health { get => this._health; }
    private bool isDead = false;

    void Start () {
        refreshHealth();
    }

    void Update () {
        if (health <= 0 && !isDead) {
            onDeath(this);
            isDead = true;
        }
    }

    public void refreshHealth () {
        setHealthWithValues(this._health);
    }

    public float getPercentage() {
        return this._health / Mathf.Abs(this._maxHealth - this._minHealth);
    }

    public void damage (float damaging) {
        setHealthWithValues(this._health - damaging);
    }

    public void heal (float healing) {
        setHealthWithValues(this._health + healing);
    }

    public void changeHealth (HealthChange type, float value) {
        if (type == HealthChange.damage)
            this.damage(value);
        else
            this.heal(value);
    }

    private void setHealthWithValues(float newHealth) {
        this._health = Mathf.Clamp(newHealth, this._minHealth, this._maxHealth);

        // trigger actions
        onHeathChange(this);
    }

    public event Action<Health> onHeathChange = delegate {};
    public event Action<Health> onDeath = delegate {};
}