using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Footstep : MonoBehaviour
{
    [System.Serializable]
    public struct TileToSound {
        public List<TileBase> tile;
        public List<AudioClip> sound;
    }

    private AudioSource audioSource;
    private Animator animator;

    [SerializeField]
    private AudioClip defaultSound;
    [SerializeField]
    private TileToSound[] tileToSounds;

    private GameObject player;
    private GameObject[] ground;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        animator = player.GetComponent<Animator>();
        ground = GameObject.FindGameObjectsWithTag("Ground");
        audioSource = GetComponent<AudioSource>();

        PlayerEvents.current.onPlayerAnimation += OnPlayerAnimation;
    }

    // run OnStep on step event
    void OnPlayerAnimation(PlayerAnimationEvents animation) {
        if (animation == PlayerAnimationEvents.Step) {
            OnStep();
        }
    }

    // check if player's animation emitted the 'step' event
    bool isPlayerStepping () {
        return false;
        // return animator.eve
    }

    // Play the sound of the tile the player is standing on using GetSoundOfTile() and GetTile()
    public void OnStep () {
        var tile = GetTile();
        var audio = GetSoundOfTile(tile);
        audioSource.PlayOneShot(audio);
    }

    // gets tite from GetTile function and maps to sound using tileToSounds, 
    // if no match, returns default sound
    AudioClip GetSoundOfTile(TileBase tile) {
        foreach (TileToSound tts in tileToSounds) {
            foreach (TileBase t in tts.tile) {
                if (t == tile) {
                    return tts.sound[Random.Range(0, tts.sound.Count)];
                }
            }
        }
        return defaultSound;
    }

    // get ground tile at player's position
    TileBase GetTile() {
        TileBase tile = null;
        foreach (GameObject g in ground) {
            if (g.transform.position == player.transform.position) {
                tile = g.GetComponent<Tilemap>().GetTile(g.GetComponent<Tilemap>().WorldToCell(player.transform.position));
            }
        }
        return tile;
    }
}
