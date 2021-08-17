using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour {
    // self point
    public static PlayerEvents current;

    private void Awake() { current = this; }

    // Player listener
    private Func<Health.HealthChange, float, Health> playerHealthListener;
    public void setPlayerHealthListener (Func<Health.HealthChange, float, Health> returnEvent) {
        this.playerHealthListener = returnEvent;
    }

    // Player health on health change

    // -Actions
    public event Action<Health> onPlayerChangeHealth;
    
    // -Triggers
    public void playerTriggerChangeHealth (Health.HealthChange type, float health) {
        if (playerHealthListener != null) {
            Health newHealth = playerHealthListener(type, health);

            if (onPlayerChangeHealth != null) {
                this.onPlayerChangeHealth(newHealth);
            }
        } 
    }
}
