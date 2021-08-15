using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Class that englobes general player features like health, avatar, etc...
/// </summary>
public class PlayerGeneral : MonoBehaviour {
    public static PlayerGeneral current;
    public Sprite avatar;

    private void Awake() { current = this; }

    void Start() {}

    void Update() {}
}
