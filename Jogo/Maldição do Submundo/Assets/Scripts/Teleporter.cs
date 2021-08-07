using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public float radious = 5.0f;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        
    }
    public void OnDrawGizmosSelected() {
        // Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, this.radious);
    }
}
