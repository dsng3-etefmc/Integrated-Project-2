using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public float radious = 2.5f;
    public bool shouldChangeScene;

    public SceneField sceneTarget;

    private CircleCollider2D collider;

    void Start() {
        this.collider = GetComponent<CircleCollider2D>();
    }

    void Update() {
        // this.checkForInteraction();
        this.collider.radius = this.radious;
    }
    
    /// <summary>Check if player is within the range</summary>
    // void checkForInteraction() {
    //     var hit = Physics2D.OverlapCircle(this.transform.position, this.radious, this.playerLayer);

    //     if (hit != null) {
    //         this.changeScene();
    //     }
    // }

    /// <summary>Change current scene to the target scene</summary>
    void changeScene() {
        if (this.sceneTarget.SceneName != "")
            SceneManager.LoadScene(this.sceneTarget.SceneName);
    }

    // Gizmos circle
    public void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, this.radious);
    }

    //
    void OnTriggerEnter2D (Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            this.changeScene();
        }
    }
}
