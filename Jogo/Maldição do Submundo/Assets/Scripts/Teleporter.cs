using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public float radious = 5.0f;
    public LayerMask playerLayer;
    public bool shouldChangeScene;
    public Scene sceneTarget;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        this.checkForInteraction();
    }
    
    void checkForInteraction() {
        var hit = Physics2D.OverlapCircle(this.transform.position, this.radious, this.playerLayer);

        if (hit != null) {
            this.changeScene();
        }
    }

    void changeScene() {
        SceneManager.LoadScene(sceneTarget.name);
    }

    public void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, this.radious);
    }
}
