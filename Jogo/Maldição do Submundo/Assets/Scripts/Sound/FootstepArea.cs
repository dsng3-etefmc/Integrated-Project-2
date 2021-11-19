using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FootstepArea : MonoBehaviour
{
    [SerializeField]
    public List<AudioClip> footstepSound = new List<AudioClip>();
    public Collider2D coll;

    void Start ()
    {
        coll = GetComponent<Collider2D>();
        coll.isTrigger = true;
    }

    public AudioClip GetRandomSound () 
    {
        return footstepSound[Random.Range(0, footstepSound.Count)];
    }

    public bool IsStepObjectTouching (GameObject obj) 
    {
        return coll.IsTouching(obj.GetComponent<Collider2D>());
    }
}
