using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class HUDController : MonoBehaviour 
{
    public HUDState _currentState;
    
    // States
    public HUDState defaultState => normalInterface;

    [SerializeField] public NormalInterface normalInterface;
    [SerializeField] public DialogueUI dialogueInterface;

    // Start is called before the first frame update
    private void Start() {
        TransitTo(normalInterface);
    }

    public void TransitTo (HUDState state)
    {
        _currentState?.OnStateExit();
        _currentState = state;
        _currentState.EnterState(this);
    }
}
