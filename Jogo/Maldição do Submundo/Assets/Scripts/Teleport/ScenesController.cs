using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesController : MonoBehaviour {

    public SceneField sceneTarget;

    void Start() {}

    void Update() {}

    // Change current scene to stored scene
    public void changeScene() {
        try {
            SceneManager.LoadScene(sceneTarget.SceneName);
        } catch {
            print("Scene didnt load");
        }
    }
}
