using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Represents health</summary>
[System.Serializable]
public class Health {
    public float maxHealth = 100f;
    public float health = 100f;
    public float minHealth = 0f;

    public float getPercentage() {
        return this.health / Mathf.Abs(this.maxHealth - this.minHealth);
    }

    public void damage (float damaging) {
        setHealthWithValues(this.health - damaging);
    }

    public void heal (float healing) {
        setHealthWithValues(this.health + healing);
    }

    public void setHealthWithValues(float newHealth) {
        var healthToSet = this.minHealth <= newHealth && newHealth <= this.maxHealth
        ? ( newHealth )
        : ( newHealth > this.maxHealth ? this.maxHealth : this.minHealth);

        this.health = healthToSet;
    }
    
    public enum HealthChange { heal, damage }
}

/// <summary>
/// A Class that englobes general player features like health, avatar, etc...
/// </summary>
public class PlayerGeneral : MonoBehaviour {
    public static PlayerGeneral current;

    // Player sprite
    public Sprite avatar;
    public Health health;

    private void Awake() { current = this; }

    void Start() {
        if (PlayerEvents.current)
            PlayerEvents.current.setPlayerHealthListener(this.changeHealth);
        else
            Debug.Log("PlayerEvents.current not found");
    }

    Health changeHealth (Health.HealthChange type, float value) {
        if (type == Health.HealthChange.damage)
            this.health.damage(value);
        else
            this.health.heal(value);
        return this.health;
    }

    void Update() {}
}