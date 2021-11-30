using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour, HUDState
{
    private HUDController _ctx;

    [SerializeField] private Text _textBox;
    [SerializeField] private Text _nameBox;
    [SerializeField] private Image _imageBox;
    [SerializeField] private Button _button;
    public Button button => _button;

    void Start() 
    {
        gameObject.SetActive(false);
    }

    public void EnterState(HUDController ctx)
    {
        gameObject.SetActive(true);
        _ctx = ctx;
    }

    public void OnStateExit()
    {
    }

    public void SetupDialogues(Sprite avatar, string name, string text) 
    {
        this._textBox.text = text;
        this._nameBox.text = name;
        this._imageBox.sprite = avatar;
    }

    public void FinishDialogues() 
    {
        gameObject.SetActive(false);
        _ctx.TransitTo(_ctx.defaultState);
    }
}
