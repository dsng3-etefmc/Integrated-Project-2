using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    // Gets children and check if player is inside collision area, then takes a random sound
    public AudioClip GetSound(GameObject obj)
    {
        FootstepArea[] areas = GetComponentsInChildren<FootstepArea>();
        foreach (FootstepArea area in areas)
        {
            if (area.gameObject.activeInHierarchy)
            {
                var sound = area.GetRandomSound();
                if (sound) return sound;
            }
        }
        return null;
    }
}
