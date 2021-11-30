using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class CutsceneManager : MonoBehaviour
{
    // [SerializeField]
    // private PlayableAsset[] cutscenes; 

    public static CutsceneManager current;

    private PlayableDirector playableDirector;

    private void Awake()
    {
        current = this;
    }

    void Update ()
    {
        if (playableDirector.state == PlayState.Playing)
        {
            Player.current.Collider.isTrigger = true;
        }
        else
        {
            Player.current.Collider.isTrigger = false;
        }
    }

    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void PlayCutscene (PlayableAsset cutscene)
    {
        playableDirector.playableAsset = cutscene;
        playableDirector.Play();
    }
}