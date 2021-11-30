using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(ISelectHandler))]
public class Interactable : MonoBehaviour
{
    // public bool Enabled = true;
    private ISelectHandler _selectHandler;

    void Start ()
    {
        _selectHandler = GetComponent<ISelectHandler>();
    }

    public Action OnInteract = delegate {};
    public void Interact()
    {
        OnInteract();
    }

    // default: creates a text with the interaction key on position of the object
    public void Select() {
        _selectHandler.Select();
    }

    public void Deselect() {
        _selectHandler.Deselect();
    }

    public float GetDistanceToInteractable(GameObject interactable) {
        return Vector3.Distance(this.transform.position, interactable.transform.position);
    }
}
