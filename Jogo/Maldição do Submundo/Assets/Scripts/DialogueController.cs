using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue {
    public Sprite avatar;
    public string name;
    public string text;
}

public class DialogueController : MonoBehaviour {
    public Dialogue[] dialogues = {};

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
    }

    void Update() {
        
    }

    public void skipDialogue () {
        PlayerMoviment.current.shouldPlayerMove(true);
        canvas.gameObject.SetActive(false);
    }

    public void setDialogue(Sprite avatar, string name, string text) {
        this.textBox.text = text;
        this.nameBox.text = name;
        this.imageBox.sprite = avatar;

        PlayerMoviment.current.shouldPlayerMove(false);
        canvas.gameObject.SetActive(true);
    }
}
