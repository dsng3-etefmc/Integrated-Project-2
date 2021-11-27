using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Teleporter : MonoBehaviour {
    public bool shouldChangeScene;

    public SceneField sceneTarget;

    void Start ()
    {
        GetComponent<Interactable>().OnInteract += this.changeScene;
    }

    /// <summary>Change current scene to the target scene</summary>
    void changeScene() 
    {
        if (this.sceneTarget.SceneName != "")
            SceneManager.LoadScene(this.sceneTarget.SceneName);
    }

    // public override void Interact ()
    // {
    //     if (shouldChangeScene)
    //         changeScene();
    // }
}
