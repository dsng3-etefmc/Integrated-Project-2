using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDController : MonoBehaviour {

    // Health bar
    public Slider healthBar;

    // Start is called before the first frame update
    void Start() {
        PlayerGeneral.current.Health.onHeathChange += this.onPlayerHealthChange;
    }

    void onPlayerHealthChange (Health health) {
        this.updateHealthbar(health.getPercentage());
    }

    // Update is called once per frame
    void Update() {}

    void updateHealthbar(float newHealth) {
        this.healthBar.value = newHealth;
    }
}
