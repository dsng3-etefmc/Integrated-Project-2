using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PlayerAnimationEvents {
    Step
}

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
    public void OnplayerChangeHealth (Health.HealthChange type, float value) {
        if (playerHealthListener != null) {
            Health newHealth = playerHealthListener(type, value);

            if (onPlayerChangeHealth != null) {
                this.onPlayerChangeHealth(newHealth);
            }
        } 
    }

    // Player animation on event

    public event Action<PlayerAnimationEvents> onPlayerAnimation;

    public void OnplayerEventAnimation (PlayerAnimationEvents animation) {
        if (onPlayerAnimation != null) {
            onPlayerAnimation(animation);
        }
    }
}
