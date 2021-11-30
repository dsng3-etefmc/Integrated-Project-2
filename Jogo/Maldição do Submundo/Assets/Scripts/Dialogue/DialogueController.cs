using System;
using System.Collections;
using System.Threading.Tasks; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>A <c>singleton</c> that handles dialogue</summary>
public class DialogueController : MonoBehaviour {
    private List<Dialogue> dialogues;

    [SerializeField] private HUDController _HUDController;

    private CanvasRenderer canvasRender;

    public static DialogueController current;

    private bool isRunning = false;
    private UnityEvent _onFinish = new UnityEvent();

    private void Awake() {
        current = this;
    }

    void Start() {
        this.canvasRender = GetComponent<CanvasRenderer>();
        _HUDController.dialogueInterface.button.onClick.AddListener(SkipToNextDialogue);
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

    public void SkipToNextDialogue () {
        var nextDi = getNextDialogue();

        if (nextDi != null) {
            SetupDialogues(nextDi.avatar, nextDi.name, nextDi.text);
        } else {
            _onFinish.Invoke();
            Player.current.Movement.AllowPlayerToMove(true);
            _HUDController.dialogueInterface.FinishDialogues();
        }
    }

    public bool StartDialogues(List<Dialogue> dialogues, UnityAction onFinish = null) 
    {
        if (isRunning) return false;
        isRunning = true;
        _onFinish.RemoveAllListeners();
        if (onFinish != null) _onFinish.AddListener(onFinish);

        this.dialogues = dialogues;
        var firstDialogue = getNextDialogue();
        _HUDController.TransitTo(_HUDController.dialogueInterface);
        SetupDialogues(firstDialogue.avatar, firstDialogue.name, firstDialogue.text);

        return true;
    }

    public void SetupDialogues(Sprite avatar, string name, string text) {
        _HUDController.dialogueInterface.SetupDialogues(avatar, name, text);
        Player.current.Movement.AllowPlayerToMove(false);
    }
}
