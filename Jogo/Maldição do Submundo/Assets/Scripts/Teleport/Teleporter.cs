using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public SceneField sceneTarget;

    void Start ()
    {
        var interactable = GetComponent<Interactable>();
        if (interactable != null) interactable.OnInteract += this.changeScene;
    }

    /// <summary>Change current scene to the target scene</summary>
    public void changeScene() 
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
