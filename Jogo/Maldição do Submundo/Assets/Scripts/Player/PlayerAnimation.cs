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
    // Player animation on event
    public event Action<PlayerAnimationEvents> onPlayerEventAnimation = delegate {};
    public void TriggerPlayerEventAnimation (PlayerAnimationEvents animation) {
        onPlayerEventAnimation(animation);
    }
}
