using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>A class that triggers dialogues with given intection</summary>
public class DialogueCollider : MonoBehaviour {
    public List<Dialogue> dialogues;

    public bool runOnce = true;
    private int executed = 0;
    BoxCollider2D boxCollider2D;

    void Start() {
        this.boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update() {}

    // ---

    /// <summary>Triggers dialogue</summary>
    void triggerDialogue () {
        DialogueController.current.StartDialogues(
            this.dialogues, 
            onFinish: () => {
                this.executed += 1;
            }
        );
    }

    // Subscribe to collision event
    void OnTriggerEnter2D (Collider2D coll) {
        bool nTimesConstraint = this.runOnce ? this.executed == 0 : true;
        if (coll.gameObject.tag == "Player" && nTimesConstraint) {
            this.triggerDialogue();
        }
    }
}
