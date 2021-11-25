using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Footstep : MonoBehaviour
{
    [SerializeField]
    private AudioClip defaultSound;
    [SerializeField]
    private FootstepManager footstepManager;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Player.current.Animation.onPlayerEventAnimation += OnPlayerAnimation;
    }

    // run OnStep on step event
    public void OnPlayerAnimation(PlayerAnimationEvents animation) {
        if (animation == PlayerAnimationEvents.Step) {
            OnStep();
        }
    }

    // play sound from footstep manager when footstep event is triggered
    public void OnStep () {
        var gotAudio = footstepManager.GetSound(this.gameObject);
        audioSource.clip = gotAudio != null ? gotAudio : defaultSound;
        audioSource.Play();
    }
}
