using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PlayerAnimationEvents {
    Step
}

public class PlayerAnimation : MonoBehaviour
{

    private Animator _animator;

    void Start ()
    {
        _animator = GetComponent<Animator>();
    }

    // Player animation on event
    public event Action<PlayerAnimationEvents> onPlayerEventAnimation = delegate {};
    public void TriggerPlayerEventAnimation (PlayerAnimationEvents animation) {
        onPlayerEventAnimation(animation);
    }

    public void PlayerDeath ()
    { 
        _animator.SetTrigger("death");
    }
}
