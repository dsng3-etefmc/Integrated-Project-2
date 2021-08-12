using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public float radious = 5.0f;
    public LayerMask playerLayer;
    public bool shouldChangeScene;
    public Object sceneTarget;

    void Start() {}

    void Update() {
        this.checkForInteraction();
    }
    
    /// <summary>Check if player is within the range</summary>
    void checkForInteraction() {
        var hit = Physics2D.OverlapCircle(this.transform.position, this.radious, this.playerLayer);

        if (hit != null) {
            this.changeScene();
        }
    }

    /// <summary>Change current scene to the target scene</summary>
    void changeScene() {
        SceneManager.LoadScene(sceneTarget.name);
    }

    // Gizmos circle
    public void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, this.radious);
    }
}
