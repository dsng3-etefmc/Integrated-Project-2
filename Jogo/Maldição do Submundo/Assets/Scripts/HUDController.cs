using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDController : MonoBehaviour {

    // Health bar
    public float health;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        this.updateHealthbar();
    }

    void updateHealthbar() {
        this.healthBar.value = 1 - health;
    }
}
