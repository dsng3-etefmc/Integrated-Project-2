using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>A <c>singleton</c> that handles dialogue</summary>
public class DialogueController : MonoBehaviour {
    private List<Dialogue> dialogues;

    public Canvas canvas;

    public Text textBox;
    public Text nameBox;
    public Image imageBox;

    private CanvasRenderer canvasRender;

    public static DialogueController current;

    private void Awake() {
        current = this;
    }

    void Start() {
        this.canvasRender = GetComponent<CanvasRenderer>();
        canvas.gameObject.SetActive(false);
    }

    void Update() {
        
    }

    Dialogue getNextDialogue () {
        if (this.dialogues.Count != 0) {
            var firstDialogue = dialogues[0];
            this.dialogues.RemoveAt(0);
            return firstDialogue;
        } else {
            return null;
        }
    }

    public void skipDialogue () {
        var nextDi = getNextDialogue();

        if (nextDi != null) {
            setDialogue(nextDi.avatar, nextDi.name, nextDi.text);
        } else {
            PlayerGeneral.current.Movement.AllowPlayerToMove(true);
            canvas.gameObject.SetActive(false);
        }
    }

    public void setMultipleDialogues(List<Dialogue> dialogues) {
        this.dialogues = dialogues;
        var firstDialogue = getNextDialogue();
        setDialogue(firstDialogue.avatar, firstDialogue.name, firstDialogue.text);
    }

    public void setDialogue(Sprite avatar, string name, string text) {
        this.textBox.text = text;
        this.nameBox.text = name;
        this.imageBox.sprite = avatar;

        PlayerGeneral.current.Movement.AllowPlayerToMove(false);
        canvas.gameObject.SetActive(true);
    }
}
