using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShowKeyOnSelect : MonoBehaviour, ISelectHandler
{
    [SerializeField]
    private int sortingOrder;
    
    private GameObject _text;
    private TextMesh _textMesh;
    
    void Start ()
    {
        _text = new GameObject("InteractionText");
        _text.transform.SetParent(this.transform);
        _text.transform.localPosition = new Vector3(0, 0, 0);
        _text.AddComponent<SortingGroup>();

        var sortingGroup = _text.GetComponent<SortingGroup>();
        sortingGroup.sortingOrder = sortingOrder;

        _text.AddComponent<TextMesh>();

        _textMesh = _text.GetComponent<TextMesh>();
        _textMesh.text = "E";
        _textMesh.fontSize = 50;
        _textMesh.characterSize = 0.1f;
        _textMesh.anchor = TextAnchor.MiddleCenter;
        _textMesh.alignment = TextAlignment.Center;
        _textMesh.color = Color.white;

        _text.SetActive(false);
    }

    public void Select()
    {
        _text.SetActive(true);
    }

    public void Deselect()
    {
        _text.SetActive(false);
    }
}