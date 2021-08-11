using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour
{
    public bool runOnce = true;
    private int executed = 0;
    BoxCollider2D boxCollider2D;

    void Start() {
        this.boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void triggerDialogue () {
        this.executed += 1;
        DialogueController.current.setDialogue(PlayerGeneral.current.avatar, "Player", "Hello");
    }

    void OnTriggerEnter2D (Collider2D coll) {
        bool nTimesConstraint = this.runOnce ? this.executed == 0 : true;
        if (coll.gameObject.tag == "Player" && nTimesConstraint) {
            this.triggerDialogue();
        }
    }
}
