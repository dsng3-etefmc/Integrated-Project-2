using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{
    [SerializeField] public AudioClip[] onHit;
    [SerializeField] public AudioClip[] onDeath;

    public void Play (AudioClip[] clips)
    {
        var clip = GetRandomClip(clips);
        Play(clip);
    }

    public void Play (AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    private AudioClip GetRandomClip (AudioClip[] clips)
    {
        return clips[Random.Range(0, clips.Length)];
    }
}
