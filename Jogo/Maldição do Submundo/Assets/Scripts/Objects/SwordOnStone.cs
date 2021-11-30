using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(ScenesController))]
public class SwordOnStone : MonoBehaviour
{
    [SerializeField]
    private List<Dialogue> dialogues;

    private Interactable _interactable;
    private ScenesController _scenesController;


    void Start ()
    {
        _interactable = GetComponent<Interactable>();
        _scenesController = GetComponent<ScenesController>();
        _interactable.OnInteract += OnInteract;
    }

    private void OnInteract ()
    {
       // Player.current.GameObject.Transform = new Vector3(44, -26, 0);
        DialogueController
            .current
            .StartDialogues(dialogues, onFinish: _scenesController.changeScene);
    }
}
