using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour {
    public static PlayerEvents current;
    private void Awake() { current = this; }
}
