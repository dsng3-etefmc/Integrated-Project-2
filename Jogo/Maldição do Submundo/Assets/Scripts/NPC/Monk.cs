using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Monk : MonoBehaviour
{
    private Interactable _interactable;
    [SerializeField] private List<Dialogue> _dialogues;

    private void Start()
    {
        _interactable = GetComponent<Interactable>();
        _interactable.OnInteract += OnInteract;
    }

    void OnInteract()
    {
        DialogueController.current.StartDialogues(_dialogues);
    }
}
